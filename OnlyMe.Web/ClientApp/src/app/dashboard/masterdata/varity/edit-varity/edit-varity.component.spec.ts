import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditVarityComponent } from './edit-varity.component';

describe('EditVarityComponent', () => {
  let component: EditVarityComponent;
  let fixture: ComponentFixture<EditVarityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditVarityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditVarityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
