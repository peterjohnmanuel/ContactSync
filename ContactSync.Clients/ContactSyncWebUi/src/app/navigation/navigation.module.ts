import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';



import { ContactGroupListComponent  } from '../contactGroups/contact-group-list/contact-group-list.component';

const routes: Routes = [
  { path: '', redirectTo: '/contactgroup', pathMatch: 'full' },
  { path: 'contactgroup', component: ContactGroupListComponent },

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
