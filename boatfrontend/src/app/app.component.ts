import { Component } from '@angular/core';
import { BoatService } from './boat.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [BoatService]
})
export class AppComponent {
  title = 'BoatAPI FrontEnd';
}
