import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {Role} from '../../_models/role';
import {User} from '../../_models/user';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-user-editor',
  templateUrl: './user-editor.component.html',
  styleUrls: ['./user-editor.component.scss']
})

export class UserEditorComponent implements OnInit, OnChanges {
  formGroup: FormGroup;
  @Input() user: User;
  @Input() roles: Role[];
  @Input() isCustomer: boolean;
  @Output() userSave = new EventEmitter<User>();

  constructor(private fb: FormBuilder) {
    this.user = new User();
    const fg: any = {
      userId: fb.control(undefined),
      firstName: fb.control(undefined, [Validators.required]),
      lastName: fb.control(undefined, [Validators.required]),
      birthDate: fb.control(undefined, [Validators.required]),
      email: fb.control(undefined),
      phone: fb.control(undefined),
      password: fb.control(undefined),
      roleId: fb.control(undefined, [Validators.required]),
      isDeleted: fb.control(undefined)
    };
    if (this.isCustomer) {
      fg.clientId = fb.control(undefined, [Validators.required]);
    }
    this.formGroup = fb.group(fg);
  }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if ('user' in changes && this.user) {
      this.formGroup.patchValue(this.user);
    }

    if ('roles' in changes && this.roles) {
      if (!this.user.roleId) {
        this.user.roleId = String(this.roles[0].roleId);
      }
      this.formGroup.patchValue({roleId: String(this.user.roleId)});
    }
  }

  handleSaveClick() {
    this.user = new User(this.formGroup.value);
    this.userSave.emit(this.user);
  }

}
