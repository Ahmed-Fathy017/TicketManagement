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
  status: number; // 0=Success, 1=Failure, 2=NotFound, 3=ValidationError
  data: T;
  message: string | null;
}

// Service Result Status Constants
export const ServiceResultStatus = {
  Success: 0,
  Failure: 1,
  NotFound: 2,
  ValidationError: 3
} as const; 