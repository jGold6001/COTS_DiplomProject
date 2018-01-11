import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MpxSkymallHall2Component } from './mpx-skymall-hall-2.component';

describe('MpxSkymallHall2Component', () => {
  let component: MpxSkymallHall2Component;
  let fixture: ComponentFixture<MpxSkymallHall2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MpxSkymallHall2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MpxSkymallHall2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
