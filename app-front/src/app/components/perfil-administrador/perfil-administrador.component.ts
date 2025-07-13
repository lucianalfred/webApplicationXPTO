import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { HeaderComponent } from '../header/header.component';
import { AdministradorNavigationComponent } from '../administrador-navigation/administrador-navigation.component';
import { AdminService } from '../../core/services/administrador.service';

@Component({
  selector   : 'app-perfil-administrador',
  standalone : true,
  imports    : [
    CommonModule,
    HeaderComponent,
    AdministradorNavigationComponent
  ],
  templateUrl: './perfil-administrador.component.html',
  styleUrls  : ['./perfil-administrador.component.css']
})
export class PerfilAdministradorComponent implements OnInit {
  asm = inject(AdminService);
  ngOnInit() { this.asm.carregar(); }   
}


