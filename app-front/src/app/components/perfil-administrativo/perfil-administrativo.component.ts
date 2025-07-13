import { Component, OnInit, inject} from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { AdministrativoNavigationComponent } from '../administrativo-navigation/administrativo-navigation.component';
import { AdministrativoService } from '../../core/services/administrativo.service';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-perfil-administrativo',
  standalone: true,
  imports: [HeaderComponent,AdministrativoNavigationComponent, CommonModule],
  templateUrl: './perfil-administrativo.component.html',
  styleUrl: './perfil-administrativo.component.css'
})
export class PerfilAdministrativoComponent {
   adm = inject(AdministrativoService);
   ngOnInit() { this.adm.carregar(); } 
}
