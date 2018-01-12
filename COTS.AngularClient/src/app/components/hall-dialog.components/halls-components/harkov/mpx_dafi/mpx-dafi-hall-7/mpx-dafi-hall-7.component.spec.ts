import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxDafiHall7Component } from './mpx-dafi-hall-7.component';

describe('MpxDafiHall7Component', () => {
  let component: MpxDafiHall7Component;
  let fixture: ComponentFixture<MpxDafiHall7Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxDafiHall7Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxDafiHall7Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
