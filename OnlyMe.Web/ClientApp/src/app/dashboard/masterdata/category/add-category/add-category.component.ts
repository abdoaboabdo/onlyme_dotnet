import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryService } from 'src/app/_services/category/category.service';
import { Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.scss']
})
export class AddCategoryComponent implements OnInit {
  categoryForm:FormGroup;
  constructor(
    private categoryService:CategoryService,
    private router:Router,
    private toastService:ToastService
  ) { }

  ngOnInit() {
    this.categoryForm=new FormGroup({
      name: new FormControl('',Validators.required)
    });
  }

  addCategory(){
    this.categoryService.addCategory(this.categoryForm.value).subscribe(data=>
      {
        console.log(data);
        this.toastService.success('تم إضافة البيانات بنجاح','نجاح')
        this.router.navigate(['/dashboard/masterdata/category'])
      },()=>{
        this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
      }
    );
  }

}
