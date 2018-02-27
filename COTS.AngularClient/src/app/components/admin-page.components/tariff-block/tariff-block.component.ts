import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatDialog } from '@angular/material';

@Component({
  selector: 'app-tariff-block',
  templateUrl: './tariff-block.component.html',
  styleUrls: ['./tariff-block.component.css']
})
export class TariffBlockComponent implements OnInit {

  enable: boolean;

  displayedColumns = ['position', 'name', 'week_day', 'time_period', 'technology', 'sector','price','edit','delete'];
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit() {
  }

  @ViewChild(MatSort) sort: MatSort;
  
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  clickEdit(id: number){
    console.info(`edit ${id}`);
  }

  clickDelete(id: number){
    console.info(`delete ${id}`);
  }

  clickAdd(){
    let dialogRef = this.dialog.open(null, {
      width: '800px',
      disableClose: true,
      data: { destiny: 'add'}    
    });

    dialogRef.afterClosed().subscribe(() => {
      
    });

  }
}

export interface TariffView{
  position: number;
  id: number;
  name: string;
  weekDay: string;
  timePeriod: string;
  technology: string;
  sector: string;
  price: number;
}

const ELEMENT_DATA: TariffView[] = [
  {position: 1, id: 23, name: "day_holiday_green_2d", weekDay: "Выходной", timePeriod: "День", technology: '2d', sector: 'green', price: 100   },
  // {position: 2, id: 26, name: "Буря в стакане", genre: "Комедия" },
  // {position: 3, id: 28, name: "Рокки Бальбоа", genre: "Спорт Драма"},
  // {position: 4, id: 29, name: "Джуманджи", genre: "Фантастика" }
];