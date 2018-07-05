import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { NavigationModule } from './navigation/navigation.module';

import { AppComponent } from './app.component';

import { ContactGroupService } from './shared/services/contact-group-service';
import { ContactGroupListComponent } from './contactGroups/contact-group-list/contact-group-list.component';
import { ContactGroupEditorComponent } from './contactGroups/contact-group-editor/contact-group-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactGroupListComponent,
    ContactGroupEditorComponent
  ],
  imports: [
    BrowserModule,
    NavigationModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ContactGroupService],
  bootstrap: [AppComponent]
})
export class AppModule { }
