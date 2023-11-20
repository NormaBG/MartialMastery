import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UsuariossService} from 'src/app/servicios/usuarioss.service';


@Component({
  selector: 'app-torneoslistado',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './torneoslistado.component.html',
  styleUrls: ['./torneoslistado.component.css']
})
export class TorneoslistadoComponent implements OnInit {

  torneos: any[] = [];
  tipoDeUser: number = 0;

  constructor(private http: HttpClient, private router: Router, private serviciouser: UsuariossService) { }

  ngOnInit(): void {
    this.obtenerTorneos();
    this.tipoDeUser = this.serviciouser.getTipoDeUser();
  }

  obtenerTorneos() {
    const apiUrl = 'https://localhost:7041/api/Torneos';

    this.http.get<any>(apiUrl).subscribe(
      response => {
        if (response && response.$values) {
          this.torneos = response.$values;
        } else {
          console.error('La respuesta de la API no tiene la estructura esperada:', response);
        }
      },
      error => {
        console.error('Error al obtener datos de la API:', error);
      }
    );
  }



}
