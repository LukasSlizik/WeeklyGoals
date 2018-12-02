import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent { // implements OnInit {

  //ngOnInit(): void {
  //  if (window.location.hash) {
  //    this.securityService.authorizedCallback();
  //  }
  //}

  //login() {
  //  console.log('start login');
  //  this.securityService.authorize();
  //}

  //refreshSession() {
  //  console.log('start refreshSession');
  //  this.securityService.authorize();
  //}

  //logout() {
  //  console.log('start logoff');
  //  this.securityService.logoff();
  //}

  title = 'my-app';

  //constructor(private _httpClient: HttpClient, public securityService: OidcSecurityService) {

  //}

}
