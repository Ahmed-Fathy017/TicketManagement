import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { 
  Ticket, 
  CreateTicketRequest, 
  PaginatedListRequest, 
  PaginatedListResponse, 
  ServiceResult 
} from '../models/ticket.interface';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  private readonly baseUrl = 'https://localhost:44308/api/tickets'; // Adjust port as needed

  constructor(private http: HttpClient) { }

  createTicket(request: CreateTicketRequest): Observable<ServiceResult<string>> {
    return this.http.post<ServiceResult<string>>(`${this.baseUrl}`, request);
  }

  getTicketsPaginated(request: PaginatedListRequest): Observable<ServiceResult<PaginatedListResponse<Ticket>>> {
    const params = new HttpParams()
      .set('pageNumber', request.pageNumber.toString())
      .set('pageSize', request.pageSize.toString());

    return this.http.get<ServiceResult<PaginatedListResponse<Ticket>>>(`${this.baseUrl}`, { params });
  }

  markTicketAsHandled(ticketId: string): Observable<ServiceResult<string>> {
    return this.http.patch<ServiceResult<string>>(`${this.baseUrl}/${ticketId}`, {});
  }

  // Helper method to calculate time-based status
  calculateTimeBasedStatus(createdAt: string): { status: string; color: string } {
    // Parse UTC date and convert to local time for accurate calculation
    const created = new Date(createdAt + 'Z'); // Ensure it's treated as UTC
    const now = new Date();
    const diffInMinutes = Math.floor((now.getTime() - created.getTime()) / (1000 * 60));

    if (diffInMinutes >= 60) {
      return { status: '60+ minutes', color: 'red' };
    } else if (diffInMinutes >= 45) {
      return { status: 'Urgent', color: 'blue' };
    } else if (diffInMinutes >= 30) {
      return { status: 'Medium Priority', color: 'green' };
    } else if (diffInMinutes >= 15) {
      return { status: 'Low Priority', color: 'yellow' };
    } else {
      return { status: 'New', color: 'white' };
    }
  }
} 