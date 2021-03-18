import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListVarityComponent } from './list-varity.component';

describe('ListVarityComponent', () => {
  let component: ListVarityComponent;
  let fixture: ComponentFixture<ListVarityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListVarityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListVarityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
