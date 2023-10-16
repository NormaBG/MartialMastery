import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';


const ROUTES: Routes = [
  //rutas xd
  //{ path: '', component: AppComponent}, //principal
  { path: 'login', component: LoginComponent }, //login
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(ROUTES),
    CommonModule
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
