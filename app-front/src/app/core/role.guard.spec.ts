
import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../core/auth.service';

export function roleGuard(
  expected: 'Utente' | 'Administrativo' | 'Administrador'
): CanActivateFn {

  return () => {
    const auth   = inject(AuthService);
    const router = inject(Router);

    if (auth.hasRole(expected)) {
      return true;
    }


    router.navigate(['/login'], { queryParams: { returnUrl: router.url } });
    return false;
  };
}
