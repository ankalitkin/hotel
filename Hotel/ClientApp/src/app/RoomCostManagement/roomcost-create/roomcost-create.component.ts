import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataServiceRoomCosts } from '../services/data.service.roomcosts';
import { RoomCost } from '../models/RoomCost';

@Component({
  templateUrl: './roomcost-create.component.html',
  providers: [DataServiceRoomCosts],
  styleUrls: ['./roomcost-create.component.scss']
})

export class RoomCostCreateComponent {

  roomCost: RoomCost = new RoomCost();    // добавляемый объект
  constructor(private dataService: DataServiceRoomCosts, private router: Router) { }

  checkValid() {
    let valid: boolean = true;
    if (this.roomCost.categoryId == undefined) {
      valid = false;
      document.getElementById("room-category-id").classList.add("has-error");
    }

    if (this.roomCost.numberOfSeats == undefined) {
      valid = false;
      document.getElementById("seats-id").classList.add("has-error");
    }

    if (this.roomCost.cost == undefined || this.roomCost.cost<0) {
      valid = false;
      document.getElementById("totalcost-id").classList.add("has-error");
    }

    return valid;
  }

  save() {
    if (this.checkValid())
    this.dataService.createProduct(this.roomCost).subscribe(data => this.router.navigateByUrl("/roomcostmanager/roomCosts"));
  }
}
