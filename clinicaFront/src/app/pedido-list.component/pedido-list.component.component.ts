import { Component, OnInit } from '@angular/core';
import { PedidoService } from '../services/api.service';
import { Router } from '@angular/router';
import { PedidoDeMarcacaoDTO } from '../pedido-de-marcacao/pedido.model'

@Component({
  selector: 'app-pedido-list',
  templateUrl: './pedido-list.component.component.html',
  styleUrls: ['./pedido-list.component.component.css']
})
export class PedidoListComponent implements OnInit {
  pedidos: PedidoDeMarcacaoDTO[] = [];

  constructor(private pedidoService: PedidoService, private router: Router) {}

  ngOnInit(): void {
    this.pedidoService.getAll().subscribe(data => {
      this.pedidos = data;
    });
  }

  verDetalhes(id: number): void {
    this.router.navigate(['/pedido/detalhes', id]);
  }

  editarPedido(id: number): void {
    this.router.navigate(['/pedido/editar', id]);
  }

  removerPedido(id: number): void {
    this.pedidoService.delete(id).subscribe(() => {
      this.pedidos = this.pedidos.filter(p => p.id !== id);
    });
  }
}
