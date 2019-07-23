import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormGroupDirective, ValidationErrors } from '@angular/forms';

@Component({
  selector: 'app-control-errors',
  templateUrl: './control-errors.component.html',
  styleUrls: ['./control-errors.component.scss']
})
export class ControlErrorsComponent implements OnInit {

  @Input() name: string | undefined | null;

  constructor(private formGroup: FormGroupDirective) { }

  ngOnInit() {
  }

  get errors(): ValidationErrors | undefined | null {
    // FIXME: normal representation in control
    if (this.name != undefined) {
      const control = this.formGroup.control.controls[this.name];
      return control.errors;
    }
    return undefined;
  }
}
