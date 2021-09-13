import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnbimaSearchComponent } from './anbima-search/anbima-search.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'anbima-search'},
  {path: 'anbima-search', component: AnbimaSearchComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
