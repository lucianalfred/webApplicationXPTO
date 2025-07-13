import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../header/header.component';
import { NavigationComponent } from '../navigation/navigation.component';
import { UserService } from '../../core/service/user.service';

@Component({
  selector   : 'app-perfil-utilizador',
  standalone : true,
  imports    : [CommonModule, HeaderComponent, NavigationComponent],
  templateUrl: './perfil-utilizador.component.html',
  styleUrls  : ['./perfil-utilizador.component.css']
})
export class PerfilUtilizadorComponent implements OnInit {

  us  = inject(UserService);

  ngOnInit() { this.us.carregar(); }
}
