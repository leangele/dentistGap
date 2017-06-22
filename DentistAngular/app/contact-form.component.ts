import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
@Component({
    selector: 'contact-form',
    templateUrl: "app/contact-form.component.html",

})

export class ContactFormComponent {
    onSubmit(form){
        console.log(form);
    }
}