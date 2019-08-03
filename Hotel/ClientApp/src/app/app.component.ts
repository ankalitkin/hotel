import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  check_auth()
  {
    if (localStorage.getItem('token') != null) {
      return true;
    }
  return false; 
  }
}

