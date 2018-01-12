import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlorenceHallBlueComponent } from './florence-hall-blue.component';

describe('FlorenceHallBlueComponent', () => {
  let component: FlorenceHallBlueComponent;
  let fixture: ComponentFixture<FlorenceHallBlueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlorenceHallBlueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlorenceHallBlueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
