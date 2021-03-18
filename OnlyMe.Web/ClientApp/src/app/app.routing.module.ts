import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';


const AppRoutes: Routes = [
    {
        path: '',
        loadChildren: () => import(`../app/frontend/frontend.module`).then(m => m.FrontendModule)
    },
    {
        path: 'dashboard',
        loadChildren: () => import(`../app/dashboard/dashboard.module`).then(m => m.DashboardModule)
    }
];

@NgModule({
    imports: [RouterModule.forRoot(AppRoutes, {enableTracing: false})],
    exports: [RouterModule]
})
export class AppRoutingModule {}
