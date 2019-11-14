import {Component, OnInit} from '@angular/core';

export interface Tile {
  color: string;
  cols: number;
  rows: number;
  text: string;
}


@Component({
  selector: 'app-landing-grid',
  templateUrl: './landing-grid.component.html',
  styleUrls: ['./landing-grid.component.css']
})
export class LandingGridComponent implements OnInit {
  constructor() { }
  tiles: Tile[] = [
    {text: 'Log-In', cols: 3, rows: 1, color: '#f5a882'},
    {text: 'Order', cols: 1, rows: 2, color: 'lightgreen'},
    {text: 'Coupons', cols: 1, rows: 1, color: 'lightpink'},
    {text: 'Register Today', cols: 2, rows: 1, color: '#a6f582'},
  ];
  ngOnInit() {
  }
}



