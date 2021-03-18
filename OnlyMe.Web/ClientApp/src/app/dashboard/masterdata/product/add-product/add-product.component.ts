import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { ProductService } from 'src/app/_services/product/product.service';
import { VarietyService } from 'src/app/_services/varity/varity.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {
  productForm:FormGroup;
  options:{ value: string, label: string }[]=[]
  constructor(
    private productService:ProductService,
    private router:Router,
    private toastService:ToastService,
    private varietyService:VarietyService
  ) { 
    this.varietyService.getAll().subscribe(data=>{
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
    this.productForm=new FormGroup({
      name: new FormControl('',Validators.required),
      description: new FormControl('',Validators.required),
      varietyId: new FormControl('',Validators.required)
    });
  }

  addProduct(){
    this.productService.addProduct(this.productForm.value).subscribe(data=>
      {
        console.log(data);
        this.toastService.success('تم إضافة البيانات بنجاح','نجاح')
        this.router.navigate(['/dashboard/masterdata/product'])
      },()=>{
        this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
      }
    );
  }

}
