import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddStoreComponent } from './add-store/add-store.component';
import { DetailsStoreComponent } from './details-store/details-store.component';
import { EditStoreComponent } from './edit-store/edit-store.component';
import { ListStoreComponent } from './list-store/list-store.component';

const routes: Routes = [
  {path:'', redirectTo:'/dashboard/masterdata/store/list',pathMatch:'full'},
  {path:'list', component:ListStoreComponent},
  {path:'add', component:AddStoreComponent},
  {path:'edit/:id', component:EditStoreComponent},
  {path:'details/:id', component:DetailsStoreComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoreRoutingModule { }
