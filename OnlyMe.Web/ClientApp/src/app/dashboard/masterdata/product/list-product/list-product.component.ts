import { ChangeDetectorRef, Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { MdbTableDirective, ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Product } from 'src/app/_models/product/product';
import { QueryModel } from 'src/app/_models/queryModel/queryModel';
import { ProductService } from 'src/app/_services/product/product.service';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.scss']
})
export class ListProductComponent implements OnInit {

  @ViewChild(MdbTableDirective, {static: true}) mdbTable: MdbTableDirective;
  pageResult:IPagedResult<Product>={currentPage:1,pageSize:10,pages:1,result:[],totalElements:0,totalPages:0};
  elements: any = [];
  headElements = ['ID', 'Name', 'Variety', 'Created At','Action'];
  searchText: string = '';
  previous: string;
  queryModel:QueryModel={CurrentPage:1,PageSize:10,Sort:'Id',SortDirection:'des' ,SearchTerm:'name:,id:',Logic:'OR'}

  constructor(private cdRef: ChangeDetectorRef,private productService:ProductService,private toastService:ToastService) {
    this.getProducts();
   }

  @HostListener('input') oninput() {
    this.searchItems();
  }

  ngOnInit() {
  }

  getProducts(){
    return this.productService.getPagedResult(this.queryModel).subscribe(
      data=>{
          this.pageResult=data;
          this.elements = data.result;
          this.mdbTable.setDataSource(this.elements);
          this.elements = this.mdbTable.getDataSource();
          this.previous = this.mdbTable.getDataSource();
        },()=>{
          this.toastService.error('هناك خطاء بالاتصال','خطأ')
        }
    );
  }

  ngAfterViewInit() {
    this.cdRef.detectChanges();
  }

  searchItems() {
    this.queryModel.SearchTerm='name:'+this.searchText+',id:'+this.searchText;
    this.getProducts();
  }
  onPageChange(page:number){
    this.queryModel.CurrentPage=page;
    this.getProducts();
  }

}
