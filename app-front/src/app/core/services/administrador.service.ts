import { Injectable, signal, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { finalize, of, catchError } from 'rxjs';
import { AuthService } from '../../core/auth.service';

@Injectable({ providedIn: 'root' })
export class AdminService {

  private apiRoot = 'http://localhost:5026/api/Utilizador';
  private auth = inject(AuthService);

  private _busy   = signal(false);
  private _perfil = signal<any | null>(null);

  constructor(private http: HttpClient) {}

  carregando() { return this._busy(); }
  perfil()     { return this._perfil(); }

  carregar() {
    const id = this.auth.userId();         
    if (!id) { console.error('Sem ID de utilizador'); return; }

    this._busy.set(true);

    this.http.get(`${this.apiRoot}/${id}`).pipe(
      finalize(() => this._busy.set(false)),
      catchError(err => { console.error(err); return of(null); })
    ).subscribe(d => this._perfil.set(d));
  }
}
