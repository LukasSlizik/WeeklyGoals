import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgtableComponent } from './progtable.component';

describe('ProgtableComponent', () => {
  let component: ProgtableComponent;
  let fixture: ComponentFixture<ProgtableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProgtableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgtableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
