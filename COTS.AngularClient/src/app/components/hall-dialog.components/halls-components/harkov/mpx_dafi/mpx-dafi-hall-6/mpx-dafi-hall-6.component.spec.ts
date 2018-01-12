import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxDafiHall6Component } from './mpx-dafi-hall-6.component';

describe('MpxDafiHall6Component', () => {
  let component: MpxDafiHall6Component;
  let fixture: ComponentFixture<MpxDafiHall6Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxDafiHall6Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxDafiHall6Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
