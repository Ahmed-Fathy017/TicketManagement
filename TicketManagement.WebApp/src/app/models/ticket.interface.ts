export interface Ticket {
  id: string;
  phoneNumber: string;
  governorate: string;
  city: string;
  district: string;
  createdAt: string;
  isHandled: boolean;
}

export interface CreateTicketRequest {
  phoneNumber: string;
  governorate: string;
  district: string;
  city: string;
}

export interface PaginatedListRequest {
  pageNumber: number;
  pageSize: number;
}

export interface PaginatedListResponse<T> {
  items: T[];
  totalCount: number;
}

export interface ServiceResult<T> {
  status: 'Success' | 'Failure' | 'NotFound' | 'ValidationError';
  data: T;
  message: string | null;
} 