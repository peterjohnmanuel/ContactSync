import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';


import { ContactGroupsComponent } from '../contact-groups/contact-groups.component';

const routes: Routes = [
  { path: '', redirectTo: '/contactgroup', pathMatch: 'full' },
  { path: 'contactgroup', component: ContactGroupsComponent },

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
