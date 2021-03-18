import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { CategoryService } from 'src/app/_services/category/category.service';
import { VarietyService } from 'src/app/_services/varity/varity.service';

@Component({
  selector: 'app-edit-varity',
  templateUrl: './edit-varity.component.html',
  styleUrls: ['./edit-varity.component.scss']
})
export class EditVarityComponent implements OnInit {
  id:number;
  VarietyForm:FormGroup;
  options:{ value: string, label: string }[]=[]
  constructor(
    private route:ActivatedRoute,
    private varietyService:VarietyService,
    private toastService:ToastService,
    private router:Router,
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
    
    this.route.params.subscribe(params=>{

      this.id=params['id'];

      this.varietyService.getById(this.id).subscribe(data=>{
        console.log(data.data)
        this.VarietyForm=new FormGroup({
          name: new FormControl(data.data.name,Validators.required),
          categoryId: new FormControl(data.data.categoryId,Validators.required)
        });

      });

    });
    this.VarietyForm=new FormGroup({
      name: new FormControl('',Validators.required),
      categoryId: new FormControl('',Validators.required)
    });
  }

  editVariety(){
    this.varietyService.updateVariety(this.id,this.VarietyForm.value).subscribe(data=>{
      console.log(data);
      this.toastService.success('تم تعديل البيانات بنجاح','نجاح')
      this.router.navigate(['/dashboard/masterdata/varity'])
    },()=>{
      this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
    })
  }

}
