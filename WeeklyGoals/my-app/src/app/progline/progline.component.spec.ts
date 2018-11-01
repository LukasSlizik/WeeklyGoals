import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProglineComponent } from './progline.component';

describe('ProglineComponent', () => {
  let component: ProglineComponent;
  let fixture: ComponentFixture<ProglineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProglineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProglineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
