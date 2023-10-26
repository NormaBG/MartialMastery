import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UsuariossService {

  constructor() { }

  isLogged(): boolean {
    return localStorage.getItem('token') ? true : false;
  }
}
