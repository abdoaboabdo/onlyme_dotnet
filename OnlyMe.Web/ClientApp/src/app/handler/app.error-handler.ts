import { ErrorHandler, NgZone, Inject, Injectable } from '@angular/core';
import { ToastService } from 'projects/ng-uikit-pro-standard/src/public_api';

@Injectable()
export class AppErrorHandler implements ErrorHandler{
    constructor(
        private ngZone:NgZone,
        @Inject(ToastService) private toastService:ToastService
        ) {}
    handleError(error: any): void {
        this.ngZone.run(()=>{
            console.log(error);
            this.toastService.error('An unExpected error happened','Error')
        });
    }

}