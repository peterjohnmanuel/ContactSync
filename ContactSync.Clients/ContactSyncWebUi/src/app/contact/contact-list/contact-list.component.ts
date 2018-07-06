import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Contact } from '../../shared/classes/contact';
import { ContactGroup } from '../../shared/classes/contact-group';
import { ContactGroupService } from '../../shared/services/contact-group-service';
import { ContactService } from '../../shared/services/contact-service';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private contactService: ContactService,
    private contactGroupService: ContactGroupService,
    private location: Location) { }

    private contacts: Contact[];
    private contactGroup: ContactGroup;
    private search: string;
    private contactGroupId: any;


  ngOnInit() {

    this.contactGroupId = +this.route.snapshot.paramMap.get('id');

    if (this.contactGroupId !== 0) {
      this.contactService.getContacts(this.contactGroupId)
        .subscribe((data: Contact[]) => this.contacts = data, error => console.log(error));

        this.contactGroupService.getContactGroup(this.contactGroupId)
        .subscribe((data: ContactGroup) => this.contactGroup = data, error => console.log(error));
    }
  }

  goBack(): void {
    this.location.back();
  }

  searchContacts(search) {

    if (search.length >= 3) {
      this.contactService.getContactsWithSearch(this.contactGroupId, search)
        .subscribe((data: Contact[]) => this.contacts = data, error => console.log(error));
    }

    if (search.length === 0 && this.contacts.length === 0) {
      this.contactService.getContactsWithSearch(this.contactGroupId, search)
        .subscribe((data: Contact[]) => this.contacts = data, error => console.log(error));
    }

  }

}
