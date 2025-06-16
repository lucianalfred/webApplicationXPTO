import { Routes } from '@angular/router';
import { PedidoListComponent } from './pedido-list.component/pedido-list.component.component';
import { PedidoFormComponent } from './pedido-form.component/pedido-form.component.component';
import { PedidoDetailsComponent } from './pedido-details.component/pedido-details.component.component';

export const routes: Routes = [
  { path: 'pedido', component: PedidoListComponent },
  { path: 'pedido/novo', component: PedidoFormComponent },
  { path: 'pedido/editar/:id', component: PedidoFormComponent },
  { path: 'pedido/detalhes/:id', component: PedidoDetailsComponent },
  { path: '', redirectTo: '/pedido', pathMatch: 'full' }
];




