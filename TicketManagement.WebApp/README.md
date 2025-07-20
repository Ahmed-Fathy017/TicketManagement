# Ticket Management System - Angular Frontend

This is the Angular frontend for the Ticket Management System, built with Angular 20 and following modern best practices.

## Features

### 🎫 Ticket Creation
- **Reactive Form** with validation
- **Required Fields**: Phone Number, Governorate, City, District
- **Static Dropdowns** with hardcoded options
- **Success/Error Messages** after submission
- **Auto-navigation** to ticket list after successful creation

### 📋 Ticket Listing with Pagination
- **Responsive Table** displaying all ticket information
- **Backend Pagination** with configurable page sizes (5, 10, 20, 50)
- **Page Navigation** with Previous/Next buttons and page numbers
- **Real-time Updates** with 30-second auto-refresh

### ⏰ Time-Based Status System
- **Automatic Status Calculation** based on creation time:
  - **Yellow** (≥ 15 minutes): Low Priority
  - **Green** (≥ 30 minutes): Medium Priority  
  - **Blue** (≥ 45 minutes): Urgent
  - **Red** (≥ 60 minutes): Handled (Auto-handled)
- **Visual Color Coding** with background colors and status badges
- **Handle Button** for manual ticket handling

### 🎨 Modern UI/UX
- **Clean, Responsive Design** with modern styling
- **Loading States** with spinners
- **Error Handling** with user-friendly messages
- **Mobile-Friendly** responsive layout

## Architecture

### Components
- **`TicketCreateComponent`**: Form for creating new tickets
- **`TicketListComponent`**: Table view with pagination and handling

### Services
- **`TicketService`**: Handles all API communication with the backend

### Models
- **`Ticket`**: Core ticket interface
- **`CreateTicketRequest`**: Request DTO for ticket creation
- **`PaginatedListRequest/Response`**: Pagination interfaces
- **`ServiceResult`**: Backend response wrapper

## API Integration

The frontend integrates with the following backend endpoints:

- `POST /api/tickets` - Create new ticket
- `GET /api/tickets` - Get paginated ticket list
- `PATCH /api/tickets/{id}` - Mark ticket as handled

## Getting Started

### Prerequisites
- Node.js (v18 or higher)
- Angular CLI (`npm install -g @angular/cli`)

### Installation
```bash
# Install dependencies
npm install

# Start development server
npm start
```

The application will be available at `http://127.0.0.1:4200`

### Build for Production
```bash
npm run build
```

## Configuration

### Backend URL
Update the `baseUrl` in `src/app/services/ticket.service.ts` to match your backend API URL:

```typescript
private readonly baseUrl = 'https://localhost:7001/api/tickets'; // Adjust port as needed
```

## Code Practices Implemented

✅ **Service Layer**: All API calls centralized in `TicketService`  
✅ **Reactive Forms**: Form validation and handling  
✅ **HttpClient**: Proper HTTP communication with parameters  
✅ **Angular Routing**: Clean URL structure (`/tickets`, `/tickets/create`)  
✅ **Async Pipe**: Proper subscription management with `takeUntil`  
✅ **Component Architecture**: Modular, reusable components  
✅ **TypeScript Interfaces**: Strong typing throughout  
✅ **Error Handling**: Comprehensive error management  
✅ **Responsive Design**: Mobile-friendly layout  

## File Structure

```
src/app/
├── components/
│   ├── ticket-create/
│   │   ├── ticket-create.component.ts
│   │   ├── ticket-create.component.html
│   │   └── ticket-create.component.css
│   └── ticket-list/
│       ├── ticket-list.component.ts
│       ├── ticket-list.component.html
│       └── ticket-list.component.css
├── models/
│   └── ticket.interface.ts
├── services/
│   └── ticket.service.ts
├── app.ts
├── app.html
├── app.css
├── app-module.ts
└── app-routing-module.ts
```

## Browser Support

- Chrome (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)

## Development Notes

- **Auto-refresh**: Tickets list refreshes every 30 seconds to update time-based statuses
- **Time Calculation**: Status colors are calculated client-side based on creation time
- **Form Validation**: Phone number accepts various formats (numbers, spaces, dashes, parentheses)
- **Pagination**: Smart pagination with configurable page sizes and navigation
- **Error Handling**: Comprehensive error handling with user-friendly messages
