import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../classes/contact';

@Injectable()
export class ContactService {

    host = 'http://localhost:61763/api/';

    constructor(private http: HttpClient) { }

    public getContacts(contactGroupId): Observable<Contact[]> {
        return this.http.get<Contact[]>(this.host + 'ContactGroup/' + contactGroupId + '/Contact');
    }

    public getContactsWithSearch(contactGroupId, search): Observable<Contact[]> {
        return this.http.get<Contact[]>(this.host + 'ContactGroup/' + contactGroupId + '/Contact?search=' + search);
    }

    public saveContact(contactGroupId, contact): Observable<Contact> {
        return this.http.post<Contact>(this.host + 'ContactGroup/' + contactGroupId + '/Contact', contact);
    }

    public updateContact(contactGroupId, contact): Observable<Contact> {
        return this.http.patch<Contact>(this.host + 'ContactGroup/' + contactGroupId + '/Contact/' + contact.id, contact);
    }

    public getContactById(contactGroupId, contactId): Observable<Contact> {
        return this.http.get<Contact>(this.host + 'ContactGroup/' + contactGroupId + '/Contact/' + contactId);
    }
}
