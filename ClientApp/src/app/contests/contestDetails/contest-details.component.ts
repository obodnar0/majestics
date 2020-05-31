import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContestsService } from "../../services/contests.service";
import { IContest } from "../../Models/contest";

@Component({
  selector: 'contest-details-component',
  templateUrl: './contest-details.component.html',
  styleUrls: ['./contest-details.component.css']
})
export class ContestDetailsComponent implements OnInit {
  private contestId: number;
  private contest: IContest;

  constructor(private contestsService: ContestsService,
    private route: ActivatedRoute) {
  }

  getContestDetails() {
    this.contestsService.GetContest(this.contestId).subscribe(response => {
      this.contest = JSON.parse(response.result);
      console.log(response);
    }, error => console.error(error));
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.contestId = params["id"];
      this.getContestDetails();
    });
  }
}
