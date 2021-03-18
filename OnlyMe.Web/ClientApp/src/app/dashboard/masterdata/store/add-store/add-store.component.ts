import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { StoreService } from 'src/app/_services/store/store.service';

@Component({
  selector: 'app-add-store',
  templateUrl: './add-store.component.html',
  styleUrls: ['./add-store.component.scss']
})
export class AddStoreComponent implements OnInit {
  storeForm:FormGroup;
  constructor(
    private storeService:StoreService,
    private router:Router,
    private toastService:ToastService
  ) { }

  ngOnInit() {
    this.storeForm=new FormGroup({
      name: new FormControl('',Validators.required),
      code: new FormControl('',Validators.required),
      address: new FormControl('',Validators.required)
    });
  }

  addStore(){
    this.storeService.addStore(this.storeForm.value).subscribe(data=>
      {
        console.log(data);
        this.toastService.success('تم تعديل البيانات بنجاح','نجاح')
        this.router.navigate(['/dashboard/masterdata/store'])
      },()=>{
        this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة','خطأ')
      }
    );
  }
}
