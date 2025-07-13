import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({ providedIn: 'root' })
export class UtilizadorService {
  private readonly api = `http://localhost:5026/api/Utilizador/`;

  constructor(private http: HttpClient) {}

  obterPorId(id:number){
    return this.http.get<any[]>(`${this.api}${id}`)
  }
  obterTodos(): Observable<any[]> {
    return this.http.get<any[]>(this.api);
  }

  atualizarEstado(id: number, ativo: boolean): Observable<any> {
    return this.http.put(`${this.api}${id}`, { id, estadoDoUtilizador: ativo });
  }
}
