import { Component, OnInit } from '@angular/core';
import {Boat} from '../boat';
import {BoatService} from '../boat.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  boats: Boat[];
  constructor(private boatService: BoatService) { }
  ngOnInit() {
    this.boatService.getBoats()
      .then(results => this.boats = results.slice(0, 4));
  }
}
