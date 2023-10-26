import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RouterModule, Routes } from '@angular/router';
//import { AppComponent } from './app.component';
import { DashboardpComponent } from './dashboardp/dashboardp.component';
import { loginGuard } from './guards/loginGuard';

const ROUTES: Routes = [
  //rutas xd
  //{ path: '', component: AppComponent}, //principal
  //{ path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent }, //login
  { path: 'dashboard', component: DashboardpComponent, canActivate: [loginGuard]}
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
