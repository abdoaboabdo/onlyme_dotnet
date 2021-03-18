import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import { Store } from 'src/app/_models/store/store';
import { StoreService } from 'src/app/_services/store/store.service';

@Component({
  selector: 'app-edit-store',
  templateUrl: './edit-store.component.html',
  styleUrls: ['./edit-store.component.scss']
})
export class EditStoreComponent implements OnInit {

  id:number;
  store:Store
  storeForm:FormGroup;
  constructor(
    private route:ActivatedRoute,
    private storeService:StoreService,
    private router:Router,
    private toastService:ToastService
    ) { }

  ngOnInit() {
    this.route.params.subscribe(params=>{
      this.id=params['id']
      this.storeService.getById(this.id).subscribe(data=>{
        this.store=data.data
        this.storeForm=new FormGroup({
          name: new FormControl(this.store.name,Validators.required),
          code: new FormControl(this.store.code,Validators.required),
          address: new FormControl(this.store.address,Validators.required)
        });
      })
    })
    this.storeForm=new FormGroup({
      name: new FormControl('',Validators.required),
      code: new FormControl('',Validators.required),
      address: new FormControl('',Validators.required)
    });
  }

  editStore(){
    this.storeService.updateStore(this.id,this.storeForm.value).subscribe(data=>
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
