import { Component, Input } from '@angular/core';
import { RoomCost } from '../models/RoomCost';

@Component({
  selector: 'roomcost-form',
  templateUrl: './roomcost-form.component.html',
  styleUrls: ['./roomcost-form.component.scss']
})

export class RoomCostFormComponent {
  @Input() roomCost: RoomCost;
  @Input() categoryCost: number;
  @Input() numberOfSeatsCost: number;
  @Input() hasMiniBarCost: number;
  @Input() totalCost: number;
  
  ngOnInit() {
    this.numberOfSeatsCost =
      this.categoryCost =
      this.hasMiniBarCost = 10000;
    this.totalCost =
      this.numberOfSeatsCost +
      this.categoryCost +
      this.hasMiniBarCost;
  }

  changeCost() {
    this.roomCost.cost = this.categoryCost + this.numberOfSeatsCost;
    if (this.roomCost.hasMiniBar)
      this.roomCost.cost += this.hasMiniBarCost;
  }

  clearErros() {
    document.getElementById("room-category-id").classList.remove("has-error");
    document.getElementById("seats-id").classList.remove("has-error");
    document.getElementById("totalcost-id").classList.remove("has-error");
    
  }

}
