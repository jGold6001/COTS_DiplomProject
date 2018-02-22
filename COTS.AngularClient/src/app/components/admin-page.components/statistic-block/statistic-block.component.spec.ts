import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatisticBlockComponent } from './statistic-block.component';

describe('StatisticBlockComponent', () => {
  let component: StatisticBlockComponent;
  let fixture: ComponentFixture<StatisticBlockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatisticBlockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatisticBlockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
