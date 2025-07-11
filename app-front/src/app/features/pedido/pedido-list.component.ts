import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PedidoService } from '../../core/services/pedido.service';

@Component({
  selector: 'app-pedido-list',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h2>Histórico de Pedidos</h2>
    <ul *ngIf="pedidos?.length">
      <li *ngFor="let pedido of pedidos">
        #{{ pedido.id }} - {{ pedido.estado }} - {{ pedido.dataCriacao | date }}
      </li>
    </ul>
    <p *ngIf="!pedidos?.length">Nenhum pedido encontrado.</p>
  `
})
export class PedidoListComponent implements OnInit {
  private pedidoService = inject(PedidoService);
  pedidos: any[] = [];

  ngOnInit(): void {
    this.pedidoService.getPedidosDoUtente().subscribe({
      next: data => this.pedidos = data,
      error: err => console.error('Erro ao carregar histórico', err)
    });
  }
}
