import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagesMenuComponent } from './messages-menu.component';

describe('MessagesMenuComponent', () => {
  let component: MessagesMenuComponent;
  let fixture: ComponentFixture<MessagesMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MessagesMenuComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MessagesMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
