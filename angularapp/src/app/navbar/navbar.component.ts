import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { UsuariossService } from '../servicios/usuarioss.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  //injecto router desde el constructor
  constructor(private router: Router, public UsuariossService: UsuariossService) { }


  onClickLogOut() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
