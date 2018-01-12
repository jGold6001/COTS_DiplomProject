import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxDafiHall4Component } from './mpx-dafi-hall-4.component';

describe('MpxDafiHall4Component', () => {
  let component: MpxDafiHall4Component;
  let fixture: ComponentFixture<MpxDafiHall4Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxDafiHall4Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxDafiHall4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
