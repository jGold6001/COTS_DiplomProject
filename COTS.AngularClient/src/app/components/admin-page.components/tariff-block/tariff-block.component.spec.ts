import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TariffBlockComponent } from './tariff-block.component';

describe('TariffBlockComponent', () => {
  let component: TariffBlockComponent;
  let fixture: ComponentFixture<TariffBlockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TariffBlockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TariffBlockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
