import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-fake-login',
  templateUrl: './fake-login.component.html',
  styleUrls: ['./fake-login.component.scss']
})
export class FakeLoginComponent implements OnInit {

  constructor() {
  }

  ngOnInit() {
  }

  fakeLogin() {
    const rights = prompt('Вы дейстиветльо хотите залогиниться?' +
      ' Если да, что введите ваши права (2048 - посетитель без прав, 2047 - полный доступ):');
    if (rights) {
      console.log(Number(rights));
    } else {
      console.log(-1);
    }
  }
}
