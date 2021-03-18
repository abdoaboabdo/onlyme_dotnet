import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditVendorInvoiceComponent } from './edit-vendor-invoice.component';

describe('EditVendorInvoiceComponent', () => {
  let component: EditVendorInvoiceComponent;
  let fixture: ComponentFixture<EditVendorInvoiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditVendorInvoiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditVendorInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
