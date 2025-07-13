import { Component, OnInit, inject, signal } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { UtilizadorService } from '../../core/services/utilizador.service';
import { AuthService } from '../../core/auth.service';
import { HeaderComponent } from '../../components/header/header.component';
import { AdministradorNavigationComponent }
  from '../../components/administrador-navigation/administrador-navigation.component';

@Component({
  selector: 'app-administrador-utilizadores',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HeaderComponent,
    AdministradorNavigationComponent
  ],
  templateUrl: './administrador-utilizadores.component.html',
  styleUrls: ['./administrador-utilizadores.component.css']
})
export class AdministradorUtilizadoresComponent implements OnInit {

  // sinais/estado
  modalPerfilAberto = signal(false);
  modalAdicionarAberto = signal(false);

  perfil: any = null;
  utilizadores: any[] = [];
  ativos = 0;
  inativos = 0;

  private fb = inject(FormBuilder);

  // form‑group para o modal
  addForm = this.fb.group({
    nome: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    dataNascimento: ['', Validators.required],
    morada: [''],
    genero: ['Masculino'],
    telefone: [''],
    papel: ['Utente', Validators.required]
  });

  constructor(
    private utilizadorService: UtilizadorService,
    private authService: AuthService
  ) { }

  ngOnInit() { this.carregarUtilizadores(); }


  carregarUtilizadores() {
    this.utilizadorService.obterTodos().subscribe({
      next: dados => {
        this.utilizadores = dados;
        this.ativos = dados.filter(u => u.estadoDoUtilizador).length;
        this.inativos = dados.length - this.ativos;
      },
      error: err => console.error('Erro ao carregar utilizadores', err)
    });
  }

  ativar(id: number) {
    this.utilizadorService.atualizarEstado(id, true).subscribe(() => this.carregarUtilizadores());
  }
  desativar(id: number) {
    this.utilizadorService.atualizarEstado(id, false).subscribe(() => this.carregarUtilizadores());
  }


  verPerfil(id: number) {
    this.utilizadorService.obterPorId(id).subscribe({
      next: u => { this.perfil = u; this.modalPerfilAberto.set(true); },
      error: () => alert('Erro ao carregar perfil')
    });
  }
  fecharPerfil() { this.modalPerfilAberto.set(false); }


  abrirAdicionar() {
    this.addForm.reset({ genero: 'Masculino', papel: 'Utente' });
    this.modalAdicionarAberto.set(true);
  }
  fecharAdicionar() { this.modalAdicionarAberto.set(false); }

  submeterNovo() {
    if (this.addForm.invalid) return this.addForm.markAllAsTouched();

    this.authService.registrar(this.addForm.value).subscribe({
      next: () => {
        this.fecharAdicionar();
        this.carregarUtilizadores();
      },
      //error: error => alert('Erro ao registar utilizador\n' + err.error?.message || '')
    });
  }
}
