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
}
