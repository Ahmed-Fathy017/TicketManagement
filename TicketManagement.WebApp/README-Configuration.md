# Configuration Management

This document explains how backend URLs and other configuration settings are managed in the Angular frontend.

## 📁 File Structure

```
src/
├── app/
│   └── services/
│       ├── config.service.ts          # Centralized configuration service
│       ├── ticket.service.ts          # Uses ConfigService for API URLs
│       └── signal-r-service.ts        # Uses ConfigService for SignalR URL
├── environments/
│   ├── environment.ts                 # Development environment
│   └── environment.prod.ts            # Production environment
└── app.config.ts                      # App-level configuration exports
```

## 🔧 Configuration Service

The `ConfigService` provides a centralized way to access all configuration settings:

```typescript
@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  get apiBaseUrl(): string              // Base API URL
  get signalRHubUrl(): string           // SignalR Hub URL
  get ticketsApiUrl(): string           // Full tickets API URL
  get isProduction(): boolean           // Environment flag
  getApiUrl(endpoint: string): string   // Helper for any endpoint
  updateConfig(config): void            // Runtime configuration update
}
```

## 🌍 Environment Configuration

### Development Environment (`environment.ts`)
```typescript
export const environment = {
  production: false,
  apiBaseUrl: 'https://localhost:44308',
  signalRHubUrl: 'https://localhost:44308/hubs/dataChange',
  apiEndpoints: {
    tickets: '/api/tickets'
  }
};
```

### Production Environment (`environment.prod.ts`)
```typescript
export const environment = {
  production: true,
  apiBaseUrl: 'https://your-production-api-url.com',
  signalRHubUrl: 'https://your-production-api-url.com/hubs/dataChange',
  apiEndpoints: {
    tickets: '/api/tickets'
  }
};
```

## 🚀 Usage Examples

### In Services
```typescript
constructor(
  private http: HttpClient,
  private configService: ConfigService
) {
  this.baseUrl = this.configService.ticketsApiUrl;
}
```

### In Components
```typescript
constructor(private configService: ConfigService) {
  if (this.configService.isProduction) {
    // Production-specific logic
  }
}
```

## ⚙️ Build Configuration

The `angular.json` file is configured to automatically replace environment files:

```json
{
  "fileReplacements": [
    {
      "replace": "src/environments/environment.ts",
      "with": "src/environments/environment.prod.ts"
    }
  ]
}
```

## 🔄 Environment Switching

### Development
```bash
ng serve
# Uses environment.ts
```

### Production
```bash
ng build --configuration=production
# Uses environment.prod.ts
```

## 📝 Benefits

1. **Centralized Management**: All URLs in one place
2. **Environment-Specific**: Different configs for dev/prod
3. **Type Safety**: TypeScript interfaces for configuration
4. **Runtime Updates**: Can update config at runtime if needed
5. **Easy Maintenance**: Change URLs in one place
6. **Testing Friendly**: Easy to mock or override configuration

## 🔧 Customization

To add new configuration settings:

1. Update the `Environment` interface in `config.service.ts`
2. Add the setting to both environment files
3. Add a getter method to `ConfigService`
4. Use the new setting in your services/components

## 🧪 Testing

The `ConfigService` can be easily mocked in tests:

```typescript
const mockConfigService = {
  apiBaseUrl: 'http://localhost:3000',
  ticketsApiUrl: 'http://localhost:3000/api/tickets',
  // ... other properties
};
``` 