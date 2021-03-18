import { Component, OnInit, AfterViewInit, ViewChild, ChangeDetectorRef, HostListener } from '@angular/core';
import { MdbTableDirective } from 'projects/ng-uikit-pro-standard/src/public_api';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Customer } from 'src/app/_models/customer/customer';
import { QueryModel } from 'src/app/_models/queryModel/queryModel';
import { CustomerService } from 'src/app/_services/customer/customer.service';

@Component({
  selector: 'app-list-customer',
  templateUrl: './list-customer.component.html',
  styleUrls: ['./list-customer.component.scss']
})
export class ListCustomerComponent implements OnInit, AfterViewInit {

  @ViewChild(MdbTableDirective, {static: true}) mdbTable: MdbTableDirective;
  pageResult:IPagedResult<Customer>={currentPage:1,pageSize:10,pages:1,result:[],totalElements:0,totalPages:0};
  elements: any = [];
  headElements = ['الرقم', 'الأسـم', 'رقم الموبايل',  'تفاصيل العنوان', 'الـتـحـكـم'];
  searchText: string = '';
  previous: string;
  queryModel:QueryModel={CurrentPage:1,PageSize:10,Sort:'Id',SortDirection:'asce' ,SearchTerm:'name:',Logic:'OR'}
  
  constructor(private cdRef: ChangeDetectorRef, private customerService:CustomerService) { 
    this.getCustomers();
  }

  @HostListener('input') oninput() {
      this.searchItems();
  }

  // Get All with Pagination
  getCustomers(){
    return this.customerService.getPageResult(this.queryModel).subscribe(
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
    this.getCustomers();
  }

  // on cahnge pages get Customers
  onPageChange(page:number){
    this.queryModel.CurrentPage=page;
    this.getCustomers();
  }

}
