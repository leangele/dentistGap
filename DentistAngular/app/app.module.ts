import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }   from './app.component';
import { TreatmentComponent } from './Treatments.Component';
import { TreatmentsService } from './treatments.service';
import { HttpModule, JsonpModule } from '@angular/http';
@NgModule({
  imports:      [ BrowserModule,HttpModule,JsonpModule ],
  declarations: [ 
    AppComponent, 
    TreatmentComponent],
  providers:    [TreatmentsService],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
