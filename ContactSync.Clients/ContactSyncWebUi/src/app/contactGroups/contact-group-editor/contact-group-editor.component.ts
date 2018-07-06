import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { ContactGroup } from '../../shared/classes/contact-group';
import { ContactGroupService } from '../../shared/services/contact-group-service';

@Component({
  selector: 'app-contact-group-editor',
  templateUrl: './contact-group-editor.component.html',
  styleUrls: ['./contact-group-editor.component.css']
})
export class ContactGroupEditorComponent implements OnInit {

  public contactGroup: ContactGroup;

  constructor(private route: ActivatedRoute,
    private contactGroupService: ContactGroupService,
    private location: Location) { }

  ngOnInit() {

    const id = +this.route.snapshot.paramMap.get('id');

    if (id !== 0) {
      this.contactGroupService.getContactGroup(id)
        .subscribe((data: ContactGroup) => this.contactGroup = data, error => console.log(error) );
    }

  }

  onUpdateContactGroup() {
    this.contactGroupService.patchContactGroup(this.contactGroup.id, this.contactGroup)
    .subscribe((data: ContactGroup) => this.contactGroup = data, error => console.log(error) );
  }

  goBack(): void {
    this.location.back();
  }

}
