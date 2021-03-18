import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoryRoutingModule } from './category-routing.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MDBBootstrapModulesPro } from 'projects/ng-uikit-pro-standard/src/public_api';
import { AddCategoryComponent } from './add-category/add-category.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';
import { DetailsCategoryComponent } from './details-category/details-category.component';
import { ListCategoryComponent } from './list-category/list-category.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    EditCategoryComponent,
    AddCategoryComponent,
    DetailsCategoryComponent,
    ListCategoryComponent,],
  imports: [
    CommonModule,
    CategoryRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MDBBootstrapModulesPro.forRoot(),
    SharedModule
  ]
})
export class CategoryModule { }
