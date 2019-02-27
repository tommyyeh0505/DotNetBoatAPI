import { Component, OnInit } from '@angular/core';
import {Boat} from '../boat';
import {BoatService} from '../boat.service';
import { Router } from '@angular/router';
@Component({
  selector: 'boat-component',
  templateUrl: './boat.component.html',
  styleUrls: ['./boat.component.css']
})
export class BoatComponent implements OnInit {
  selected: Boat;
  boats: Boat[];
  constructor(
    private boatService: BoatService,
    private router: Router
  ) { }
    onSelect(boat: Boat): void {
    this.selected = boat;
  }
  getBoats(): void {
    this.boatService.getBoats()
    .then(boats => this.boats = boats);
  }
  
  ngOnInit(): void {
    this.getBoats();
  }
  gotoDetail(): void {
    this.router.navigate(['/detail', this.selected.BoatId]);
  }
  
}
