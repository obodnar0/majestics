import { Component, OnInit, ViewChild} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContestsService } from "../../services/contests.service";
import { IContest } from "../../Models/contest";
import { IWork } from "../../Models/work";

@Component({
  selector: 'contest-details-component',
  templateUrl: './contest-details.component.html',
  styleUrls: ['./contest-details.component.css']
})
export class ContestDetailsComponent implements OnInit {
  private contestId: number;
  public contest: IContest;
  public selectedWorkId: string;

  public isAdd: boolean;
  addWork() {
    this.isAdd = !this.isAdd;
  }

  constructor(private contestsService: ContestsService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  getContestDetails() {
    this.contestsService.GetContest(this.contestId).subscribe(response => {
      this.contest = JSON.parse(response.result);
    }, error => console.error(error));
  }

  public openMarker(work: IWork) {
    this.router.navigate(
      ['/contest/mark', work.WorkId]);
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.contestId = params["id"];
      this.getContestDetails();
    });
  }
}
