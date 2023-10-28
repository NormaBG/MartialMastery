import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';


@Component({
  selector: 'app-registrodeusuarios',
  standalone: true,
  imports: [CommonModule, MatFormFieldModule],
  templateUrl: './registrodeusuarios.component.html',
  styleUrls: ['./registrodeusuarios.component.css']
})
export class RegistrodeusuariosComponent {

}
