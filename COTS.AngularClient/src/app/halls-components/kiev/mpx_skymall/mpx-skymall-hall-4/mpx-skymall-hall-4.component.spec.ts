import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxSkymallHall4Component } from './mpx-skymall-hall-4.component';

describe('MpxSkymallHall4Component', () => {
  let component: MpxSkymallHall4Component;
  let fixture: ComponentFixture<MpxSkymallHall4Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxSkymallHall4Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxSkymallHall4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
