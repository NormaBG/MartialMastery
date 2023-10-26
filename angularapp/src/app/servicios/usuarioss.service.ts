import { Injectable } from '@angular/core';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class UsuariossService {

  constructor(private router: Router) { }

  isLogged(): boolean {
    return localStorage.getItem('token') ? true : false;
  }
}
