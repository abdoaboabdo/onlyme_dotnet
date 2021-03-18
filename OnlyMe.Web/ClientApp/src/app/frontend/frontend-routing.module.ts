import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FullDefaultComponent } from '../layouts/default/full-default/full-default.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { BeforeLoginService } from '../_services/authentication/before-login.service';

const routes: Routes = [
  {path:'',component:FullDefaultComponent,children:[
    {path:'login',component:LoginComponent},
    {path:'',component:HomeComponent,canActivate:[BeforeLoginService]},
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FrontendRoutingModule { }
