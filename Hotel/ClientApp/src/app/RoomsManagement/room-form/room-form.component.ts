import { Component, Input } from '@angular/core';
import { Room } from '../models/Room';
@Component({
    selector: "room-form",
    templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.scss']
})

export class RoomFormComponent {
  @Input() room: Room;

  clearErros() {

  }
}
