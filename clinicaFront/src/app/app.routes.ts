import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { MarcacaoAnonimaComponent } from './marcacao/marcacao-anonima/marcacao-anonima.component';
import { DashboardUtenteComponent } from './utente/dashboard-utente/dashboard-utente.component';
import { DashboardAdministrativoComponent } from './administrativo/dashboard-administrativo/dashboard-administrativo.component';
import { DashboardAdministradorComponent } from './administrador/dashboard-administrador/dashboard-administrador.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'marcacao-anonima', component: MarcacaoAnonimaComponent },
  { path: 'utente', component: DashboardUtenteComponent, canActivate: [AuthGuard] },
  { path: 'administrativo', component: DashboardAdministrativoComponent, canActivate: [AuthGuard] },
  { path: 'administrador', component: DashboardAdministradorComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '' }
];