import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsuariossService {

  private baseURL = 'https://localhost:7041/api/Usuarios';

  private tipoDeUser!: number;

  constructor(private router: Router, private http: HttpClient) { }

  isLogged(): boolean {
    return localStorage.getItem('token') ? true : false;
  }

  setTipoDeUser(tipo: number): void {
    this.tipoDeUser = tipo;
  }

  getTipoDeUser(): number {
    return this.tipoDeUser;
  }

}
