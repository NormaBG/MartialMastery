import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public tipouser?: tipousu[];
  public usuarios?: Usuarios[];

  constructor(http: HttpClient) {
    http.get<tipousu[]>('https://localhost:7041/api/Tiposusers').subscribe(result => {
      this.tipouser = result;
    }, error => console.error(error));

    http.get<Usuarios[]>('https://localhost:7041/api/Usuarios').subscribe(result => {
      this.usuarios = result;
    }, error => console.error(error));

  }

  title = 'angularapp';
}

/*interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
*/

interface tipousu {
  idTp: number
  tipoDeUser: string
}

interface Usuarios {
  idUser: number
  usuario1: string
  contrasena: string
  tipoDeUser: number
}
