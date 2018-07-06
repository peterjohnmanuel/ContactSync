import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { NavigationModule } from './navigation/navigation.module';

import { AppComponent } from './app.component';

import { ContactGroupService } from './shared/services/contact-group-service';
import { ContactService } from './shared/services/contact-service';
import { ContactGroupListComponent } from './contactGroups/contact-group-list/contact-group-list.component';
import { ContactGroupEditorComponent } from './contactGroups/contact-group-editor/contact-group-editor.component';
import { ContactListComponent  } from './contact/contact-list/contact-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactGroupListComponent,
    ContactGroupEditorComponent,
    ContactListComponent
  ],
  imports: [
    BrowserModule,
    NavigationModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ContactGroupService, ContactService],
  bootstrap: [AppComponent]
})
export class AppModule { }
