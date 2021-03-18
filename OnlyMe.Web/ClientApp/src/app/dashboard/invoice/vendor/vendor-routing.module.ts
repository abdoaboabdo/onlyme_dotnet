import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddVendorInvoiceComponent } from './add-vendor-invoice/add-vendor-invoice.component';
import { DetailsVendorInvoiceComponent } from './details-vendor-invoice/details-vendor-invoice.component';
import { EditVendorInvoiceComponent } from './edit-vendor-invoice/edit-vendor-invoice.component';
import { ListVendorInvoiceComponent } from './list-vendor-invoice/list-vendor-invoice.component';

const routes: Routes = [
  {path:'', redirectTo:'/dashboard/invoice/vendor/list', pathMatch: 'full' },
  {path:'list', component:ListVendorInvoiceComponent},
  {path:'add', component:AddVendorInvoiceComponent},
  {path:'edit/:id', component:EditVendorInvoiceComponent},
  {path:'details/:id', component:DetailsVendorInvoiceComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
