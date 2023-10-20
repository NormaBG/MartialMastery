import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  username: string = '';
  password: string = '';
  loginError: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    this.authService.login(this.username, this.password).subscribe(
      (Response) => {
        if (Response.succes) {
          //inicio sesion correctamente
          this.router.navigate(['']);
        } else {
          //fallo la autenticacion
          this.loginError = 'Nombre de usuario o contraseña incorrecto';
        }
      },
      (error) => {
        //manejo de errores
        this.loginError = 'Hubo un problema al iniciar sesion';
      }
    )
  }
}
