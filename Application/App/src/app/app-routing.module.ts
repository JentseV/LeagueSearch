import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchComponent } from './components/search/search.component';
import { ProfileComponent } from './components/profile/profile.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guard/auth.guard';
import { CallbackauthComponent } from './components/callbackauth/callbackauth.component';

const routes: Routes = [
  {path: '', redirectTo: '/search', pathMatch: 'full' },
  {path:'search',component:SearchComponent,canActivate:[AuthGuard]},
  {path:"profile", component:ProfileComponent},
  {path:"login",component:LoginComponent},
  {path:"callbackauth",component:CallbackauthComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
