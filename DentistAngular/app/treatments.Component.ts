import { Component } from '@angular/core';
import { ContactFormComponent} from './contact-form.component';
import { TreatmentsService } from "./treatments.service";
@Component({
  selector: 'Treatment',
  template: '<h1>Treatment module: {{date}} {{treatments}}</h1>'
})
export class TreatmentComponent { 
    date="01-01-2017";
    treatments;
    constructor(treatmentsService: TreatmentsService) {
        this.treatments = treatmentsService.getTreatments();
console.log("Treatment",this.treatments);
    }
}