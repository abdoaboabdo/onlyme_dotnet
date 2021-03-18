import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { CustomerService } from 'src/app/_services/customer/customer.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.scss']
})
export class AddCustomerComponent implements OnInit {
  CustomerForm:FormGroup;
  constructor(
    private customerService: CustomerService,
    private router:Router,
    private toastService:ToastService,
  ) { }

  ngOnInit() {
    
    this.CustomerForm=new FormGroup({
      name: new FormControl('',Validators.required),
      mobileNumber: new FormControl('',Validators.required),
      addressDetails:new FormControl()
    });
  }

  addCustomer(){
    this.customerService.addCustomer(this.CustomerForm.value).subscribe(data=>
      {
        console.log(data);
        this.toastService.success('تم إضافة البيانات بنجاح','نجاح')
        this.router.navigate(['/dashboard/customer'])
      },()=>{
        this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
      }
    );
  }

}
