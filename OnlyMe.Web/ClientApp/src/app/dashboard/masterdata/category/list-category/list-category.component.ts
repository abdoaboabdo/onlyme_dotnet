import { Component, ViewChild, HostListener, OnInit, ChangeDetectorRef, AfterViewInit } from '@angular/core';
import {  MdbTableDirective, ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { CategoryService } from 'src/app/_services/category/category.service';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Category } from 'src/app/_models/category/category';
import { QueryModel } from 'src/app/_models/queryModel/queryModel';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.scss']
})
export class ListCategoryComponent  implements OnInit, AfterViewInit  {

  @ViewChild(MdbTableDirective, {static: true}) mdbTable: MdbTableDirective;
  pageResult: IPagedResult<Category> = {currentPage: 1 , pageSize: 10 , pages: 1, result : [] , totalElements: 0 , totalPages : 0 };
  elements: any = [];
  headElements = ['ID', 'Name', 'Created At', 'Action'];
  searchText = '';
  previous: string;
  queryModel: QueryModel = {CurrentPage: 1 , PageSize : 2 , Sort : 'Id', SortDirection: 'des' , SearchTerm: 'name:,id:' , Logic: 'OR' }

  constructor(private cdRef: ChangeDetectorRef, private categoryService: CategoryService, private toastService: ToastService) {
    this.getCategories();
  }

  @HostListener('input') oninput() {
      this.searchItems();
  }

  getCategories() {
    return this.categoryService.getPagedResult(this.queryModel).subscribe(
      data => {
          this.pageResult = data;
          this.elements = data.result;
          this.mdbTable.setDataSource(this.elements);
          this.elements = this.mdbTable.getDataSource();
          this.previous = this.mdbTable.getDataSource();
        }, () => {
          this.toastService.error('هناك خطاء بالاتصال', 'خطأ')
        }
    );
  }

  ngOnInit() {

  }
  ngAfterViewInit() {

    this.cdRef.detectChanges();
  }

  searchItems() {
    this.queryModel.SearchTerm = 'name:' + this.searchText + ',id:' + this.searchText;
    this.getCategories();
  }
  onPageChange(page: number) {
    this.queryModel.CurrentPage = page;
    this.getCategories();
  }

}
