import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxSkymallHall3Component } from './mpx-skymall-hall-3.component';

describe('MpxSkymallHall3Component', () => {
  let component: MpxSkymallHall3Component;
  let fixture: ComponentFixture<MpxSkymallHall3Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxSkymallHall3Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxSkymallHall3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
