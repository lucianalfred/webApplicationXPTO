import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-pedido-formulario',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './pedido-formulario.component.html',
  styleUrls: ['./pedido-formulario.component.scss']
})
export class PedidoFormularioComponent {
  constructor(private fb: FormBuilder) {}

  pedidoForm = this.fb.group({
    numeroUtente: ['', Validators.required],
    fotografia: [null],
    nomeCompleto: ['', Validators.required],
    dataNascimento: ['', Validators.required],
    genero: ['', Validators.required],
    telemovel: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    morada: ['', Validators.required],
    intervaloDatas: ['', Validators.required],
    horario: ['', Validators.required],
    observacoes: [''],
    actosClinicos: this.fb.array([])  // Depois vamos preencher
  });

  onSubmit() {
    if (this.pedidoForm.valid) {
      const dados = this.pedidoForm.value;
      console.log('Dados do pedido:', dados);
      
      // Aqui você chama a API com HttpClient
    }
  }
}
