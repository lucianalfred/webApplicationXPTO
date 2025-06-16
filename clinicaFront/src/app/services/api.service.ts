import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PedidoDeMarcacaoDTO } from '../pedido-de-marcacao/pedido.model'

@Injectable({
  providedIn: 'root'
})
export class PedidoService {
  private apiUrl = 'http://localhost:5000/api/PedidoDeMarcacao';

  constructor(private http: HttpClient) {}

  getAll(): Observable<PedidoDeMarcacaoDTO[]> {
    return this.http.get<PedidoDeMarcacaoDTO[]>(this.apiUrl);
  }

  getById(id: number): Observable<PedidoDeMarcacaoDTO> {
    return this.http.get<PedidoDeMarcacaoDTO>(`${this.apiUrl}/${id}`);
  }

  create(pedido: PedidoDeMarcacaoDTO): Observable<any> {
    return this.http.post(this.apiUrl, pedido);
  }

  update(id: number, pedido: PedidoDeMarcacaoDTO): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, pedido);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
