import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListVendorInvoiceComponent } from './list-vendor-invoice.component';

describe('ListVendorInvoiceComponent', () => {
  let component: ListVendorInvoiceComponent;
  let fixture: ComponentFixture<ListVendorInvoiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListVendorInvoiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListVendorInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
