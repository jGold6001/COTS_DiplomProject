import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxProspectHall5Component } from './mpx-prospect-hall-5.component';

describe('MpxProspectHall5Component', () => {
  let component: MpxProspectHall5Component;
  let fixture: ComponentFixture<MpxProspectHall5Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxProspectHall5Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxProspectHall5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
