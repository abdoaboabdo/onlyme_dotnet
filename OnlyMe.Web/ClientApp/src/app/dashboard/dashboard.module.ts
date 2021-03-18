import { MDBBootstrapModulesPro } from '../../../projects/ng-uikit-pro-standard/src/lib/mdb.module';
import { SidebarComponent } from '../layouts/dashboard/full-dashboard/sidebar/sidebar.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { HomeDashboardComponent } from './home-dashboard/home-dashboard.component';
import { FullDashboardComponent } from '../layouts/dashboard/full-dashboard/full-dashboard.component';
import { HeaderDashboardComponent } from '../layouts/dashboard/full-dashboard/header-dashboard/header-dashboard.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [SidebarComponent,
    HeaderDashboardComponent,
    FullDashboardComponent,
    HomeDashboardComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MDBBootstrapModulesPro.forRoot(),
  ]
})
export class DashboardModule { }
