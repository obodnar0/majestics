import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ContestsService } from "../../services/contests.service";
import { Utilities } from "../../utils/utilities";

@Component({
  selector: 'add-contest-component',
  templateUrl: './add-contest.component.html',
  styleUrls: ['./add-contest.component.css']
})
export class AddContestsComponent {

  constructor(private contestsService: ContestsService,
    private router: Router,
    private utilities: Utilities) {
  }

  public addContest(title: string, description: string, isOpen: boolean) {
    this.contestsService.CreateContest(title, description, this.utilities.getBoolean(isOpen)).subscribe(response => {
      console.log(response);
      return JSON.parse(response.result);
    }, error => console.error(error));;
  }
}
