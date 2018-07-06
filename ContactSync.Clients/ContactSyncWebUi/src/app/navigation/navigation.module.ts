import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';



import { ContactGroupListComponent  } from '../contactGroups/contact-group-list/contact-group-list.component';
import { ContactGroupEditorComponent  } from '../contactGroups/contact-group-editor/contact-group-editor.component';
import { ContactListComponent  } from '../contact/contact-list/contact-list.component';
import { ContactEditorComponent  } from '../contact/contact-editor/contact-editor.component';

const routes: Routes = [
  { path: '', redirectTo: '/contactgroup', pathMatch: 'full' },
  { path: 'contactgroup', component: ContactGroupListComponent },
  { path: 'contactgroup/edit/:id', component: ContactGroupEditorComponent },
  { path: 'contactgroup/:id/contactlist', component: ContactListComponent },
  { path: 'contactgroup/:id/contacteditor/:contactId', component: ContactEditorComponent },
  { path: 'contactgroup/:id/contacteditor', component: ContactEditorComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [ RouterModule ],
  declarations: []
})
export class NavigationModule { }
