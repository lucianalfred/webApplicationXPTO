import { Component, inject } from '@angular/core';
import { AuthService } from '../../core/auth.service';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  private auth = inject(AuthService);
  private router = inject(Router);
  
  get nome(): string | null { return this.auth.userName() ?? "Utilizador"; }

  
  isLoggedIn(): boolean { return this.auth.isLoggedIn(); }

  logout() {
    this.auth.logout();
    this.router.navigate(['/login']);       // redireciona após sair
  }
}
