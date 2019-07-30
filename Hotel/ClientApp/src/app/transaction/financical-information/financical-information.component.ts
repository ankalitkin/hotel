import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { FinancicalInformation } from '../models/transaction';


@Component({
  selector: 'financical-information',
  templateUrl: './financical-information.component.html',
  styleUrls: ['./financical-information.component.scss'],
})
export class FinancicalInformationComponent implements OnInit {

  displayedColumns: string[] = ['TheNoumber', 'Date', 'Sum'];
  dataSource: MatTableDataSource<FinancicalInformation>;
  @Input()
  financicalInformation: FinancicalInformation[] | null | undefined;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() { }

  ngOnInit() {
    console.log(this.financicalInformation);
    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource(this.financicalInformation);

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;

    console.log(this.dataSource.data);
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  // для быстрого фильтра(котрый в списке) TODO: сделать нормально
  parseDate(input) {
    let separator: string = '-';
    let newDate: Date = new Date(input);
    let day: string = ((newDate.getDate() > 9) ? newDate.getDate() : "0" + newDate.getDate()).toString();
    let mouth: string = ((newDate.getMonth() > 9) ? newDate.getMonth() : "0" + newDate.getMonth()).toString();

    return day + separator + mouth + separator + newDate.getFullYear();
  }

}
