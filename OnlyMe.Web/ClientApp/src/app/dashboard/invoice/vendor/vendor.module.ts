import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { ListVendorInvoiceComponent } from './list-vendor-invoice/list-vendor-invoice.component';
import { EditVendorInvoiceComponent } from './edit-vendor-invoice/edit-vendor-invoice.component';
import { AddVendorInvoiceComponent } from './add-vendor-invoice/add-vendor-invoice.component';
import { DetailsVendorInvoiceComponent } from './details-vendor-invoice/details-vendor-invoice.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MDBBootstrapModulesPro } from 'projects/ng-uikit-pro-standard/src/public_api';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    DetailsVendorInvoiceComponent, 
    AddVendorInvoiceComponent, 
    EditVendorInvoiceComponent, 
    ListVendorInvoiceComponent
  ],
  imports: [
    CommonModule,
    VendorRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MDBBootstrapModulesPro.forRoot(),
    SharedModule
  ]
})
export class VendorModule { }
