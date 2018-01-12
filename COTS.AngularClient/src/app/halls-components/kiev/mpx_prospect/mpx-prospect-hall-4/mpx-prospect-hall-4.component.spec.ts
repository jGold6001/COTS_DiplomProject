import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxProspectHall4Component } from './mpx-prospect-hall-4.component';

describe('MpxProspectHall4Component', () => {
  let component: MpxProspectHall4Component;
  let fixture: ComponentFixture<MpxProspectHall4Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxProspectHall4Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxProspectHall4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
