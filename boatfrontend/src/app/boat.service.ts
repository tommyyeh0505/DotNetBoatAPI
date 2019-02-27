import { Injectable } from '@angular/core';
import {DUMMY_DATA} from './data/dummy-data';
import {Boat} from './boat'
import { Headers, Http, Response } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class BoatService {

  private BASE_URL = "http://https://dotnetass1tommyeva.azurewebsites.net/api/boats"; 
  constructor(private http: Http) { } 
  
  getBoats(): Promise<Boat[]> {
    return this.http.get(this.BASE_URL)
     .toPromise()
     .then(response => response.json() as Boat[])
     .catch(this.handleError);
  }
  
   getBoatById(id: number): Promise<Boat> {
    return this.getBoats()
      .then(result => result.find(boat => boat.BoatId === id));
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
  
}
