import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FullDefaultComponent } from './full-default.component';

describe('FullDefaultComponent', () => {
  let component: FullDefaultComponent;
  let fixture: ComponentFixture<FullDefaultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FullDefaultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FullDefaultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
