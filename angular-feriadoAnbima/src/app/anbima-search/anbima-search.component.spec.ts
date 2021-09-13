import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnbimaSearchComponent } from './anbima-search.component';

describe('AnbimaSearchComponent', () => {
  let component: AnbimaSearchComponent;
  let fixture: ComponentFixture<AnbimaSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnbimaSearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnbimaSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
