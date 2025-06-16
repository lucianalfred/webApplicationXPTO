import { Component, OnInit } from '@angular/core';
import { PedidoService } from '../services/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PedidoDeMarcacaoDTO } from '../pedido-de-marcacao/pedido.model'

@Component({
  selector: 'app-pedido-form',
  standalone: true,
  templateUrl: './pedido-form.component.component.html',
  styleUrls: ['./pedido-form.component.component.css']
})
export class PedidoFormComponent implements OnInit {
  pedido: PedidoDeMarcacaoDTO = { id: 0, estadoDoPedidoDeMarcacao: 0, dataDeAgendamento: '' };
  isEdicao = false;

  constructor(private pedidoService: PedidoService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEdicao = true;
      this.pedidoService.getById(+id).subscribe(data => {
        this.pedido = data;
      });
    }
  }

  salvar(): void {
    if (this.isEdicao) {
      this.pedidoService.update(this.pedido.id, this.pedido).subscribe(() => {
        this.router.navigate(['/pedido']);
      });
    } else {
      this.pedidoService.create(this.pedido).subscribe(() => {
        this.router.navigate(['/pedido']);
      });
    }
  }
}
