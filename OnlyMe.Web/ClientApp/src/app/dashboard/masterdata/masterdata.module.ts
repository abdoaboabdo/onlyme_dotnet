import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { MasterdataRoutingModule } from './masterdata-routing.module';

import { MDBBootstrapModulesPro } from 'projects/ng-uikit-pro-standard/src/public_api';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule,
    MasterdataRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MDBBootstrapModulesPro.forRoot(),
  ]
})
export class MasterdataModule { }
