// components/administrativo-dashboard/administrativo-dashboard.component.ts
import { Component, OnInit, inject, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HeaderComponent } from '../header/header.component';
import { AdministrativoNavigationComponent }
        from '../administrativo-navigation/administrativo-navigation.component';

import { PedidoService } from '../../core/services/pedido.service';

@Component({
  selector   : 'app-administrativo-dashboard',
  standalone : true,
  imports    : [
    CommonModule,
    HeaderComponent,
    AdministrativoNavigationComponent
  ],
  templateUrl: './administrativo-dashboard.component.html',
  styleUrls  : ['./administrativo-dashboard.component.css']
})
export class AdministrativoDashboardComponent implements OnInit {

  private pedidoSrv = inject(PedidoService);

  pedidos = signal<any[]>([]);

  /* contagens computadas */
  total       = computed(() => this.pedidos().length);
  emEspera    = computed(() => this.pedidos().filter(p => p.estado === 'PEDIDO').length);
  agendados   = computed(() => this.pedidos().filter(p => p.estado === 'AGENDADO').length);
  concluidos  = computed(() => this.pedidos().filter(p => p.estado === 'REALIZADO').length);

  ngOnInit() {
    this.pedidoSrv.getAll()
      .subscribe(dados => this.pedidos.set(dados));
  }
}
