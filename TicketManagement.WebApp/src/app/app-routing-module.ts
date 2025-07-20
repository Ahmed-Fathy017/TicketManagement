import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TicketListComponent } from './components/ticket-list/ticket-list.component';

const routes: Routes = [
  { path: '', component: TicketListComponent },
  { path: 'tickets', component: TicketListComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
