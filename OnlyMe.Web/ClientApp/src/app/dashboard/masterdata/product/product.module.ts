import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductRoutingModule } from './product-routing.module';
import { ListProductComponent } from './list-product/list-product.component';
import { AddProductComponent } from './add-product/add-product.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { DetailsProductComponent } from './details-product/details-product.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MDBBootstrapModulesPro } from 'projects/ng-uikit-pro-standard/src/public_api';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    ListProductComponent,
    AddProductComponent,
    EditProductComponent,
    DetailsProductComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MDBBootstrapModulesPro.forRoot(),
    SharedModule
  ]
})
export class ProductModule { }
