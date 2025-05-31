import { Component, OnInit } from '@angular/core';
import { OrderService, Order } from '../../services/order.service';
import { Config } from 'datatables.net';
import 'datatables.net';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  standalone: false
})
export class OrderListComponent implements OnInit {
  orders: Order[] = [];
  hourlySalesData: any[] = [];
  top10Pizzas: any[] = [];
  view: [number, number] = [600, 400];

  // Options for the chart
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'Hour of Day';
  showYAxisLabel = true;
  yAxisLabel = 'Total Sales';
  autoScale = true;


  xAxisLabelTop10 = "Sales Count";
  yAxisLabelTop10 = "Pizza Type";

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.orderService.getOrders().subscribe((data) => {
      console.log(data);
      this.orders = data;

      setTimeout(() => {
        $("#ordersTable").DataTable();
      }, 1000);

    });

    this.orderService.getPeakTimes().subscribe((data) => {
      console.log(data);
      // Transform data for ngx-charts
      this.hourlySalesData = [
        {
          name: 'Sales by Hour',
          series: data.map(item => ({
            name: `${item.hour}:00`,
            value: item.totalSales
          }))
        }
      ];
    });

    this.orderService.getTop10BestSellers().subscribe((data) => {
      console.log(data);
      this.top10Pizzas = data.map(item => ({
        name: item.pizzaId,
        value: item.salesCount
      }));
    });
  }
}
