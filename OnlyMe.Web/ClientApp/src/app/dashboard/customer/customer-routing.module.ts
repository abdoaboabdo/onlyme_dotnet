import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { ListCustomerComponent } from './list-customer/list-customer.component';
import { EditCustomerComponent } from './edit-customer/edit-customer.component';
import { DetailsCustomerComponent } from './details-customer/details-customer.component';

const routes: Routes = [
  {path:'list', component:ListCustomerComponent},
  {path:'add', component:AddCustomerComponent},
  {path:'edit/:id', component:EditCustomerComponent},
  {path:'details/:id', component:DetailsCustomerComponent},
  {path:'',redirectTo:'/dashboard/customer/list', pathMatch: 'full'}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
