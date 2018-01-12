import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlorenceHallRedComponent } from './florence-hall-red.component';

describe('FlorenceHallRedComponent', () => {
  let component: FlorenceHallRedComponent;
  let fixture: ComponentFixture<FlorenceHallRedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlorenceHallRedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlorenceHallRedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
