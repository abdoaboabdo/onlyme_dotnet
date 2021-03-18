import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { CustomerService } from 'src/app/_services/customer/customer.service';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.scss']
})
export class EditCustomerComponent implements OnInit {
  id:number;
  customerForm:FormGroup;
  constructor(
    private route:ActivatedRoute,
    private customerService: CustomerService,
    private router:Router,
    private toastService:ToastService,
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params=>{
      this.id=params['id'];
      this.customerService.getById(this.id).subscribe(data=>{
        this.customerForm=new FormGroup({
          name: new FormControl(data.data.name,Validators.required),
          mobileNumber: new FormControl(data.data.mobileNumber,Validators.required),
          addressDetails:new FormControl(data.data.addressDetails)
        });
      });
    })
    this.customerForm=new FormGroup({
      name: new FormControl('',Validators.required),
      mobileNumber: new FormControl('',Validators.required),
      addressDetails:new FormControl()
    });
  }

  editCustomer(){
    this.customerService.updateCustomer(this.id,this.customerForm.value).subscribe(data=>
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
