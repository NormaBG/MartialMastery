// auth.guard.ts
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class noVolver{
  constructor(private router: Router) { }

  NoVolver (): boolean {
    // comprueba si el usuario a iniciado sesion
    if (localStorage.getItem('token')) {
      this.router.navigate(['/dashboard']); // Redirige al panel de control si el usuario ya está autenticado.
      return false; // No permite el acceso a la página de inicio de sesión.
    }
    return true; 
  }
}
