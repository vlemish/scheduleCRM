import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../app/login-component/login-component';
import { MainComponent } from '../app/main-component/main-component.component';
import { AuthGuard } from './auth/auth.guard';
import { ForbiddenComponent } from './forbidden/forbidden.component';

const routes: Routes = 
[
  {path: '', redirectTo:'/login', pathMatch:'full'},
  {path: 'login', component: LoginComponent},
  {path: 'main', component: MainComponent, canActivate:[AuthGuard], data: {permittedRoles: ['Admin']}}, //, canActivate:[AuthGuard], data: {permittedRoles: ['Admin', 'Guest']}
  {path:'forbidden', component:ForbiddenComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
