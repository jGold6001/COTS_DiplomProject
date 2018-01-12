import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxProspectHall2Component } from './mpx-prospect-hall-2.component';

describe('MpxProspectHall2Component', () => {
  let component: MpxProspectHall2Component;
  let fixture: ComponentFixture<MpxProspectHall2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxProspectHall2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxProspectHall2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
