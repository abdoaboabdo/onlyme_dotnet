import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VarityRoutingModule } from './varity-routing.module';
import { ListVarityComponent } from './list-varity/list-varity.component';
import { AddVarityComponent } from './add-varity/add-varity.component';
import { EditVarityComponent } from './edit-varity/edit-varity.component';
import { DetailsVarityComponent } from './details-varity/details-varity.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MDBBootstrapModulesPro, SelectModule } from 'projects/ng-uikit-pro-standard/src/public_api';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    ListVarityComponent,
    AddVarityComponent,
    EditVarityComponent,
    DetailsVarityComponent,
    
  ],
  imports: [
    CommonModule,
    VarityRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MDBBootstrapModulesPro.forRoot(),
    SharedModule,
    SelectModule
  ]
})
export class VarityModule { }
