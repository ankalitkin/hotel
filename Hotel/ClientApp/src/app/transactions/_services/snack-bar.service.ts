import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

import { Injectable } from '@angular/core';
import { config } from 'rxjs';

@Injectable()
export class SnackBarService  {

  constructor(private _snackBar: MatSnackBar) { }

  private openSnackBar(message: string, action: string, config: MatSnackBarConfig) {
    this._snackBar.open(message, action, config);
  }

  succsesSnack() {
    let config = new MatSnackBarConfig();
    config.duration = 3000;
    config.panelClass = ['snackBar-succses'];

    this.openSnackBar("Успешно!", "ОК", config);
  }

  failureSnack(message?:string) {
    let config = new MatSnackBarConfig();
    config.duration = 5000;
    config.panelClass = ['snackBar-fail'];
    if (message == undefined)
      message = " ";
    this.openSnackBar("Ошибка!" + message, "ok", config);
  }

  showMessage(message: string, action: string, config?: MatSnackBarConfig) {
    if (config == undefined) {
      config = new MatSnackBarConfig();
      config.duration = 3000;
    }

    this.openSnackBar(message, action, config);
  }

}
