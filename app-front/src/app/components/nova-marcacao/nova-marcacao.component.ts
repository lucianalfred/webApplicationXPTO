// src/app/components/nova-marcacao/nova-marcacao.component.ts
import { Component, inject, signal } from '@angular/core';
import {
  FormBuilder, FormGroup, ReactiveFormsModule,
  FormArray, Validators
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { HeaderComponent } from '../header/header.component';
import { NavigationComponent } from '../navigation/navigation.component';
import { AuthService } from '../../core/auth.service';     //  ⚑ usa token / user

@Component({
  selector: 'app-nova-marcacao',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HeaderComponent,
    NavigationComponent
  ],
  templateUrl: './nova-marcacao.component.html',
  styleUrls: ['./nova-marcacao.component.css']
})
export class NovaMarcacaoComponent {

  private fb = inject(FormBuilder);
  private http = inject(HttpClient);
  private auth = inject(AuthService);
  private router = inject(Router);

  // estados de UI
  etapa = signal(1);           // 1‑dados • 2‑actos • 3‑confirmação
  enviando = signal(false);
  sucesso = signal(false);

  tiposConsulta = ['Consulta Geral', 'Exame Oftalmológico', 'Exame Cardiológico'];
  subsistemas = ['SNS', 'Medis', 'Multicare', 'Privado'];

  form: FormGroup = this.fb.group({
    // (dados do pedido)
    intervaloDatas: ['', Validators.required],
    horarioSolicitado: ['', Validators.required],
    observacoes: [''],

    // lista de actos
    actosClinicos: this.fb.array([])
  });

  /** getter do FormArray para o template */
  get actosClinicos(): FormArray {
    return this.form.get('actosClinicos') as FormArray;
  }

  constructor() {
    // inicia com um acto clínico
    this.addActoClinico();
  }

  /* ---------------------------------------------------------
     controle das etapas
  --------------------------------------------------------- */
  next() { if (this.etapa() < 3) this.etapa.update(e => e + 1); }
  prev() { if (this.etapa() > 1) this.etapa.update(e => e - 1); }
  go(i: number) { this.etapa.set(i); }

  /* ---------------------------------------------------------
     actos clínicos dinâmicos
  --------------------------------------------------------- */
  addActoClinico() {
    this.actosClinicos.push(
      this.fb.group({
        tipo: ['', Validators.required],
        subsistema: ['', Validators.required],
        profissional: ['']
      })
    );
  }
  removeActoClinico(i: number) { this.actosClinicos.removeAt(i); }

  /* ---------------------------------------------------------
     submissão
  --------------------------------------------------------- */
  submit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const { intervaloDatas, horarioSolicitado, observacoes } = this.form.value;

    // monta DTO para a API
    const dto = {
      estado: 'PEDIDO',                          
      dataCriacao: new Date(),                   
      intervaloDatas,
      observacoes,
      dataAgendamento: new Date(),
      idUsuario : this.auth.userId(),          
      actosClinico: this.actosClinicos.value.map((a: any) => ({
        tipoDeActoClinico: a.tipo,
        subSistemaDeSaude: a.subsistema,
        profissionalId: a.profissional || null
      }))
    };


    this.enviando.set(true);

    this.http.post('http://localhost:5026/api/PedidoDeMarcacao', dto).subscribe({
      next: () => {
        this.enviando.set(false);
        this.sucesso.set(true);
        // opcional: navegar depois de alguns segundos
        setTimeout(() => this.router.navigate(['/utente/historico']), 1500);
      },
      error: err => {
        this.enviando.set(false);
        alert('Erro ao enviar pedido: ' + err.message);
      }
    });
  }
}
