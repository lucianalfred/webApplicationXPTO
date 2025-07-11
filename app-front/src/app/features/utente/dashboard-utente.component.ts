import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { AsyncPipe, CurrencyPipe, DatePipe, NgIf, NgFor } from '@angular/common';
import { AuthService } from '../../core/auth.service';
import { PedidoService, PedidoResumo } from "../../core/services/pedido.service";
import { HeaderComponent } from '../../components/header/header.component';
import { NavigationComponent } from '../../components/navigation/navigation.component';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-dashboard-utente',
  standalone: true,
  imports: [
    HeaderComponent,
    NavigationComponent,
    NgIf,
    NgFor,
    AsyncPipe,
    DatePipe,
    CommonModule
  ],
  templateUrl: './dashboard-utente.component.html',
  styleUrls: ['./dashboard-utente.component.css']
})
export class UtenteDashboardComponent implements OnInit {

  private auth = inject(AuthService);
  private pedidosSrv = inject(PedidoService);


  nome = this.auth.userName;
  id   = this.auth.userId;

  pedidos = signal<PedidoResumo[]>([]);

  pendentes   = computed(() => this.pedidos().filter(p => p.estado === 'Pedido').length);
  agendados   = computed(() => this.pedidos().filter(p => p.estado === 'Agendado').length);
  proximos    = computed(() => this.pedidos()
                               .filter(p => p.estado === 'Agendado' && new Date(p.data) > new Date())
                               .length);

  ngOnInit() {

    this.pedidosSrv.getMeusPedidos()
      .subscribe(p => this.pedidos.set(p));
  }
}
