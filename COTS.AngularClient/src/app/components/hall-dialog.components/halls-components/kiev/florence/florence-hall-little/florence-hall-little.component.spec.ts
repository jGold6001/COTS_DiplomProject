import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlorenceHallLittleComponent } from './florence-hall-little.component';

describe('FlorenceHallLittleComponent', () => {
  let component: FlorenceHallLittleComponent;
  let fixture: ComponentFixture<FlorenceHallLittleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlorenceHallLittleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlorenceHallLittleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
