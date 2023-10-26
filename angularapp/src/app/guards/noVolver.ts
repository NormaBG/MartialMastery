// auth.guard.ts
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable()
export class noVolver implements CanActivate {
  constructor(private router: Router) { }

  canActivate(): boolean {
    // comprueba si el usuario a iniciado sesion
    if (localStorage.getItem('token')) {
      this.router.navigate(['/dashboard']); // Redirige al panel de control si el usuario ya está autenticado.
      return false; // No permite el acceso a la página de inicio de sesión.
    }
    return true; // Permite el acceso a la página de inicio de sesión si el usuario no ha iniciado sesión.
  }
}
