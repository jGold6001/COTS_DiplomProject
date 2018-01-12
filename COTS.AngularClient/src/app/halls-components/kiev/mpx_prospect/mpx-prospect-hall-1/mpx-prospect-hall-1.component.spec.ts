import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxProspectHall1Component } from './mpx-prospect-hall-1.component';

describe('MpxProspectHall1Component', () => {
  let component: MpxProspectHall1Component;
  let fixture: ComponentFixture<MpxProspectHall1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxProspectHall1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxProspectHall1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
