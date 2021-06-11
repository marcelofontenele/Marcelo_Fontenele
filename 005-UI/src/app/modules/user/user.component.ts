import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/dto/user';
import { UserService } from 'src/app/services/user.service';

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html'
})
export class UserComponent implements OnInit {

    user: User;

    constructor(private userService: UserService) { }

    ngOnInit(): void {
        this.getUser();
    }

    getUser() {
        this.userService.getUser()
            .subscribe(_user => {
                this.user = _user;
            })
    }

}
