import { Component } from '@angular/core';
import { NavigationComponent } from '../navigation/navigation.component';
import { HeaderComponent } from '../header/header.component';
@Component({
  selector: 'app-perfil-utilizador',
  standalone: true,
  imports: [HeaderComponent, NavigationComponent],
  templateUrl: './perfil-utilizador.component.html',
  styleUrl: './perfil-utilizador.component.css'
})
export class PerfilUtilizadorComponent {

}
