import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Token } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly tokenKey = 'token';
  private apiUtl = 'http://api/Usuarios';

  constructor(private http: HttpClient) { }

  //iniciar sesion y almacenar el token en el almacenamiento local

  login(username: string, password: string): Observable<any> {
    //solicitud http para autenticas usuario
    return this.http.post(`${this.apiUtl}/auth/login`, { username, password })
      .pipe(
        //respuesta y almacena token
        map((response: any) => {
          if (Token) {
            this.storeToken('token');
          }
        }
        ));
  }


  // Cerrar sesión y eliminar el token del almacenamiento local
  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }

  // Comprobar si el usuario está autenticado
  isAuthenticated(): boolean {
    return localStorage.getItem(this.tokenKey) !== null;
  }

  // Obtener el token almacenado
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  private storeToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  private removeToken(): void {
    localStorage.removeItem(this.tokenKey);
  }

}
