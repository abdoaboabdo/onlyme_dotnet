import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { DetailsCustomerInvoiceComponent } from './details-customer-invoice/details-customer-invoice.component';
import { EditCustomerInvoiceComponent } from './edit-customer-invoice/edit-customer-invoice.component';
import { ListCustomerInvoiceComponent } from './list-customer-invoice/list-customer-invoice.component';
import { AddCustomerInvoiceComponent } from './add-customer-invoice/add-customer-invoice.component';

@NgModule({
  declarations: [
    AddCustomerInvoiceComponent,
    ListCustomerInvoiceComponent, 
    EditCustomerInvoiceComponent, 
    DetailsCustomerInvoiceComponent,
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule
  ]
})
export class CustomerModule { }
