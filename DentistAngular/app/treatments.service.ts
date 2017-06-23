import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
@Injectable()
export class TreatmentsService {

    private _baseUrl = "http://localhost:51035/api/";

    constructor(private _http: Http) { }

    createAuthorizationHeader(headers: Headers) {
        headers.append('x-wsapikey','Rikki0145:gs145ka' );
    }

    getTreatments() {
        xhr.setRequestHeader("x-wsapikey", "Rikki0145:gs145ka");
        let headers = new Headers({ 'Access-Control-Request-Headers': 'x-wsapikey:Rikki0145:gs145ka'});
        let options = new RequestOptions({ headers: headers });
        return this._http.get("http://localhost:51035/api/Patients", options).map((res: Response) => res.json()).catch(this.handleError);
    }

    private handleError(error: Response | any) {
        // In a real world app, you might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);


    }
}