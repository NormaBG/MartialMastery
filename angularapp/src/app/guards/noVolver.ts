import { inject } from '@angular/core';
import { Router } from '@angular/router';


export const noVolver = () => {

  const router = inject(Router)

  if (localStorage.getItem('token')) {
    router.navigate(['/dashboard']);
    return false;
  }
    return true;
  
}

/*
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
*/
