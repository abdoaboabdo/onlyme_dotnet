import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsCustomerInvoiceComponent } from './details-customer-invoice.component';

describe('DetailsCustomerInvoiceComponent', () => {
  let component: DetailsCustomerInvoiceComponent;
  let fixture: ComponentFixture<DetailsCustomerInvoiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailsCustomerInvoiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsCustomerInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
