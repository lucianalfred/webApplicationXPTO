import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../core/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {
  email = '';
  password = '';

  constructor(private auth: AuthService, private router: Router) { }

  onSubmit() {
    this.auth.login(this.email, this.password).subscribe({
      next: res => {
        const payload: any = jwtDecode(res.token);
        const role = payload.role;
        console.log("papel: ",role,"Payload: ", payload);

        switch (role) {
          case 'Administrador':
            this.router.navigateByUrl('/admin'); break;
          case 'Administrativo':
            this.router.navigateByUrl('/administrativo'); break;
          case 'Utente':
            console.log("Utente log");
            this.router.navigateByUrl('/utente'); break;
          default:
            console.log("default role");
            this.router.navigateByUrl('/'); // fallback
        }
      },
      error: err => alert('Credenciais inválidas')
    });
  }

}