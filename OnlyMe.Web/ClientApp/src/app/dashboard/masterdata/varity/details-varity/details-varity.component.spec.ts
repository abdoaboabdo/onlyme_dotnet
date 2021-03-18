import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsVarityComponent } from './details-varity.component';

describe('DetailsVarityComponent', () => {
  let component: DetailsVarityComponent;
  let fixture: ComponentFixture<DetailsVarityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailsVarityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsVarityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
