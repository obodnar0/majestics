import { Component, OnInit, Injectable } from '@angular/core';

import { AuthorizeService } from '../../api-authorization/authorize.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { map, tap } from 'rxjs/operators';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}


var modal = document.getElementById('id01');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}


//------------------------------- LOGIN SCRIPT ------------------------------------

@Component({
    selector: 'app-login-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class LoginMenuComponent implements OnInit {
    public isAuthenticated: Observable<boolean>;
    public userName: Observable<string>;

    constructor(private authorizeService: AuthorizeService) { }

    ngOnInit() {
        this.isAuthenticated = this.authorizeService.isAuthenticated();
        this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    }
}


//--------------------------------- LOGIK SCRIPT ---------------------------------

//class AuthService {

//    isAuthenticated = new BehaviorSubject<boolean>(false);

//    constructor() {
//        const authenticated = !!JSON.parse(localStorage.getItem('currentUser'));
//        this.isAuthenticated.next(authenticated);
//    }

//    login() {
//        this.isAuthenticated.next(true);
//    }

//    logout() {
//        this.isAuthenticated.next(false);
//    }

//}

////------------

//class HeaderComponent implements OnInit {
//    [x: string]: any;

//    public currentUser: any;
//    public isAuthenticated$ = this.auth.isAuthenticated$;

//    private() { }

//    ngOnInit() {
//        this.isAuthenticated$.subscribe(authenticated => {
//            if (authenticated) {
//                this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
//            } else {
//                this.currentUser = null;
//            }
//        });
//    }

//}


//-------------------------------------------------------------------------------------------------------------


//@Injectable()
//export class Authentication {

//    isAuthenticated = new BehaviorSubject<boolean>(false);

//    login() {
//        localStorage.setItem('access_token', 'true');
//        this.isAuthenticated.next(true);
//    }

//}

//@Component({
//    selector: 'nav-menu',
//    templateUrl: 'nav-menu.component.html'
//})
//export class navigation {

//    private isAuthenticated: boolean;

//    constructor(public authService: Authentication) {
//        this.authService.isAuthenticated
//            .subscribe(isAuthenticated => this.isAuthenticated = isAuthenticated)
//    }

//}


