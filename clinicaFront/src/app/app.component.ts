import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PedidoFormComponent } from './pedido-form.component/pedido-form.component.component';
import { PedidoDetailsComponent } from './pedido-details.component/pedido-details.component.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    PedidoDetailsComponent,
    PedidoFormComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'clinicaFront';
}
