import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { CategoryService } from 'src/app/_services/category/category.service';
import {VarietyService } from './../../../../_services/varity/varity.service';


@Component({
  selector: 'app-add-varity',
  templateUrl: './add-varity.component.html',
  styleUrls: ['./add-varity.component.scss']
})
export class AddVarityComponent implements OnInit {

  VarietyForm:FormGroup;
  options:{ value: string, label: string }[]=[]
  constructor(
    private VarietyService:VarietyService,
    private router:Router,
    private toastService:ToastService,
    private categoryService:CategoryService
  ) {
    this.categoryService.getAll().subscribe(data=>{
      let myOPtions:{ value: string, label: string }[]=[]
      for (let index = 0; index < data.length; index++) {
        myOPtions.push({label:data[index].name,value:data[index].id.toString()})
      }
      this.options=myOPtions
    },()=>{
      this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
    });
  }

  ngOnInit() {
    this.VarietyForm=new FormGroup({
      name: new FormControl('',Validators.required),
      categoryId: new FormControl('',Validators.required)
    });
    
  }

  addVariety(){
    this.VarietyService.addVariety(this.VarietyForm.value).subscribe(data=>
      {
        console.log(data);
        this.toastService.success('تم إضافة البيانات بنجاح','نجاح')
        this.router.navigate(['/dashboard/masterdata/varity'])
      },()=>{
        this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
      }
    );
  }

}
