import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCustomerInvoiceComponent } from './add-customer-invoice.component';

describe('AddCustomerInvoiceComponent', () => {
  let component: AddCustomerInvoiceComponent;
  let fixture: ComponentFixture<AddCustomerInvoiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCustomerInvoiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCustomerInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
