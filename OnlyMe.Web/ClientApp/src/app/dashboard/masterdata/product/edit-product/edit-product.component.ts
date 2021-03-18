import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { ProductService } from 'src/app/_services/product/product.service';
import { VarietyService } from 'src/app/_services/varity/varity.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit {
  id:number;
  productForm:FormGroup;
  options:{ value: string, label: string }[]=[]
  
  constructor(
    private route:ActivatedRoute,
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
    this.route.params.subscribe(params=>{
      this.id=params['id'];
      this.productService.getById(this.id).subscribe(data=>{
        console.log(data.data)
        this.productForm=new FormGroup({
          name: new FormControl(data.data.name,Validators.required),
          description: new FormControl(data.data.description,Validators.required),
          varietyId: new FormControl(data.data.varietyId,Validators.required)
        });

      });
    })
    this.productForm=new FormGroup({
      name: new FormControl('',Validators.required),
      description: new FormControl('',Validators.required),
      varietyId: new FormControl('',Validators.required)
    });
  }

  editProduct(){
    this.productService.updateProduct(this.id,this.productForm.value).subscribe(data=>{
      console.log(data);
      this.toastService.success('تم تعديل البيانات بنجاح','نجاح')
      this.router.navigate(['/dashboard/masterdata/product'])
    },()=>{
      this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
    })
  }



}
