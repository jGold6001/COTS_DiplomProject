import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxDafiHall2Component } from './mpx-dafi-hall-2.component';

describe('MpxDafiHall2Component', () => {
  let component: MpxDafiHall2Component;
  let fixture: ComponentFixture<MpxDafiHall2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxDafiHall2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxDafiHall2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
