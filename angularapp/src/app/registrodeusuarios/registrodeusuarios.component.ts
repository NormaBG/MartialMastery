import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { ObtenerorganizacionService } from 'src/app/servicios/obtenerorganizacion.service';

@Component({
  selector: 'app-registrodeusuarios',
  standalone: true,
  imports: [CommonModule, MatGridListModule,MatFormFieldModule, MatSelectModule, FormsModule, MatInputModule, MatButtonModule],
  templateUrl: './registrodeusuarios.component.html',
  styleUrls: ['./registrodeusuarios.component.css']
})
export class RegistrodeusuariosComponent implements OnInit{
 
  constructor(private Obtenerorganizacion: ObtenerorganizacionService) { }

  datos: any[] = []; 

  ngOnInit(): void {

    this.Obtenerorganizacion.obtenerDatos().subscribe((data: any) => {
      this.datos = Object.values(data);
    });
  }


  opcionOrganizacion: string = '';
  opcionSeleccionada: string = '';

}
