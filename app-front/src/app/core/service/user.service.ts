// core/user.service.ts
import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../auth.service';

export interface UsuarioPerfil {
  nome: string;
  dataNascimento: string;
  morada: string;
  telefone: string;
  urlDaFotografia?: string;
  estadoDoUtilizador: boolean;
  tipoUtilizador: string;
}

@Injectable({ providedIn: 'root' })
export class UserService {

  private http  = inject(HttpClient);
  private auth  = inject(AuthService);

  perfil = signal<UsuarioPerfil | null>(null);
  carregando = signal(false);

  carregar() {
    const id = this.auth.userId();    
    if (!id) return;

    this.carregando.set(true);
    this.http.get<UsuarioPerfil>(`http://localhost:5026/api/Utilizador/${id}`)
      .subscribe({
        next : p => this.perfil.set(p),
        error: _ => { },
        complete: () => this.carregando.set(false)
      });
  }
}
