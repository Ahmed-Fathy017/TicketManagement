import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TicketService } from '../../services/ticket.service';

@Component({
  selector: 'app-ticket-create',
  templateUrl: './ticket-create.component.html',
  styleUrls: ['./ticket-create.component.css'],
  standalone: false
})
export class TicketCreateComponent implements OnInit {
  ticketForm!: FormGroup;
  isLoading = false;
  message = '';
  messageType = '';

  // Hardcoded options for dropdowns
  governorates = [
    'Cairo', 'Alexandria', 'Giza', 'Qalyubia', 'Port Said', 
    'Suez', 'Luxor', 'Aswan', 'Sharm El Sheikh', 'Hurghada'
  ];

  cities = [
    'Downtown', 'Maadi', 'Heliopolis', 'Zamalek', 'Nasr City',
    '6th of October', 'New Cairo', 'Shoubra', 'Ain Shams', 'El Mokattam'
  ];

  districts = [
    'District 1', 'District 2', 'District 3', 'District 4', 'District 5',
    'District 6', 'District 7', 'District 8', 'District 9', 'District 10'
  ];

  constructor(
    private fb: FormBuilder,
    private ticketService: TicketService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.initForm();
  }

  onAddClick(event: any) {
    this.router.navigate(['/tickets'])
  }

  private initForm(): void {
    this.ticketForm = this.fb.group({
      phoneNumber: ['', [Validators.required, Validators.pattern(/^[0-9+\-\s()]+$/)]],
      governorate: ['', Validators.required],
      city: ['', Validators.required],
      district: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.ticketForm.valid) {
      this.isLoading = true;
      this.message = '';
      
      const request = this.ticketForm.value;
      
      this.ticketService.createTicket(request).subscribe({
        next: (result) => {
          this.isLoading = false;
          if (result.status === 'Success') {
            this.message = 'Ticket created successfully!';
            this.messageType = 'success';
            this.ticketForm.reset();
            setTimeout(() => {
              this.router.navigate(['/tickets']);
            }, 2000);
          } else {
            this.message = result.message || 'Failed to create ticket';
            this.messageType = 'error';
          }
        },
        error: (error) => {
          this.isLoading = false;
          this.message = 'An error occurred while creating the ticket';
          this.messageType = 'error';
          console.error('Error creating ticket:', error);
        }
      });
    } else {
      this.markFormGroupTouched();
    }
  }

  private markFormGroupTouched(): void {
    Object.keys(this.ticketForm.controls).forEach(key => {
      const control = this.ticketForm.get(key);
      control?.markAsTouched();
    });
  }

  getErrorMessage(controlName: string): string {
    const control = this.ticketForm.get(controlName);
    if (control?.errors && control.touched) {
      if (control.errors['required']) {
        return `${controlName} is required`;
      }
      if (control.errors['pattern']) {
        return 'Please enter a valid phone number';
      }
    }
    return '';
  }
} 