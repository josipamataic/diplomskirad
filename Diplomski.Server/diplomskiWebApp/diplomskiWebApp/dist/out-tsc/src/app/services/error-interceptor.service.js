import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
let ErrorInterceptorService = class ErrorInterceptorService {
    constructor(toastrService) {
        this.toastrService = toastrService;
    }
    intercept(request, next) {
        return next.handle(request).pipe(retry(1), catchError((err) => {
            let message = "";
            if (err.status === 401) {
                //refresh token or navigate to login
                message = "Potrebno je prijaviti se";
            }
            else if (err.status === 404) {
                //some custom message
                message = "404";
            }
            else if (err.status === 400) {
                //some message
                message = "400";
            }
            else {
                //global message for error
                message = "Neočekivana pogreška";
            }
            this.toastrService.error(message);
            return throwError(err);
        }));
    }
};
ErrorInterceptorService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], ErrorInterceptorService);
export { ErrorInterceptorService };
//# sourceMappingURL=error-interceptor.service.js.map