
import { BrowserModule } from '@angular/platform-browser';

import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { FormsModule } from '@angular/forms';

import { HttpClient } from '@angular/common/http';

@NgModule({

  declarations: [

    AppComponent

  ],

  imports: [

    BrowserModule,

    FormsModule,

    HttpClient,

  ],

  providers: [],

  bootstrap: [AppComponent]

})

export class AppModule { }
