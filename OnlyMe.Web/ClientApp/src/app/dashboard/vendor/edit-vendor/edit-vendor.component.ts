import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { VendorService } from 'src/app/_services/vendor/vendor.service';

@Component({
  selector: 'app-edit-vendor',
  templateUrl: './edit-vendor.component.html',
  styleUrls: ['./edit-vendor.component.scss']
})
export class EditVendorComponent implements OnInit {
  id:number;
  vendorForm:FormGroup;
  constructor(
    private route:ActivatedRoute,
    private vendorService: VendorService,
    private router:Router,
    private toastService:ToastService,
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params=>{
      this.id=params['id'];
      this.vendorService.getById(this.id).subscribe(data=>{
        this.vendorForm=new FormGroup({
          name: new FormControl(data.data.name,Validators.required),
          email: new FormControl(data.data.email),
          mobileNumber: new FormControl(data.data.mobileNumber,Validators.required),
          phoneNumber: new FormControl(data.data.phoneNumber),
          addressDetails:new FormControl(data.data.addressDetails)
        });
      });
    })
    this.vendorForm=new FormGroup({
      name: new FormControl('',Validators.required),
      email: new FormControl(),
      mobileNumber: new FormControl('',Validators.required),
      phoneNumber: new FormControl(),
      addressDetails:new FormControl()
    });
  }

  editVendor(){
    this.vendorService.updateVendor(this.id,this.vendorForm.value).subscribe(data=>
      {
        console.log(data);
        this.toastService.success('تم إضافة البيانات بنجاح','نجاح')
        this.router.navigate(['/dashboard/vendor'])
      },()=>{
        this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
      }
    );
  }

}
