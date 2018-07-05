import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NavigationModule } from './navigation/navigation.module';

import { AppComponent } from './app.component';
import { ContactGroupsComponent } from './contact-groups/contact-groups.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactGroupsComponent
  ],
  imports: [
    BrowserModule,
    NavigationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
