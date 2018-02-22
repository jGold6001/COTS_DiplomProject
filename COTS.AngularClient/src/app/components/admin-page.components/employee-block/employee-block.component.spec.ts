import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeBlockComponent } from './employee-block.component';

describe('EmployeeBlockComponent', () => {
  let component: EmployeeBlockComponent;
  let fixture: ComponentFixture<EmployeeBlockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeBlockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeBlockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
