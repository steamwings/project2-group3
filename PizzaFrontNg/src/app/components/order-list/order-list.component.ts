import { Component, OnInit } from '@angular/core';
import { KrazAPIService } from '../../services/kraz-api.service'

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  constructor(private api : KrazAPIService) { }

  ngOnInit() {

  }

}
