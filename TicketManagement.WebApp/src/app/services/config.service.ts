import { Injectable } from '@angular/core';

// Define the environment interface
interface Environment {
  production: boolean;
  apiBaseUrl: string;
  signalRHubUrl: string;
  apiEndpoints: {
    tickets: string;
  };
}

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  
  // Default development environment
  private environment: Environment = {
    production: false,
    apiBaseUrl: 'https://localhost:44308',
    signalRHubUrl: 'https://localhost:44308/hubs/dataChange',
    apiEndpoints: {
      tickets: '/api/tickets'
    }
  };

  constructor() {
    // In production, this would be replaced by the build process
    // For now, we'll use the default development values
  }
  
  get apiBaseUrl(): string {
    return this.environment.apiBaseUrl;
  }

  get signalRHubUrl(): string {
    return this.environment.signalRHubUrl;
  }

  get ticketsApiUrl(): string {
    return `${this.environment.apiBaseUrl}${this.environment.apiEndpoints.tickets}`;
  }

  get isProduction(): boolean {
    return this.environment.production;
  }

  // Helper method to get full API URL for any endpoint
  getApiUrl(endpoint: string): string {
    return `${this.environment.apiBaseUrl}${endpoint}`;
  }

  // Method to update configuration (useful for testing or runtime configuration)
  updateConfig(config: Partial<Environment>): void {
    this.environment = { ...this.environment, ...config };
  }
} 