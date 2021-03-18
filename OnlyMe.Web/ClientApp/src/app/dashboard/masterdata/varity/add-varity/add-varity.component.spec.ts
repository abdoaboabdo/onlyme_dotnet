import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVarityComponent } from './add-varity.component';

describe('AddVarityComponent', () => {
  let component: AddVarityComponent;
  let fixture: ComponentFixture<AddVarityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddVarityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddVarityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
