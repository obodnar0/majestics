import { Component, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { ContestsService } from "../../services/contests.service";
import { Utilities } from "../../utils/utilities";

@Component({
  selector: 'add-work-component',
  templateUrl: './add-work.component.html',
  styleUrls: ['./add-work.component.css']
})
export class AddWorksComponent {

  constructor(private contestsService: ContestsService,
    private router: Router,
    private utilities: Utilities) {
  }

  @Output() contestCreated = new EventEmitter<boolean>();

  public addContest(title: string, description: string, isOpen: boolean) {
    this.contestsService.CreateContest(title, description, this.utilities.getBoolean(isOpen)).subscribe(response => {
      this.contestCreated.next(true);
    }, error => {
      this.contestCreated.next(false);
      console.error(error);
    });;
  }
}
