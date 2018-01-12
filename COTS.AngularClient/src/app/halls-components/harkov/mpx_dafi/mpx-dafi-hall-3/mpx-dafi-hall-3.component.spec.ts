import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxDafiHall3Component } from './mpx-dafi-hall-3.component';

describe('MpxDafiHall3Component', () => {
  let component: MpxDafiHall3Component;
  let fixture: ComponentFixture<MpxDafiHall3Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxDafiHall3Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxDafiHall3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
