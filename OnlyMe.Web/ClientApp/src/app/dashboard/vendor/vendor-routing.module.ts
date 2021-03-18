import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddVendorComponent } from './add-vendor/add-vendor.component';
import { ListVendorComponent } from './list-vendor/list-vendor.component';
import { EditVendorComponent } from './edit-vendor/edit-vendor.component';
import { DetailsVendorComponent } from './details-vendor/details-vendor.component';

const routes: Routes = [
  {path:'', redirectTo:'/dashboard/vendor/list'},
  {path:'list', component:ListVendorComponent},
  {path:'add', component:AddVendorComponent},
  {path:'edit/:id', component:EditVendorComponent},
  {path:'details/:id', component:DetailsVendorComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
