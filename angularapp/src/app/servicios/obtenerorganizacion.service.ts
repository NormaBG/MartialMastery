import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ObtenerorganizacionService {

  private apiUrl = 'https://localhost:7041/api/Organizaciones';
  constructor(private http: HttpClient) { }

  obtenerDatos() {
    return this.http.get(this.apiUrl);
  }
}
