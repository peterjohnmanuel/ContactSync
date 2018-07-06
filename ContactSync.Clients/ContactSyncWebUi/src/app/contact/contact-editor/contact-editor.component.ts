import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Contact } from '../../shared/classes/contact';
import { ContactGroup } from '../../shared/classes/contact-group';
import { ContactGroupService } from '../../shared/services/contact-group-service';
import { ContactService } from '../../shared/services/contact-service';

@Component({
  selector: 'app-contact-editor',
  templateUrl: './contact-editor.component.html',
  styleUrls: ['./contact-editor.component.css']
})
export class ContactEditorComponent implements OnInit {

  private contactGroupId: any;
  private contactId: any;
  private contact: Contact;
  private contactGroup: ContactGroup;
  private errors: any[];

  constructor(private route: ActivatedRoute,
    private contactService: ContactService,
    private contactGroupService: ContactGroupService,
    private location: Location) { }

  ngOnInit() {

    this.contactGroupId = +this.route.snapshot.paramMap.get('id');
    this.contactId = +this.route.snapshot.paramMap.get('contactId');

    if (this.contactGroupId !== 0 && this.contactId !== 0) {
      this.contactService.getContactById(this.contactGroupId, this.contactId)
        .subscribe((data: Contact) => this.contact = data, error => console.log(error));

        this.contactGroupService.getContactGroup(this.contactGroupId)
        .subscribe((data: ContactGroup) => this.contactGroup = data, error => console.log(error));
    } else {
       this.contact = new Contact();
    }
  }

  onSaveContact() {

    if (this.contact.id !== 0 && this.contact.id !== undefined) {

       this.contactService.updateContact(this.contactGroupId, this.contact)
         .subscribe(
           (data: Contact) => this.contact = data,
           (errors: any[]) => this.errors = errors );
     } else {


       this.contactService.saveContact(this.contactGroupId, this.contact)
       .subscribe(
         (data: Contact) => this.contact = data,
         (errors: any[]) => this.errors = errors);
     }
  }

  goBack(): void {
    this.location.back();
  }

}
