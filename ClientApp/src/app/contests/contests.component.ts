import { Component } from '@angular/core';
import { ContestsService } from "../services/contests.service";
import { IContest } from "../Models/contest";
import { Router } from '@angular/router';

@Component({
  selector: 'app-contests-component',
  templateUrl: './contests.component.html'
})
export class ContestsComponent {
  public contests: IContest[];
  public isAdd: boolean = false;

  constructor(private contestsService: ContestsService,
              private router: Router) {
    this.loadContests();
  }

  public addContest() {
    this.isAdd = !this.isAdd;
    console.log(this.isAdd);
  }

  public navigateContest(contest: IContest) {
    this.router.navigate(
      ['/contest', contest.ContestId]);
  }

  public loadContests() {
    this.contestsService.GetContests().subscribe(response => {
      this.contests = JSON.parse(response.result);
      console.log(response.result);
    }, error => console.error(error));
  }
}
