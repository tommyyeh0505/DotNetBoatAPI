import { Component, OnInit, Input } from '@angular/core'; 
import {Boat} from '../boat'; 
import { ActivatedRoute, Params }   from '@angular/router';
import { Location }                 from '@angular/common';
import { BoatService } from '../boat.service';

@Component({
  selector: 'app-boat-detail',
  templateUrl: './boat-detail.component.html',
  styleUrls: ['./boat-detail.component.css']
})
export class BoatDetailComponent implements OnInit {

  constructor(
    private boatService: BoatService,
    private route: ActivatedRoute,
    private location: Location
  ) { }
  
  ngOnInit() {
    this.route.params.forEach((params: Params) => {
      let id = +params['id'];
      this.boatService.getBoatById(id)
        .then(result => this.boat = result);
    });
  }
  goBack(): void {
    this.location.back();
  }
  

  @Input()
  boat: Boat;

}
