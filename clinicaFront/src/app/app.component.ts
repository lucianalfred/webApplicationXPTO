import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, CommonModule],
  template: './app.component.html',
  styles: './app.component.css'
})
export class AppComponent {
  constructor(private authService: AuthService) {}
  
  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }
  
  getCurrentUser() {
    return this.authService.getCurrentUser();
  }
  
  logout() {
    this.authService.logout();
  }
}