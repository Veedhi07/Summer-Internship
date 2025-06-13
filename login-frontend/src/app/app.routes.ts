import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AdminDashboardComponent } from './dashboard-admin/dashboard-admin.component';
import { UserDashboardComponent } from './dashboard-user/dashboard-user.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'admin-dashboard', component: AdminDashboardComponent },
  { path: 'user-dashboard', component: UserDashboardComponent }
];
