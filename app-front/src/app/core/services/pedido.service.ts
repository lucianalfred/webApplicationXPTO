import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface PedidoResumo {
  id: number;
  utenteEmail: string,
  data: string;
  hora: string;
  tipo: string;
  profissional?: string;
  estado: 'Pedido' | 'Agendado' | 'Realizado';
}


@Injectable({ providedIn: 'root' })
export class PedidoService {
  private api = 'http://localhost:5026/api/PedidoDeMarcacao/';

  constructor(private http: HttpClient) { }

  getPedidosDoUtente(): Observable<any[]> {
    return this.http.get<any[]>(`${this.api}`);
  }

  criarPedido(pedido: any): Observable<any> {
    return this.http.post(`${this.api}`, pedido);
  }

  criarPedidoAnonimo(pedido: any): Observable<any> {
    return this.http.post(`${this.api}`, pedido);
  }
  getAll() {
    return this.http.get<any[]>(this.api);
  }

  agendar(id: number, data: Date, feedback?: string) {
    return this.http.put(`${this.api}${id}/agendar`,
      { dataAgendamento: data, feedback });
  }

  updateEstado(id: number, estado: string, feedback?: string) {
    return this.http.put(`${this.api}${id}`, { id, estado, feedback });
  }
  getMeusPedidos(): Observable<PedidoResumo[]> {
    return this.http.get<PedidoResumo[]>(`${this.api}`);
  }
}

