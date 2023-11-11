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

  //peleador
  peleador = {
    idPeleador: 0,
    nombre: "",
    apellido: "",
    edad: "",
    estatura: 0,
    peso: 0,
    artemarcial: "",
    cinturon: "",
    organizacion: "",
    peleasganadas: 0,
    peleasperdidas: 0,
    "peleadore": [
    ]
  }

  //organizacion
  org = {
    "idOrg": 0,
    "nombre": "",
    "descripcion": "",
    "artemarcial": "",
    "ubicacion": "",
  }

  //juez
  juez = {
    "idJuez": 0,
    "nombre": "",
    "apellido": "",
    "edad": "",
    "peleasj": "NULL",
    "juece": [
     
    ]
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
        console.log(this.peleador);
      },
        (error) => {
          console.error('Error al registrar usuario', error);
          console.log(this.user);
        }
    );
    if (this.opcionSeleccionada === 'Peleador') {
      this.http.post('https://localhost:7041/api/Peleadores', this.peleador).subscribe(
        (response) => {
          console.log('Peleador registrado');
        }
      )
    } else if (this.opcionSeleccionada === 'Organizacion') {
      this.http.post('https://localhost:7041/api/Organizaciones', this.org).subscribe(
        (response) => {
          console.log('Organizacion Registrada')
        }
      )
    } else if (this.opcionSeleccionada === 'Juez') {
      this.http.post('https://localhost:7041/api/Jueces', this.juez).subscribe(
        (response) => {
          console.log('Juez Registrado')
        }
      )
    }
  }
}
