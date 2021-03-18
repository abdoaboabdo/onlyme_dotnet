import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddCustomerInvoiceComponent } from './add-customer-invoice/add-customer-invoice.component';
import { DetailsCustomerInvoiceComponent } from './details-customer-invoice/details-customer-invoice.component';
import { EditCustomerInvoiceComponent } from './edit-customer-invoice/edit-customer-invoice.component';
import { ListCustomerInvoiceComponent } from './list-customer-invoice/list-customer-invoice.component';

const routes: Routes = [
  {path:'', redirectTo:'/dashboard/invoice/customer/list', pathMatch: 'full' },
  {path:'list', component:ListCustomerInvoiceComponent},
  {path:'add', component:AddCustomerInvoiceComponent},
  {path:'edit/:id', component:EditCustomerInvoiceComponent},
  {path:'details/:id', component:DetailsCustomerInvoiceComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
