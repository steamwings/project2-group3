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
    {text: 'Log-In', cols: 3, rows: 1, color: '#f16821'},
    {text: 'Order', cols: 1, rows: 2, color: '#f3a333'},
    {text: 'Coupons', cols: 1, rows: 1, color: '#f3a333'},
    {text: 'Register Today', cols: 2, rows: 1, color: '#cd4545'},
  ];
  ngOnInit() {
  }
}



