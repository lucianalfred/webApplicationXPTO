import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface PedidoResumo {
  id: number;
  data: string;        // ISO
  hora: string;        // HH:mm
  tipo: string;
  profissional?: string;
  estado: 'Pedido' | 'Agendado' | 'Realizado';
}


@Injectable({ providedIn: 'root' })
export class PedidoService {
  private api = 'https://localhost:5001/api/PedidoDeMarcacao';

  constructor(private http: HttpClient) {}

  getPedidosDoUtente(): Observable<any[]> {
    return this.http.get<any[]>(`${this.api}`);
  }

  criarPedido(pedido: any): Observable<any> {
    return this.http.post(`${this.api}`, pedido);
  }

  criarPedidoAnonimo(pedido: any): Observable<any> {
    return this.http.post(`${this.api}`, pedido);
  }

  getMeusPedidos(): Observable<PedidoResumo[]> {
    return this.http.get<PedidoResumo[]>('/api/PedidoDeMarcacao');
  }
}


