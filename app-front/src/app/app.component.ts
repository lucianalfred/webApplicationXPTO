import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import {NavigationComponent} from './components/navigation/navigation.component';
import { MainComponent } from './components/main/main.component';
import { PedidoAnonimoComponent } from './features/pedido/pedido-anonimo/pedido-anonimo.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './features/administrativo/dashboard/dashboard.component';
import { UtenteDashboardComponent } from './features/utente/dashboard-utente.component';
import { PedidoMarcacaoComponent } from './features/pedido/pedido-marcacao/pedido-marcacao.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, 
            HeaderComponent,
            NavigationComponent,
            MainComponent, 
            PedidoAnonimoComponent,
            LoginComponent,
            DashboardComponent,
            UtenteDashboardComponent,
            PedidoMarcacaoComponent,
            RouterModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'app-front';
}
