import { AccordionModule } from '../../projects/ng-uikit-pro-standard/src/lib/pro/accordion';
import { WavesModule } from '../../projects/ng-uikit-pro-standard/src/lib/free/waves';
import { SidenavModule } from '../../projects/ng-uikit-pro-standard/src/lib/pro/sidenav';
import { BrowserModule } from '@angular/platform-browser';

import { MDBSpinningPreloader } from '../../projects/ng-uikit-pro-standard/src/lib/pro/preloader';

import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastModule, ToastService } from '../../projects/ng-uikit-pro-standard/src/lib/pro/alerts';
import { MDBBootstrapModulesPro } from '../../projects/ng-uikit-pro-standard/src/lib/mdb.module';
import { AppRoutingModule } from './app.routing.module';
import { JarwisService } from './_services/authentication/jarwis.service';
import { BeforeLoginService } from './_services/authentication/before-login.service';
import { TokenService } from './_services/authentication/token.service';
import { AfterLoginService } from './_services/authentication/after-login.service';
import { AuthService } from './_services/authentication/auth.service';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    MDBBootstrapModulesPro.forRoot(),
    ToastModule.forRoot(),
    FormsModule,
    BrowserAnimationsModule,
    SidenavModule, WavesModule, AccordionModule,
    AppRoutingModule
  ],
  providers: [

    MDBSpinningPreloader,
    ToastService,
    JarwisService,
    BeforeLoginService,
    AfterLoginService,
    TokenService,
    AuthService
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
