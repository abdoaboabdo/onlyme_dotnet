import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListVarityComponent } from './list-varity/list-varity.component';
import { AddVarityComponent } from './add-varity/add-varity.component';
import { EditVarityComponent } from './edit-varity/edit-varity.component';
import { DetailsVarityComponent } from './details-varity/details-varity.component';

const routes: Routes = [
  {path:'', component:ListVarityComponent},
  {path:'list', component:ListVarityComponent},
  {path:'add', component: AddVarityComponent},
  {path:'edit/:id', component:EditVarityComponent},
  {path:'details/:id', component:DetailsVarityComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VarityRoutingModule { }
