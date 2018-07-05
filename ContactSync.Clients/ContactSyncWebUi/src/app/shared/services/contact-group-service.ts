import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ContactGroup } from '../classes/contact-group';

@Injectable()
export class ContactGroupService {

    host = 'http://localhost:61763/api/';

    constructor(private http: HttpClient) { }

    public getContactGroups(): Observable<ContactGroup[]> {
         return this.http.get<ContactGroup[]>(this.host + 'ContactGroup');
    }

}
