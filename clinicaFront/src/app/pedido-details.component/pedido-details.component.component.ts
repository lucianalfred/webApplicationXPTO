import { Component, OnInit } from '@angular/core';
import { PedidoService } from '../services/api.service';
import { ActivatedRoute } from '@angular/router';
import { PedidoDeMarcacaoDTO } from '../pedido-de-marcacao/pedido.model';

@Component({
  selector: 'app-pedido-details',
  standalone: true,
  templateUrl: './pedido-details.component.component.html',
  styleUrls: ['./pedido-details.component.component.css']
})
export class PedidoDetailsComponent implements OnInit {
  pedido: PedidoDeMarcacaoDTO | undefined;

  constructor(private pedidoService: PedidoService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.pedidoService.getById(+id).subscribe(data => {
        this.pedido = data;
      });
    }
  }
}
