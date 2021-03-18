import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/_models/category/category';
import { CategoryService } from 'src/app/_services/category/category.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.scss']
})
export class EditCategoryComponent implements OnInit {
  id:number;
  category:Category
  categoryForm:FormGroup;
  constructor(
    private route:ActivatedRoute,
    private categoryService:CategoryService,
    private router:Router,
    private toastService:ToastService) { }

  ngOnInit() {
    this.route.params.subscribe(params=>{
      this.id=params['id']
      this.categoryService.getById(this.id).subscribe(data=>{
        this.category=data.data
        this.categoryForm=new FormGroup({
          name: new FormControl(this.category.name,Validators.required)
        });
      })
    })
    this.categoryForm=new FormGroup({
      name: new FormControl('',Validators.required)
    });
  }

  editCategory(){
    this.categoryService.updateCategory(this.id,this.categoryForm.value).subscribe(data=>
      {
        console.log(data);
        this.toastService.success('تم تعديل البيانات بنجاح','نجاح')
        this.router.navigate(['/dashboard/masterdata/category'])
      },()=>{
        this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
      }
    );
  }

}
