import { Component, Input } from '@angular/core';
import { Room } from '../models/Room';
@Component({
    selector: "room-form",
    templateUrl: './room-form.component.html'
})

export class RoomFormComponent {
    @Input() room: Room;
}
