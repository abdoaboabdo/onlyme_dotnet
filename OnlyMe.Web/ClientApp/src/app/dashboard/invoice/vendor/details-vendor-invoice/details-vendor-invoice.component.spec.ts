import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsVendorInvoiceComponent } from './details-vendor-invoice.component';

describe('DetailsVendorInvoiceComponent', () => {
  let component: DetailsVendorInvoiceComponent;
  let fixture: ComponentFixture<DetailsVendorInvoiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailsVendorInvoiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsVendorInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
