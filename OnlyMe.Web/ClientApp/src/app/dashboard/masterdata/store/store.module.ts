import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoreRoutingModule } from './store-routing.module';
import { AddStoreComponent } from './add-store/add-store.component';
import { ListStoreComponent } from './list-store/list-store.component';
import { EditStoreComponent } from './edit-store/edit-store.component';
import { DetailsStoreComponent } from './details-store/details-store.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MDBBootstrapModulesPro } from 'projects/ng-uikit-pro-standard/src/public_api';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [AddStoreComponent, ListStoreComponent, EditStoreComponent, DetailsStoreComponent],
  imports: [
    CommonModule,
    StoreRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MDBBootstrapModulesPro.forRoot(),
    SharedModule
  ]
})
export class StoreModule { }
