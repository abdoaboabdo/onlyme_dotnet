import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListProductComponent } from './list-product/list-product.component';
import { AddProductComponent } from './add-product/add-product.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { DetailsProductComponent } from './details-product/details-product.component';

const routes: Routes = [
  {path:'', component: ListProductComponent},
  {path:'list', component: ListProductComponent},
  {path:'add', component: AddProductComponent},
  {path:'edit/:id', component: EditProductComponent},
  {path:'details/:id', component: DetailsProductComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
