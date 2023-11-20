import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UsuariossService } from 'src/app/servicios/usuarioss.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  //recibir parametros para validacion del login

  Usuario1: string = "";
  Contrasena: string = "";
  credencialesincorrectas: boolean = false;
  idtipo: number = 0;
  
  constructor(private http: HttpClient, private router: Router, private usuarioservicio: UsuariossService) { }

  Validar() {
    const credenciales = {
      usuario1: this.Usuario1,
      contrasena: this.Contrasena,
      email: "",
      tipoDeUser: 0,
      tipoDeUserNavigation: {
      }
    };
    this.http.post('https://localhost:7041/api/Authentication/Validar', credenciales).subscribe(
      (response: any) => {
        //almacenar el tkoen JWT en el almacenamiento local
        localStorage.setItem('token', response.token);

        //redirigir a la pagina autorizada
        console.log('Redirigiendo a la página de dashboard...');
        this.router.navigate(['/dashboard']);

        this.http.get('https://localhost:7041/api/Usuarios').subscribe(
          (responseusu: any) => {
            const valores = responseusu.$values;

            for (const usuario of valores) {
              if (usuario.usuario1 === this.Usuario1 && usuario.contrasena === this.Contrasena) {
                //this.idtipo = usuario.tipoDeUser;
                this.usuarioservicio.setTipoDeUser(usuario.tipoDeUser);
              }
            }

            //this.usuarioservicio.setTipoDeUser(this.idtipo);

          }
        )


      },
      (error) => {
        this.credencialesincorrectas = true;
        console.log('Error de autenticación:', error);
      }
    );
  }

}
