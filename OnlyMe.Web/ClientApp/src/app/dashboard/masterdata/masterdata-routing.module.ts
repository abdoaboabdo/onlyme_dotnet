import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  // Category Pathes
  {path:'category', loadChildren:()=>import(`./category/category.module`).then(m=>m.CategoryModule)},
  
  // Varity Pathes
  {path:'varity', loadChildren:()=>import(`./varity/varity.module`).then(m=>m.VarityModule)},
  // Product Pathes
  {path:'product', loadChildren:()=>import(`./product/product.module`).then(m=>m.ProductModule)},
  {path:'store', loadChildren:()=>import(`./store/store.module`).then(m=>m.StoreModule)},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MasterdataRoutingModule { }
