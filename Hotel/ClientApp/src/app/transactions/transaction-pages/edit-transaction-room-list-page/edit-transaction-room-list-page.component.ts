import { Component, OnInit, Input, EventEmitter, Output} from '@angular/core';
import { DataServiceTransaction } from '../../_services/data.service.transaction';
import { Transaction } from '../../../_models/transaction';
import { Room } from 'src/app/_models/room';

@Component({
  selector: 'app-edit-transaction-room-list-page',
  templateUrl: './edit-transaction-room-list-page.component.html',
  styleUrls: ['./edit-transaction-room-list-page.component.scss'],
  providers: [DataServiceTransaction]
})
export class EditTransactionRoomListPageComponent implements OnInit {

  @Input()
  transaction?: Transaction;
  @Input()
  room?: Room;
  numberDay: number;

  @Output()
  selectRoomEmitter = new EventEmitter<Room>();

  rooms?: Room[];

  isLoaded: Boolean = false;

  constructor(private dataService: DataServiceTransaction) { }

  ngOnInit() {
    if (this.transaction != undefined) {
      let date2 = new Date(this.transaction.checkOutTime);
      let date1 = new Date(this.transaction.checkInTime);
      this.numberDay = Math.ceil(Math.abs(date2.getTime() - date1.getTime()) / (1000 * 3600 * 24));
    }
     
    this.loadRooms();
  }

  update(transaction: Transaction, room: Room) {
    this.transaction = transaction;
    this.room = room;
    this.loadRooms();
  }

  loadRooms() {
    console.log(this.transaction, this.room);
    this.isLoaded = false;
    this.dataService.GetFreeRooms(this.transaction, this.room)
      .subscribe((data: Room[]) => { this.CompleteLoad(data); });
  }

  CompleteLoad(data: Room[]) {
    this.rooms = data;
    for (let elem in this.rooms) {
      this.rooms[elem].TheNoumber = +elem + 1;
      this.dataService.GetRoomCost(this.rooms[elem].roomId) // вынести из цикла и получить все разом
        .subscribe((data: number) => { this.rooms[elem].Cost = data; });
    }
    this.isLoaded = true;
  }

  selectRoom(room: Room) {
    console.log("selected");
    console.log(room);

    this.selectRoomEmitter.emit(room);
  }

}
