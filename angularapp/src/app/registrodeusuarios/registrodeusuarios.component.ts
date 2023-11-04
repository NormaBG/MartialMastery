import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
//import { HttpClient } from '@angular/common/http';
//import { Router } from '@angular/router';
import { UsuariossService } from 'src/app/servicios/usuarioss.service';

@Component({
  selector: 'app-registrodeusuarios',
  standalone: true,
  imports: [CommonModule, MatGridListModule,MatFormFieldModule, MatSelectModule, FormsModule, MatInputModule, MatButtonModule],
  templateUrl: './registrodeusuarios.component.html',
  styleUrls: ['./registrodeusuarios.component.css']
})
export class RegistrodeusuariosComponent {

  opcionSeleccionada: string = '';
  seleccionArte: string = '';
  usuarios: any = {};
  //parametros para recibir en el registro

  Usuario1: string = "";
  contrasena: string = "";
  email: string = "";

  //peleador

  NombreP: string = "";
  ApellidoP: string = "";
  EdadP: string = "";
  EstaturaP: string = "";
  pesoP: string = "";
  artemarcial: string = "";
  cinturon: string = "";

  //organizacion
  nombreO: string = "";
  descripcionO: string = "";
  artemarcialO: string = "";
  ubicacionO: string = "";

  //juez
  nombrej: string = "";
  apellidoj: string = "";
  edadj: string = "";

  constructor(private usuarioService: UsuariossService) { }
   
  crearUsuario() {
    this.usuarioService.crearUsuario(this.Usuario1).subscribe(
      (data) => {
        // Maneja la respuesta exitosa aquí
        console.log('Usuario creado exitosamente', data);
      },
      (error) => {
        // Maneja errores aquí
        console.error('Error al crear el usuario', error);
      }
    );
  }
}
