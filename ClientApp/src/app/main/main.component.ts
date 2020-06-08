import { Component, OnInit } from '@angular/core';
import { ContestsService } from "../services/contests.service";
import { IWork } from "../Models/work";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  public topWorks: Array<IWork>;

  constructor(private contestService: ContestsService) { }

  public loadTopRated() {
    this.contestService.getTopRatedWorks().subscribe(x => this.topWorks = JSON.parse(x.result));
  }

  ngOnInit(): void {
    this.loadTopRated();
  }

}
