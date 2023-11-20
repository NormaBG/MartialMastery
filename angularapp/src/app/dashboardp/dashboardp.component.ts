import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UsuariossService } from 'src/app/servicios/usuarioss.service';

@Component({
  selector: 'app-dashboardp',
  templateUrl: './dashboardp.component.html',
  styleUrls: ['./dashboardp.component.css']
})
export class DashboardpComponent implements OnInit{

  tipoDeUser: number | undefined;

  constructor(private http: HttpClient, private router: Router, private serviciosUser: UsuariossService) { }

  ngOnInit(): void {
    this.tipoDeUser = this.serviciosUser.getTipoDeUser();
    console.log(this.tipoDeUser);
  }


}
