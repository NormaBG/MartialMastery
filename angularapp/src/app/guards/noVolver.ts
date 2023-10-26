import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable()
export class noVolver implements CanActivate {
  constructor(private router: Router) { }

  canActivate(): boolean {
    // Comprueba aquí si el usuario ha iniciado sesión
    if (localStorage.getItem('token')) {
      this.router.navigate(['/dashboard']);
      return false; //prohibe acceso a login
    }
    return true; 
  }
}
