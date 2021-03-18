import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { VendorService } from 'src/app/_services/vendor/vendor.service';
import { Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';

@Component({
  selector: 'app-add-vendor',
  templateUrl: './add-vendor.component.html',
  styleUrls: ['./add-vendor.component.scss']
})
export class AddVendorComponent implements OnInit {
  vendorForm:FormGroup;
  
  constructor(
    private vendorService: VendorService,
    private router:Router,
    private toastService:ToastService,
  ) { }

  ngOnInit() {
    this.vendorForm=new FormGroup({
      name: new FormControl('',Validators.required),
      email: new FormControl(),
      mobileNumber: new FormControl('',Validators.required),
      phoneNumber: new FormControl(),
      addressDetails:new FormControl()
    });
  }

  addVendor(){
    this.vendorService.addVendor(this.vendorForm.value).subscribe(data=>
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

// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-add-vendor',
//   templateUrl: './add-vendor.component.html',
//   styleUrls: ['./add-vendor.component.scss']
// })
// export class AddVendorComponent implements OnInit {

//   constructor() { }

//   ngOnInit() {
//   }

// }