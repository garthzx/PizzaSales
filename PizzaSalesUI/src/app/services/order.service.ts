import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Order {
  id: number;
  date: string;
  time: string;
  orderDetails: OrderDetail[]
}

export interface OrderDetail {
  id: number,
  pizza: Pizza,
  quantity: number
}

export interface Pizza {
  id: string,
  pizzaType: PizzaType,
  price: number,
  size: string
}
export interface PizzaType {
  id: string,
  category: string,
  ingredients: string,
  name: string
}

export interface PeakTime {
  totalSales: number,
  hour: number
}

export interface BestSeller {
  pizzaId: string,
  salesCount: number
}

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  private apiUrl = 'https://localhost:44398/api'; // Adjust if needed

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.apiUrl + "/orders");
  }

  getPeakTimes(): Observable<PeakTime[]> {
    return this.http.get<PeakTime[]>(this.apiUrl + "/orders/peak-time");
  }

  getTop10BestSellers(): Observable<BestSeller[]> {
    return this.http.get<BestSeller[]>(this.apiUrl + "/orders/top-10");
  }
}
