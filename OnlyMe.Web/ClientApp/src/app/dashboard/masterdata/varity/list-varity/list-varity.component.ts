import { Component, OnInit, ViewChild, ChangeDetectorRef, HostListener, AfterViewInit } from '@angular/core';
import { MdbTableDirective, ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { IPagedResult } from 'src/app/_models/PagedResult/iPagedResult';
import { Variety } from 'src/app/_models/variety/variety';
import { VarietyService } from 'src/app/_services/varity/varity.service';
import { QueryModel } from 'src/app/_models/queryModel/queryModel';

@Component({
  selector: 'app-list-varity',
  templateUrl: './list-varity.component.html',
  styleUrls: ['./list-varity.component.scss']
})
export class ListVarityComponent implements OnInit,AfterViewInit {

  @ViewChild(MdbTableDirective, {static: true}) mdbTable: MdbTableDirective;
  pageResult:IPagedResult<Variety>={currentPage:1,pageSize:10,pages:1,result:[],totalElements:0,totalPages:0};
  elements: any = [];
  headElements = ['ID', 'Name', 'Category', 'Created At','Action'];
  searchText: string = '';
  previous: string;
  queryModel:QueryModel={CurrentPage:1,PageSize:10,Sort:'Id',SortDirection:'des' ,SearchTerm:'name:,id:',Logic:'OR'}

  constructor(private cdRef: ChangeDetectorRef,private varietyService:VarietyService,private toastService:ToastService) {
    this.getVarities();
  }

  @HostListener('input') oninput() {
      this.searchItems();
  }
  
  getVarities(){
    return this.varietyService.getPagedResult(this.queryModel).subscribe(
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

  ngOnInit() {
    
  }
  ngAfterViewInit() {

    this.cdRef.detectChanges();
  }

  searchItems() {
    this.queryModel.SearchTerm='name:'+this.searchText+',id:'+this.searchText;
    this.getVarities();
  }
  onPageChange(page:number){
    this.queryModel.CurrentPage=page;
    this.getVarities();
  }

}
