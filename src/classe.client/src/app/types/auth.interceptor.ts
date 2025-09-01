import { HttpEvent, HttpHandlerFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { Observable } from 'rxjs';

import { AuthService } from './auth.service';

export function authInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> {
    const currentUser = inject(AuthService);

    const authReq = req.clone({
        setHeaders: {
            Authorization: 'Bearer ' + currentUser.token(),
        },
    });

    return next(authReq);
}