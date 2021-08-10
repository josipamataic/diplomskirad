import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let TokenInterceptorService = class TokenInterceptorService {
    constructor(authService) {
        this.authService = authService;
    }
    intercept(request, next) {
        request = request.clone({
            setHeaders: {
                Authorization: `Bearer ${this.authService.getToken()}`
            }
        });
        return next.handle(request);
    }
};
TokenInterceptorService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], TokenInterceptorService);
export { TokenInterceptorService };
//# sourceMappingURL=token-interceptor.service.js.map