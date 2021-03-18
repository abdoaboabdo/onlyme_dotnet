import { Component, OnInit, AfterViewInit, ViewChild, ChangeDetectorRef, HostListener } from '@angular/core';
import { MdbTableDirective } from 'projects/ng-uikit-pro-standard/src/public_api';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Vendor } from 'src/app/_models/vendor/vendor';
import { QueryModel } from 'src/app/_models/queryModel/queryModel';
import { VendorService } from 'src/app/_services/vendor/vendor.service';

@Component({
  selector: 'app-list-vendor',
  templateUrl: './list-vendor.component.html',
  styleUrls: ['./list-vendor.component.scss']
})
export class ListVendorComponent implements OnInit, AfterViewInit {

  @ViewChild(MdbTableDirective, {static: true}) mdbTable: MdbTableDirective;
  pageResult:IPagedResult<Vendor>={currentPage:1,pageSize:10,pages:1,result:[],totalElements:0,totalPages:0};
  elements: any = [];
  headElements = ['الرقم', 'الأسـم',  'رقم الموبايل', 'تفاصيل العنوان', 'الـتـحـكـم'];
  searchText: string = '';
  previous: string;
  queryModel:QueryModel={CurrentPage:1,PageSize:10,Sort:'Id',SortDirection:'asce' ,SearchTerm:'name:',Logic:'OR'}
  
  constructor(private cdRef: ChangeDetectorRef, private vendorService:VendorService) { 
    this.getVendors();
  }

  @HostListener('input') oninput() {
      this.searchItems();
  }

  // Get All with Pagination
  getVendors(){
    return this.vendorService.getPageResult(this.queryModel).subscribe(
      data=>{
        this.pageResult=data;
          this.elements = data.result;
          this.mdbTable.setDataSource(this.elements);
          this.elements = this.mdbTable.getDataSource();
          this.previous = this.mdbTable.getDataSource();
      }
    );
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.cdRef.detectChanges();
  }

  // Search in Table
  searchItems() {
    this.queryModel.SearchTerm='name:'+this.searchText;
    this.getVendors();
  }

  // on cahnge pages get Vendors
  onPageChange(page:number){
    this.queryModel.CurrentPage=page;
    this.getVendors();
  }
}
