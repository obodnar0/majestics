import { Component, OnInit, ViewChildren } from '@angular/core';
import { IWork } from "../../Models/work";
import { ContestsService } from "../../services/contests.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'mark-work-component',
  templateUrl: './mark-work.component.html',
  styleUrls: ['./mark-work.component.css']
})
export class MarkWorksComponent implements OnInit {

  public work: IWork;
  public workId: string;
  public criterias: any[];

  constructor(private contestsService: ContestsService,
    private route: ActivatedRoute,) {
  }

  @ViewChildren('markInput') marks;

  getWorkDetails() {
    this.contestsService.GetWorkDetails(this.workId).subscribe(res => {
      this.work = JSON.parse(res.result);
    });
  }

  markWork() {
    this.marks.forEach(x => {
      if (x.nativeElement.value !== "") {
        this.contestsService.MarkWork(this.workId, x.nativeElement.value, x.nativeElement.id)
          .subscribe(res => this.getWorkDetails());
      }
    });
  }

  getCriterias() {
    this.contestsService.GetCriterias().subscribe(res => this.criterias = JSON.parse(res.result));
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.workId = params["id"];
      this.getWorkDetails();
      this.getCriterias();
    });
  }
}
