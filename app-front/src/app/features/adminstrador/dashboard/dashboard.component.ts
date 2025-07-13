// dashboard.component.ts
import { Component, OnInit } from '@angular/core';
import { UtilizadorService } from '../../../core/services/utilizador.service';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../../../components/header/header.component';
import { AdministradorNavigationComponent } from '../../../components/administrador-navigation/administrador-navigation.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports:[CommonModule, HeaderComponent, AdministradorNavigationComponent],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  utilizadores: any[] = [];
  ativos: number = 0;
  inativos: number = 0;

  constructor(private utilizadorService: UtilizadorService) {}

  ngOnInit(): void {
    this.carregarUtilizadores();
  }

  carregarUtilizadores() {
    this.utilizadorService.obterTodos().subscribe({
      next: (dados) => {
        this.utilizadores = dados;
        this.ativos = dados.filter((u: any) => u.estadoDoUtilizador).length;
        this.inativos = dados.filter((u: any) => !u.estadoDoUtilizador).length;
      },
      error: (erro) => console.error('Erro ao carregar utilizadores', erro)
    });
  }

  ativar(id: number) {
    this.utilizadorService.atualizarEstado(id, true).subscribe(() => this.carregarUtilizadores());
  }

  desativar(id: number) {
    this.utilizadorService.atualizarEstado(id, false).subscribe(() => this.carregarUtilizadores());
  }

  verPerfil(id: number) {
    
    window.location.href = `/adminstrador/perfil?id=${id}`;
  }
}