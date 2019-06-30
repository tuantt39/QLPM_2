import { Component, OnInit } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Component({

  selector: 'app-root',

  templateUrl: './app.component.html',

  styleUrls: ['./app.component.css']

})

export class AppComponent implements OnInit {

  constructor(private httpClient: HttpClient) { }

  title: string = "QLPM";

  apiValues: string[] = [];

  ngOnInit() {

    this._httpService.get('/api/values').subscribe(values => {

      this.apiValues = values.json() as string[];

    });

  }

}
