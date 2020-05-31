import { Component, Output, EventEmitter, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContestsService } from "../../services/contests.service";
import { Utilities } from "../../utils/utilities";

@Component({
  selector: 'mark-work-component',
  templateUrl: './mark-work.component.html',
  styleUrls: ['./mark-work.component.css']
})
export class MarkWorksComponent implements OnInit {

  constructor(private contestsService: ContestsService,
    private router: Router,
    private utilities: Utilities) {
  }

  public isOpen: boolean;
  @Input() workId: number;

  public addWork(title: string, description: string, source: string) {

    //let formData: FormData = new FormData();
    //formData.append('file', this.selectedFile, this.selectedFile.name);
    //this.contestsService.UploadFile(formData).subscribe(result => {
    //  console.log(result);
    //  this.contestsService.CreateWork(title, description, result.result, this.contestId)
    //    .subscribe(res => {
    //      console.log(res); this.workCreated.next(true)});
    //});

    //  this.contestsService.CreateContest(title, description, this.utilities.getBoolean(isOpen)).subscribe(response => {
    //    this.workCreated.next(true);
    //  }, error => {
    //      this.workCreated.next(false);
    //    console.error(error);
    //  });;
  }

  ngOnInit() {
    
  }
}
