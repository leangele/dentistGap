"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var TreatmentsService = (function () {
    function TreatmentsService(_http) {
        this._http = _http;
        this._baseUrl = "http://localhost:51035/api/";
    }
    TreatmentsService.prototype.createAuthorizationHeader = function (headers) {
        headers.append('x-wsapikey', 'Rikki0145:gs145ka');
    };
    TreatmentsService.prototype.getTreatments = function () {
        xhr.setRequestHeader("x-wsapikey", "Rikki0145:gs145ka");
        var headers = new http_1.Headers({ 'Access-Control-Request-Headers': 'x-wsapikey:Rikki0145:gs145ka' });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http.get("http://localhost:51035/api/Patients", options).map(function (res) { return res.json(); }).catch(this.handleError);
    };
    TreatmentsService.prototype.handleError = function (error) {
        // In a real world app, you might use a remote logging infrastructure
        var errMsg;
        if (error instanceof http_1.Response) {
            var body = error.json() || '';
            var err = body.error || JSON.stringify(body);
            errMsg = error.status + " - " + (error.statusText || '') + " " + err;
        }
        else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable_1.Observable.throw(errMsg);
    };
    return TreatmentsService;
}());
TreatmentsService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], TreatmentsService);
exports.TreatmentsService = TreatmentsService;
//# sourceMappingURL=treatments.service.js.map