import { Component, input } from '@angular/core';
import { RouterLink } from '@angular/router';

import { SearchQuery } from '@app-types/search-query';

@Component({
  selector: 'app-sorter',
  imports: [RouterLink],
  templateUrl: './sorter.component.html',
  styleUrl: './sorter.component.css',
})
export class SorterComponent {
  public readonly query = input.required<SearchQuery>();

  public readonly field = input.required<string>();
}
