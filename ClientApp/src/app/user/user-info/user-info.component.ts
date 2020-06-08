import { Component, OnInit } from '@angular/core';
import { UsersService } from "../../services/users.service";

@Component({
  selector: 'user-info-component',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {

  constructor(private userService: UsersService) {
  }

  public user: any = {};

  public saveUserInfo(name: string, surname: string, phone: string, address: string, email: string, institution: string, birthDate: Date) {
    this.userService.updateUserInfo(name, surname, phone, address, email, institution, birthDate).subscribe(res => this.user = JSON.parse(res.result));
  }

  public getUserInfo() {
    this.userService.getUserInfo().subscribe(res => this.user = JSON.parse(res.result));
  }

  ngOnInit() {
     this.getUserInfo();
  }
}
