import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeanceBlockComponent } from './seance-block.component';

describe('SeanceBlockComponent', () => {
  let component: SeanceBlockComponent;
  let fixture: ComponentFixture<SeanceBlockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeanceBlockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeanceBlockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
