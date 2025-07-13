import { Routes } from '@angular/router';
import { roleGuard } from './core/role.guard';

import { UtenteDashboardComponent } from './features/utente/dashboard-utente.component';
import { NovaMarcacaoComponent } from './components/nova-marcacao/nova-marcacao.component';
import { HistoricoMarcacoesComponent } from './components/historico-marcacoes/historico-marcacoes.component';
import { PerfilUtilizadorComponent } from './components/perfil-utilizador/perfil-utilizador.component';

import { PedidoAnonimoComponent } from './features/pedido/pedido-anonimo/pedido-anonimo.component';
import { PedidoMarcacaoComponent } from './features/pedido/pedido-marcacao/pedido-marcacao.component';
import { MainComponent } from './components/main/main.component';
import { LoginComponent } from './login/login.component'; 

import { AdministradorUtilizadoresComponent } from './components/administrador-utilizadores/administrador-utilizadores.component';
import { DashboardComponent } from './features/adminstrador/dashboard/dashboard.component';
import { PerfilAdministradorComponent } from './components/perfil-administrador/perfil-administrador.component';

import { AdministrativoDashboardComponent } from './components/administrativo-dashboard/administrativo-dashboard.component';
import { AdministrativoPedidosComponent } from './components/administrativo-pedidos/administrativo-pedidos.component';
import { PerfilAdministrativoComponent } from './components/perfil-administrativo/perfil-administrativo.component';



export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  
  { path: 'utente', component: UtenteDashboardComponent, canActivate: [roleGuard('Utente')] },
  { path: 'utente/dashboard',        component:  UtenteDashboardComponent, canActivate: [roleGuard('Utente')]},
  { path: 'utente/nova-marcacao',    component: NovaMarcacaoComponent, canActivate: [roleGuard('Utente')] },
  { path: 'utente/historico',        component: HistoricoMarcacoesComponent, canActivate: [roleGuard('Utente')]},
  { path: 'utente/perfil',           component: PerfilUtilizadorComponent, canActivate: [roleGuard('Utente')]},

  { path: 'administrador/dashboard', component: DashboardComponent, canActivate: [roleGuard('Administrador')]},
  { path: 'adminstrador/utilizadores',        component: AdministradorUtilizadoresComponent, canActivate: [roleGuard('Administrador')]},
  { path: 'administrador/perfil',           component: PerfilAdministradorComponent, canActivate: [roleGuard('Administrador')]},
  
  { path: 'administrativo/dashboard', component: AdministrativoDashboardComponent, canActivate: [roleGuard('Administrativo')]},
  {path: 'administrativo/pedidos', component: AdministrativoPedidosComponent, canActivate: [roleGuard('Administrativo')]},
  { path: 'administrativo/perfil',           component: PerfilAdministrativoComponent, canActivate: [roleGuard('Administrativo')]},

  
  { path: 'home', component: MainComponent},
  { path: 'login', component: LoginComponent},
  
  { path: 'utente/pedidos/novo', component: PedidoMarcacaoComponent,  canActivate: [roleGuard('Utente')]},
  
  { path: 'utente/pedidos/anonimo', component: PedidoAnonimoComponent },
  
  { path: '**', redirectTo: '/home' }

];
