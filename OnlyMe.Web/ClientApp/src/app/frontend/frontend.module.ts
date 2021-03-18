import { MDBBootstrapModulesPro } from './../../../projects/ng-uikit-pro-standard/src/lib/mdb.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FrontendRoutingModule } from './frontend-routing.module';
import { LoginComponent } from './login/login.component';
import { FullDefaultComponent } from '../layouts/default/full-default/full-default.component';
import { HomeComponent } from './home/home.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [LoginComponent,FullDefaultComponent, HomeComponent],
  imports: [
    CommonModule,
    FrontendRoutingModule,
    ReactiveFormsModule,
    MDBBootstrapModulesPro.forRoot(),
  ]
})
export class FrontendModule { }
