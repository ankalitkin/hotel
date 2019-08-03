import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-fake-login',
  templateUrl: './fake-login.component.html',
  styleUrls: ['./fake-login.component.scss']
})
export class FakeLoginComponent implements OnInit {

  constructor(private router: Router) {
  }

  ngOnInit() {
  }

  fakeLogin() {
    const rights = prompt('Вы дейстиветльо хотите залогиниться?' +
      ' Если да, что введите ваши права (2048 - посетитель без прав, 2047 - полный доступ):');
    let data = {};
    if (rights) {
      data = {
        firstName: 'FakeUser',
        rights: rights
      };
    }
    let header = {
      alg: 'HS256',
      typ: 'JWT'
    };


    const token = btoa(JSON.stringify(header)) + '.' + btoa(JSON.stringify(data)) + '.' + btoa('FAKE_SIGNATURE');
    localStorage.setItem('token', token);
    this.router.navigate(['']);
  }
}
