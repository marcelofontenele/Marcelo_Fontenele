import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor{

    constructor(private injector: Injector) { }
    
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
        const auth: AuthService = this.injector.get(AuthService);
        
        request = request.clone({
            setHeaders: {
                'content-type': 'application/json'
            }
        });

        if (auth.isAuthenticated()) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${auth.credentials.access_token}`,
                    'Cache-control': 'no-cache, no-store',
                    'content-type': 'application/json',
                    Expires: '0',
                    Pragma: 'no-cache'
                }
            });
        }

        return next.handle(request);
    }
}
