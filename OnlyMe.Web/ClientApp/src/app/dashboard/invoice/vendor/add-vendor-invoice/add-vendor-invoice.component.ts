import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IMyOptions, ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';
import {forkJoin} from 'rxjs'
import { Category } from 'src/app/_models/category/category';
import { Store } from 'src/app/_models/store/store';
import { Vendor } from 'src/app/_models/vendor/vendor';
import { CategoryService } from 'src/app/_services/category/category.service';
import { StoreService } from 'src/app/_services/store/store.service';
import { VendorService } from 'src/app/_services/vendor/vendor.service';
import {IOption} from 'ng-uikit-pro-standard';
import {VarietyService} from '../../../../_services/varity/varity.service';
import { Variety } from 'src/app/_models/variety/variety';
import { Product } from 'src/app/_models/product/product';
import { ProductService } from 'src/app/_services/product/product.service';

@Component({
  selector: 'app-add-vendor-invoice',
  templateUrl: './add-vendor-invoice.component.html',
  styleUrls: ['./add-vendor-invoice.component.scss']
})
export class AddVendorInvoiceComponent implements OnInit {
  invoiceVendorForm: FormGroup
  vendors: Vendor[]
  stores: Store[]
  categories: Category[]
  varieties:Variety[]
  products:Product[]
  vendorOptions: IOption[] = []
  StoreOptions: IOption[] = []
  CategoryOptions: IOption[] = []
  varietyOptions: IOption[] = []
  productOptions: IOption[] = []
  myDatePickerOptions: IMyOptions = {
    
    dateFormat: 'mm/dd/yyyy'
  };
  constructor(
    private vendorService: VendorService,
    private storeService: StoreService,
    private categoryService: CategoryService,
    // private router: Router,
    private toastService: ToastService,
    private varietyService: VarietyService,
    private ProductService: ProductService
    ) { }

  ngOnInit() {

    const sources: object[] = [
      this.vendorService.getAll(),
      this.storeService.getAll(),
      this.categoryService.getAll()
    ];

    forkJoin(sources)
      .subscribe(data => {
        this.vendors = data[0];
        this.stores = data[1];
        this.categories = data[2]
        let myOptions: IOption[] = []
        for (let index = 0; index < this.vendors.length; index++) {
          myOptions.push({label: this.vendors[index].name, value: this.vendors[index].id.toString(), icon : ''})
        }
        this.vendorOptions = myOptions
        myOptions = []
        for (let index = 0; index < this.stores.length; index++) {
          myOptions.push({label: this.stores[index].name, value: this.stores[index].id.toString(), icon : ''})
        }
        this.StoreOptions = myOptions
        myOptions = []
        for (let index = 0; index < this.categories.length; index++) {
          myOptions.push({label: this.categories[index].name, value: this.categories[index].id.toString(), icon : ''})
        }
        this.CategoryOptions = myOptions
        console.log(this.vendorOptions);
        console.log(this.vendorOptions);
        console.log(this.CategoryOptions);
      }, () => {
        this.toastService.error('هناك خطاء ما من فضلك اعد المحاولة', 'خطأ')
      });

    this.invoiceVendorForm = new FormGroup({
      code: new FormControl('', Validators.required),
      vendorId: new FormControl('', Validators.required),
      storeId: new FormControl('', Validators.required),
      categoryId: new FormControl('', Validators.required),
      varietyId: new FormControl('', Validators.required),
      productId: new FormControl('', Validators.required),
      dateTime: new FormControl('', Validators.required)
    });
    // @ts-ignore
    this.invoiceVendorForm.get('varietyId').valueChanges.subscribe( value => {
      if(value!=null)
      {
        this.ProductService.getAll({varietyId:value}).subscribe(data=>{
          this.products=data;
          let myOptions: IOption[] = []
          for (let index = 0; index < this.products.length; index++) {
            myOptions.push({label: this.products[index].name, value: this.products[index].id.toString(), icon : ''})
          }
          this.productOptions=myOptions
        });
      }
    })
    // @ts-ignore
    this.invoiceVendorForm.get('categoryId').valueChanges.subscribe( value => {
      if(value!=null)
      {
        this.varietyService.getAll({categoryId:value}).subscribe(data=>{
          this.varieties=data;
          let myOptions: IOption[] = []
          for (let index = 0; index < this.varieties.length; index++) {
            myOptions.push({label: this.varieties[index].name, value: this.varieties[index].id.toString(), icon : ''})
          }
          this.varietyOptions=myOptions
        });
      }
    })

  }

  addInvoiceVendor() {

  }





}
