import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection!: signalR.HubConnection;
  private isConnected = false;

  startConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44308/hubs/dataChange', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection.start()
      .then(() => {
        console.log('SignalR connected successfully.');
        this.isConnected = true;
      })
      .catch(err => {
        console.error('SignalR connection error:', err);
        this.isConnected = false;
      });

    // Handle connection state changes
    this.hubConnection.onreconnecting(() => {
      console.log('SignalR reconnecting...');
      this.isConnected = false;
    });

    this.hubConnection.onreconnected(() => {
      console.log('SignalR reconnected.');
      this.isConnected = true;
    });

    this.hubConnection.onclose(() => {
      console.log('SignalR connection closed.');
      this.isConnected = false;
    });
  }

  onTicketCreated(callback: (ticket: any) => void): void {
    this.hubConnection.on('TicketCreated', (ticket) => {
      console.log('Received TicketCreated event:', ticket);
      callback(ticket);
    });
  }

  isConnectionActive(): boolean {
    return this.isConnected;
  }

  stopConnection(): void {
    if (this.hubConnection) {
      this.hubConnection.stop();
    }
  }
}
