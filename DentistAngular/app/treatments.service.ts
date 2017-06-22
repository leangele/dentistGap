import { Injectable } from '@angular/core';
import { Http, Response }          from '@angular/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map':
@Injectable()
export class TreatmentsService {
    private _baseUrl = "http://localhost:51035/api/";
    constructor(private _http: Http) { }
    getTreatments() {
        return this._http.get(this._baseUrl +"Treatments")
            .map(res => res.json());

    }

}
