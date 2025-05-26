import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [],
})
export class AppComponent {
  readonly #httpClient = inject(HttpClient);

  protected readonly forecasts = toSignal(this.#httpClient.get<WeatherForecast[]>('/weatherforecast'));
}
