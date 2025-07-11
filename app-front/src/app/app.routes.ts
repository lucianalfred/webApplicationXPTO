import { Routes } from '@angular/router';

import { UtenteDashboardComponent } from './features/utente/dashboard-utente.component';
import { DashboardComponent } from './features/administrativo/dashboard/dashboard.component';
import { NovaMarcacaoComponent } from './components/nova-marcacao/nova-marcacao.component';
import { HistoricoMarcacoesComponent } from './components/historico-marcacoes/historico-marcacoes.component';
import { PerfilUtilizadorComponent } from './components/perfil-utilizador/perfil-utilizador.component';

import { PedidoAnonimoComponent } from './features/pedido/pedido-anonimo/pedido-anonimo.component';
import { PedidoMarcacaoComponent } from './features/pedido/pedido-marcacao/pedido-marcacao.component';
import { MainComponent } from './components/main/main.component';
import { LoginComponent } from './login/login.component';
export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  
  { path: 'utente', component: UtenteDashboardComponent },
  { path: 'utente/dashboard',        component:  UtenteDashboardComponent},
  { path: 'utente/nova-marcacao',    component: NovaMarcacaoComponent },
  { path: 'utente/historico',        component: HistoricoMarcacoesComponent },
  { path: 'utente/perfil',           component: PerfilUtilizadorComponent },

  { path: 'home', component: MainComponent},
  { path: 'login', component: LoginComponent},
  
  { path: 'utente/pedidos/novo', component: PedidoMarcacaoComponent },
  
  { path: 'utente/pedidos/anonimo', component: PedidoAnonimoComponent },
  
  { path: '**', redirectTo: 'home' }

];
