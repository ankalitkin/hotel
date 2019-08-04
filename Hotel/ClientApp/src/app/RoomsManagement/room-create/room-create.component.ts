import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataServiceRooms } from '../services/data.service.rooms';
import { Room } from '../../_models/room';

@Component({
  templateUrl: './room-create.component.html',
  providers: [DataServiceRooms],
  styleUrls: ['./room-create.component.scss']
})

export class RoomCreateComponent {

    room: Room = new Room();    // добавляемый объект
    constructor(private dataService: DataServiceRooms, private router: Router) { }


  checkvalid() {
    let valid: boolean = true;

    //if ( )

    return valid;
  }

  save() {
    if ( this.checkvalid() )   
     this.dataService.createProduct(this.room).subscribe(data => this.router.navigateByUrl("/roommanager/rooms"));
  }
}
