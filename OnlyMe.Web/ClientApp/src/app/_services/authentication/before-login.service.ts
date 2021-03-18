import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';

@Injectable()
export class BeforeLoginService implements CanActivate {

  canActivate(_route: ActivatedRouteSnapshot, _state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
    return !this.Token.loggedIn();
  }
  constructor(private Token: TokenService) { }

}
