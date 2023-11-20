import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboardp',
  templateUrl: './dashboardp.component.html',
  styleUrls: ['./dashboardp.component.css']
})
export class DashboardpComponent {
  torneos: any[] = [];

  constructor(private http: HttpClient, private router: Router) { }
}
