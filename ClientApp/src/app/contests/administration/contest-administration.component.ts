import { Component, Input, OnInit } from '@angular/core';
import { ContestsService } from "../../services/contests.service";
import { ICriteria } from "../../Models/criteria";

@Component({
  selector: 'contest-administration-component',
  templateUrl: './contest-administration.component.html',
  styleUrls: ['./contest-administration.component.css']
})
export class ContestAdministration implements OnInit {

  constructor(private contestsService: ContestsService) {
  }

  isCriteriaAdd: boolean = false;
  public criterias: Array<ICriteria>;

  @Input() contestId: string;

  public addCriteria() {
    this.isCriteriaAdd = !this.isCriteriaAdd;
  }

  public addNewCriteria(name: string, description: string) {
    this.contestsService.CreateCriteria(name, description, this.contestId).subscribe(res => {
      if (res.result === "true") this.loadCriterias();
    });
  }

  public loadCriterias() {
    this.contestsService.GetCriterias(this.contestId).subscribe(res => {
      this.criterias = JSON.parse(res.result);
    });
  }

  ngOnInit() {
    this.loadCriterias();
  }
}
