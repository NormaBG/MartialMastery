import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private http: HttpClient) { }

  login(username: string, password: string) {
    const body = { username, password };
    return this.http.post('api/usuarios',body);
  }

  onSubmit() {

  }

}
