import { Component, Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

@Injectable()
export class AppComponent {
  title = 'function-test';
  constructor(private http: HttpClient) {
  }
  public getRequest() {
    console.log("I've been pressed!");
    this.http.get(environment.functionURL,  { responseType: 'text' as 'text' }).subscribe(response => console.log(response));
  }
}
