import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Credentials } from '../dto/credentials';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
    constructor(
        private http: HttpClient, 
        public jwtHelper: JwtHelperService) {   }

    public get credentials(): Credentials {
        return JSON.parse(sessionStorage.getItem('auth.credentials')) as Credentials;
    }

    public set credentials(value: Credentials) {
        sessionStorage.setItem('auth.credentials', JSON.stringify(value));
    } 

    public isAuthenticated(): boolean {
        if(!this.credentials) {
            return false;
        }

        return !this.jwtHelper.isTokenExpired(this.credentials.access_token);
    }

    public login(login: string, password: string): Observable<AuthService> {
        return new Observable<AuthService>((observable) => {

            let headers: HttpHeaders = new HttpHeaders();

            headers = headers.append(
                'Content-Type',
                'application/json'
            );
            
            this.credentials = null;

            this.http
                .post(
                    `${environment.ms_auth_api}/v1/auth`,
                    {
                        login, password
                    },
                    {
                        headers: headers,
                    }
                )
                .subscribe(
                    (response) => {
                        this.credentials = response as Credentials;

                        observable.next(this);
                    },
                    (error) => {
                        console.error('An error occurred', error);
                        
                        this.credentials = null;

                        observable.error(error);
                    },
                    () => {
                        observable.complete();
                    }
                );
        });
    }
  
}
