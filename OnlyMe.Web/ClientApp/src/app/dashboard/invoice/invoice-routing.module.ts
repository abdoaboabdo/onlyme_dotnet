import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path:'customer',
    loadChildren: ()=>import(`./customer/customer.module`).then(m=>m.CustomerModule)
  },
  {
    path:'vendor',
    loadChildren: ()=>import(`./vendor/vendor.module`).then(m=>m.VendorModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoiceRoutingModule { }
