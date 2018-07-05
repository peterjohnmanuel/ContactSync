import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { NavigationModule } from './navigation/navigation.module';

import { AppComponent } from './app.component';

import { ContactGroupService } from './shared/services/contact-group-service';
import { ContactGroupListComponent } from './contactGroups/contact-group-list/contact-group-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactGroupListComponent
  ],
  imports: [
    BrowserModule,
    NavigationModule,
    HttpClientModule
  ],
  providers: [ContactGroupService],
  bootstrap: [AppComponent]
})
export class AppModule { }
