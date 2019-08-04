import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Room, } from '../../../_models/room';

@Component({
  selector: 'user-edit-transaction-room-list',
  templateUrl: './user-edit-transaction-room-list.component.html',
  styleUrls: ['./user-edit-transaction-room-list.component.scss']
})
export class UserEditTransactionRoomListComponent implements OnInit {


  displayedColumns: string[] = ['TheNoumber', 'name', 'floor', 'roomTypeId', 'numberOfSeats', 'hasMiniBar', 'Cost'];
  dataSource: MatTableDataSource<Room>;

  selectedElement?: Room;

  @Input()
  rooms: Room[] | null | undefined;
  @Input()
  numberDay: number = 1;

  @Output()
  selectRoomEmitter = new EventEmitter<Room>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.rooms);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    console.log(this.numberDay);
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  selectRoom(room: Room) {
    this.selectRoomEmitter.emit(room);
    this.selectedElement = room;
  }

}
