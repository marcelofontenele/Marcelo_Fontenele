import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../dto/user';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor(
        private http: HttpClient) { }

    public getUser() : Observable<User>{
        return this.http.get<User>(`${environment.ms_user_api}/v1/user`);
    }
}
