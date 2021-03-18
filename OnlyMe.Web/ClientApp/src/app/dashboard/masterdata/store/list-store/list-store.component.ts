import { ChangeDetectorRef, Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { MdbTableDirective, ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { QueryModel } from 'src/app/_models/queryModel/queryModel';
import { Store } from 'src/app/_models/store/store';
import { StoreService } from 'src/app/_services/store/store.service';

@Component({
  selector: 'app-list-store',
  templateUrl: './list-store.component.html',
  styleUrls: ['./list-store.component.scss']
})
export class ListStoreComponent implements OnInit {

  @ViewChild(MdbTableDirective, {static: true}) mdbTable: MdbTableDirective;
  pageResult: IPagedResult<Store> = {currentPage: 1 , pageSize: 10 , pages: 1, result : [] , totalElements: 0 , totalPages : 0 };
  elements: any = [];
  headElements = ['ID', 'Name', 'Code', 'Created At', 'Action'];
  searchText = '';
  previous: string;
  queryModel: QueryModel = {CurrentPage: 1 , PageSize : 2 , Sort : 'Id', SortDirection: 'des' , SearchTerm: 'name:,id:,code:,address:' , Logic: 'OR' }

  constructor(private cdRef: ChangeDetectorRef, private StoreService: StoreService, private toastService: ToastService) {
    this.getStores();
   }
  
  @HostListener('input') oninput() {
    this.searchItems();
}

  ngOnInit() {
  }
  ngAfterViewInit() {

    this.cdRef.detectChanges();
  }

  getStores(){
    return this.StoreService.getPagedResult(this.queryModel).subscribe(
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
  searchItems() {
    this.queryModel.SearchTerm = 'name:' + this.searchText + ',id:' + this.searchText + ',code:' + this.searchText +  ',address:' + this.searchText;
    this.getStores();
  }
  onPageChange(page: number) {
    this.queryModel.CurrentPage = page;
    this.getStores();
  }

}
