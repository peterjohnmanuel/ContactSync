import { Component, OnInit } from '@angular/core';

import { ContactGroup } from '../../shared/classes/contact-group';
import { ContactGroupService } from '../../shared/services/contact-group-service';

@Component({
  selector: 'app-contact-group-list',
  templateUrl: './contact-group-list.component.html',
  styleUrls: ['./contact-group-list.component.css']
})
export class ContactGroupListComponent implements OnInit {


  public contactGroups: ContactGroup[];

  constructor(private contactGroupService: ContactGroupService) { }

  ngOnInit() {
    this.contactGroupService.getContactGroups()
    .subscribe((data: ContactGroup[]) => {

      this.contactGroups = data;

    });
  }

}
