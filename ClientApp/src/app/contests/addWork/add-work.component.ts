import { Component, Output, EventEmitter, Input } from '@angular/core';
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

  @Input() contestId: number;
  @Output() workCreated = new EventEmitter<boolean>();

  selectedFile: File = null;

  onFileSelected(event) {
    this.selectedFile = <File>event.target.files[0];
  }


  public addWork(title: string, description: string, source: string) {

    let formData: FormData = new FormData();
    formData.append('file', this.selectedFile, this.selectedFile.name);
    this.contestsService.UploadFile(formData).subscribe(result => {
      console.log(result);
      this.contestsService.CreateWork(title, description, result.result, this.contestId)
        .subscribe(res => {
          console.log(res); this.workCreated.next(true)});
    });
  }
}
