import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { rxResource } from '@angular/core/rxjs-interop';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { SearchQuery } from '@app-types/search-query';
import { VenueService } from '../venue.service';

@Component({
  selector: 'app-search',
  imports: [PageHeaderComponent,RouterLink],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  readonly #venueSvc = inject(VenueService);

  protected readonly venues = rxResource({
    request: () => new SearchQuery(),
    loader: (params) => this.#venueSvc.search(params.request),
  });
}
