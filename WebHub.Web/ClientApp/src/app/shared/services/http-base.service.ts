import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class HttpBase {
    public httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }
}