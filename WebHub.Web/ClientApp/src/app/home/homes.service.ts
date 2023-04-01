import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { HttpBase } from '../shared/services/http-base.service'
import { Observable } from 'rxjs';

@Injectable()
export class HomeService extends HttpBase {
    constructor(private http: HttpClient) {
        super();
    }

    public getTestData(): Observable<string> {
        return this.http.get<string>('TestController', this.httpOptions);
    }
}