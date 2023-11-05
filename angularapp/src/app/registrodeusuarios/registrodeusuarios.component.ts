import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
//import { UsuariossService } from 'src/app/servicios/usuarioss.service';

interface TiposDeUsuario {
  [key: string]: number;
}


@Component({
  selector: 'app-registrodeusuarios',
  standalone: true,
  imports: [CommonModule, MatGridListModule, MatFormFieldModule, MatSelectModule, FormsModule, MatInputModule, MatButtonModule],
  templateUrl: './registrodeusuarios.component.html',
  styleUrls: ['./registrodeusuarios.component.css']
})
export class RegistrodeusuariosComponent {

  seleccionArte: string = '';
  opcionSeleccionada: string = '';


  //recibir parametros para el registro
  user = {
    idUsuario: 0,
    Usuario1: '',
    Contrasena: '',
    email: '',
    tipodeuser: 0,
    "tipoDeUserNavigation": {
    }
  }

tiposDeUsuario: TiposDeUsuario = {
  'Elige una opción': 0,
  'Peleador': 2,
  'Organizacion': 4,
  'Juez': 3,
};

  constructor(private http: HttpClient, private router: Router) { }
  registerUser() {
    this.user.tipodeuser = this.tiposDeUsuario[this.opcionSeleccionada];
    this.http.post('https://localhost:7041/api/Usuarios', this.user).subscribe(
        (response) => {
          console.log('Usuario registrado con éxito');
        },
        (error) => {
          console.error('Error al registrar usuario', error);
          console.log(this.user);
        }
      );
  }
}
