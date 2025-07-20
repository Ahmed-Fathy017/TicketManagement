import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject, takeUntil, interval } from 'rxjs';
import { TicketService } from '../../services/ticket.service';
import { Ticket, PaginatedListRequest, CreateTicketRequest, ServiceResultStatus } from '../../models/ticket.interface';

@Component({
  selector: 'app-ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: ['./ticket-list.component.css'],
  standalone: false
})
export class TicketListComponent implements OnInit, OnDestroy {
  tickets: Ticket[] = [];
  totalCount = 0;
  currentPage = 1;
  pageSize = 5; // Static page size of 5
  isLoading = false;
  message = '';
  messageType = '';
  
  // Modal properties
  showCreateModal = false;
  createForm!: FormGroup;
  isSubmitting = false;
  createMessage = '';
  createMessageType = '';
  
  private destroy$ = new Subject<void>();
  private refreshInterval: any;

  constructor(
    private ticketService: TicketService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.initForm();
    this.loadTickets();
    // this.startAutoRefresh();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
    if (this.refreshInterval) {
      clearInterval(this.refreshInterval);
    }
  }

  loadTickets(): void {
    this.isLoading = true;
    this.message = '';

    const request: PaginatedListRequest = {
      pageNumber: this.currentPage,
      pageSize: this.pageSize
    };

    this.ticketService.getTicketsPaginated(request)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (result) => {
          this.isLoading = false;
          if (result.status === ServiceResultStatus.Success && result.data) {
            this.tickets = result.data.items;
            this.totalCount = result.data.totalCount;
          } else {
            this.showMessage(result.message || 'Failed to load tickets', 'error');
          }
        },
        error: (error) => {
          this.isLoading = false;
          this.showMessage('An error occurred while loading tickets', 'error');
          console.error('Error loading tickets:', error);
        }
      });
  }

  onPageChange(page: number): void {
    this.currentPage = page;
    this.loadTickets();
  }



  handleTicket(ticket: Ticket): void {
    if (ticket.isHandled) {
      return; // Already handled
    }

    this.ticketService.markTicketAsHandled(ticket.id)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (result) => {
          if (result.status === ServiceResultStatus.Success) {
            // Update the ticket locally
            ticket.isHandled = true;
            this.showMessage('Ticket marked as handled successfully!', 'success');
          } else {
            this.showMessage(result.message || 'Failed to mark ticket as handled', 'error');
          }
        },
        error: (error) => {
          this.showMessage('An error occurred while handling the ticket', 'error');
          console.error('Error handling ticket:', error);
        }
      });
  }

  private showMessage(message: string, type: 'success' | 'error'): void {
    this.message = message;
    this.messageType = type;
    
    // Auto-hide after 4 seconds
    setTimeout(() => {
      this.message = '';
    }, 4000);
  }

  private showModalMessage(message: string, type: 'success' | 'error'): void {
    this.createMessage = message;
    this.createMessageType = type;
    
    // Auto-hide after 3 seconds
    setTimeout(() => {
      this.createMessage = '';
    }, 3000);
  }

  getTimeBasedStatus(ticket: Ticket): { status: string; color: string; backgroundColor: string } {
    const timeStatus = this.ticketService.calculateTimeBasedStatus(ticket.createdAt);
    
    // If ticket is already handled, show as handled
    if (ticket.isHandled) {
      return { 
        status: 'Handled', 
        color: 'white', 
        backgroundColor: '#28a745' 
      };
    }

    // Apply time-based status
    switch (timeStatus.color) {
      case 'red':
        return { 
          status: timeStatus.status, 
          color: 'white', 
          backgroundColor: '#dc3545' 
        };
      case 'blue':
        return { 
          status: timeStatus.status, 
          color: 'white', 
          backgroundColor: '#007bff' 
        };
      case 'green':
        return { 
          status: timeStatus.status, 
          color: 'white', 
          backgroundColor: '#28a745' 
        };
      case 'yellow':
        return { 
          status: timeStatus.status, 
          color: 'black', 
          backgroundColor: '#ffc107' 
        };
      default:
        return { 
          status: timeStatus.status, 
          color: 'black', 
          backgroundColor: '#f8f9fa' 
        };
    }
  }

  // Add Math reference for template
  protected readonly Math = Math;

  getTotalPages(): number {
    return Math.ceil(this.totalCount / this.pageSize);
  }

  getPageNumbers(): number[] {
    const totalPages = this.getTotalPages();
    const pages: number[] = [];
    
    // Show 5 pages around current page (2 before, current, 2 after)
    const startPage = Math.max(1, this.currentPage - 2);
    const endPage = Math.min(totalPages, this.currentPage + 2);
    
    for (let i = startPage; i <= endPage; i++) {
      pages.push(i);
    }
    
    return pages;
  }

  formatDate(dateString: string): string {
    return new Date(dateString).toLocaleString();
  }

  canHandleTicket(ticket: Ticket): boolean {
    if (ticket.isHandled) {
      return false;
    }
    
    const timeStatus = this.ticketService.calculateTimeBasedStatus(ticket.createdAt);
    return timeStatus.color !== 'red'; // Don't allow handling if already "Handled" (60+ minutes)
  }

  // private startAutoRefresh(): void {
  //   // Refresh every 30 seconds to update time-based statuses
  //   this.refreshInterval = setInterval(() => {
  //     this.loadTickets();
  //   }, 30000);
  // }

  initForm(): void {
    this.createForm = this.fb.group({
      phoneNumber: ['', [Validators.required, Validators.pattern(/^[0-9+\-\s()]+$/)]],
      governorate: ['', Validators.required],
      city: ['', Validators.required],
      district: ['', Validators.required]
    });
  }

  openCreateModal(): void {
    this.showCreateModal = true;
    this.createForm.reset();
    this.createMessage = '';
    this.createMessageType = '';
  }

  closeCreateModal(): void {
    this.showCreateModal = false;
    this.createForm.reset();
    this.createMessage = '';
    this.createMessageType = '';
  }

  onSubmit(): void {
    if (this.createForm.valid) {
      this.isSubmitting = true;
      this.createMessage = '';

      const request: CreateTicketRequest = {
        phoneNumber: this.createForm.value.phoneNumber,
        governorate: this.createForm.value.governorate,
        city: this.createForm.value.city,
        district: this.createForm.value.district
      };

      this.ticketService.createTicket(request)
        .pipe(takeUntil(this.destroy$))
        .subscribe({
          next: (result) => {
            this.isSubmitting = false;
            if (result.status === ServiceResultStatus.Success) {
              this.showModalMessage('Ticket created successfully!', 'success');
              this.createForm.reset();
              
              // Close modal after 2 seconds and refresh the list
              setTimeout(() => {
                this.closeCreateModal();
                this.loadTickets();
              }, 2000);
            } else {
              this.showModalMessage(result.message || 'Failed to create ticket', 'error');
            }
          },
          error: (error) => {
            this.isSubmitting = false;
            this.showModalMessage('An error occurred while creating the ticket', 'error');
            console.error('Error creating ticket:', error);
          }
        });
    } else {
      this.markFormGroupTouched();
    }
  }

  isFieldInvalid(fieldName: string): boolean {
    const field = this.createForm.get(fieldName);
    return !!(field && field.invalid && (field.dirty || field.touched));
  }

  getFieldError(fieldName: string): string {
    const field = this.createForm.get(fieldName);
    if (field && field.errors) {
      if (field.errors['required']) {
        return `${fieldName.charAt(0).toUpperCase() + fieldName.slice(1)} is required`;
      }
      if (field.errors['pattern']) {
        return 'Please enter a valid phone number';
      }
    }
    return '';
  }

  private markFormGroupTouched(): void {
    Object.keys(this.createForm.controls).forEach(key => {
      const control = this.createForm.get(key);
      control?.markAsTouched();
    });
  }

  navigateToCreate(): void {
    this.openCreateModal();
  }
} 