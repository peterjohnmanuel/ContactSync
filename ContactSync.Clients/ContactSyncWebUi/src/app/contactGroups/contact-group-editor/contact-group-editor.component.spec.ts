import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactGroupEditorComponent } from './contact-group-editor.component';

describe('ContactGroupEditorComponent', () => {
  let component: ContactGroupEditorComponent;
  let fixture: ComponentFixture<ContactGroupEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContactGroupEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactGroupEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
