import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FullDashboardComponent } from '../layouts/dashboard/full-dashboard/full-dashboard.component';
import { HomeDashboardComponent } from './home-dashboard/home-dashboard.component';

const routes: Routes = [
  {path: '', component: FullDashboardComponent, children: [
    {path: '', component: HomeDashboardComponent},
    {
      path: 'customer',
      loadChildren: () => import(`./customer/customer.module`).then(m => m.CustomerModule)
    },
    {
      path: 'masterdata',
      loadChildren: () => import(`./masterdata/masterdata.module`).then(m => m.MasterdataModule)
    },
    {
      path: 'vendor',
      loadChildren: () => import(`./vendor/vendor.module`).then(m => m.VendorModule)
    },
    {
      path: 'invoice',
      loadChildren: () => import(`./invoice/invoice.module`).then(m => m.InvoiceModule)
    }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
