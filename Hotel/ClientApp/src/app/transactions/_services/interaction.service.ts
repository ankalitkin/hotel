import { Injectable } from '@angular/core';

@Injectable()
export class InteractionService {
  // сделано как-то не по-хорошему, наверное, но зато просто :)
  // есть компонент родительский(recipient), который получает данные(temp) от дочернего
  private recipient: any;
  private temp: any;

  setRecipient(recipient: any) {
    this.recipient = recipient;
  }

  sendMessage() {
    if (this.recipient != undefined)
      this.recipient.getMessage();
  }

  setTemp(temp: any) {
    this.temp = temp;
  }

  getTemp(): any {
    return this.temp;
  }

}
