import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlorenceHallBigComponent } from './florence-hall-big.component';

describe('FlorenceHallBigComponent', () => {
  let component: FlorenceHallBigComponent;
  let fixture: ComponentFixture<FlorenceHallBigComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlorenceHallBigComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlorenceHallBigComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
