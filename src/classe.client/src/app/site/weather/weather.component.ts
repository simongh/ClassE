import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { PageHeaderComponent } from '@components/page-header/page-header.component';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-weather',
  imports: [PageHeaderComponent],
  templateUrl: './weather.component.html',
  styleUrl: './weather.component.css',
})
export class WeatherComponent {
  readonly #client = inject(HttpClient);

  protected readonly forecasts = rxResource({
    loader: () => {
      return this.#client.get<WeatherForecast[]>('/weatherforecast');
    },
  });
}
