import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCustomerInvoiceComponent } from './edit-customer-invoice.component';

describe('EditCustomerInvoiceComponent', () => {
  let component: EditCustomerInvoiceComponent;
  let fixture: ComponentFixture<EditCustomerInvoiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditCustomerInvoiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCustomerInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
