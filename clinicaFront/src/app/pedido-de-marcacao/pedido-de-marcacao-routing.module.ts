import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PedidoListComponent } from '../pedido-list.component/pedido-list.component.component';
import { PedidoFormComponent } from '../pedido-form.component/pedido-form.component.component';
import { PedidoDetailsComponent } from '../pedido-details.component/pedido-details.component.component';

const routes: Routes = [
  { path: '', component: PedidoListComponent },
  { path: 'novo', component: PedidoFormComponent },
  { path: 'editar/:id', component: PedidoFormComponent },
  { path: 'detalhes/:id', component: PedidoDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PedidoDeMarcacaoRoutingModule { }
