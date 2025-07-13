import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from './auth.service';
// guarda-fábrica (recebe 'role' e devolve CanActivateFn)
export function roleGuard(expected: 'Utente' | 'Administrativo' | 'Administrador')
  : CanActivateFn {

  return () => {
    const auth = inject(AuthService);

    return auth.hasRole(expected);
  };
}
