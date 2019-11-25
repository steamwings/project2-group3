import { Component, OnInit } from '@angular/core';
import { KrazAPIService } from 'src/app/services/kraz-api.service';

@Component({
  selector: 'app-order-sides',
  templateUrl: './order-sides.component.html',
  styleUrls: ['./order-sides.component.css']
})

export class OrderSidesComponent implements OnInit {

  constructor(private api: KrazAPIService) {
    
  }

  ngOnInit() {
  }

}
