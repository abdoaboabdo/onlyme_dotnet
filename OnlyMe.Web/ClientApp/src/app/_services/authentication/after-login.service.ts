import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { TokenService } from './token.service';
import { Observable } from 'rxjs';

@Injectable()
export class AfterLoginService implements CanActivate {

  canActivate(_route: ActivatedRouteSnapshot, _state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
    return this.Token.loggedIn();
  }
  constructor(private Token: TokenService) { }

}
