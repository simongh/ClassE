import { Component, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { RouterLink } from '@angular/router';
import { SearchQuery } from '@app-types/search-query';
import { PageHeaderComponent } from "@components/page-header/page-header.component";
import { ClassesService } from '../classes.service';

@Component({
  selector: 'app-search',
  imports: [PageHeaderComponent,RouterLink],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  readonly #classSvc = inject(ClassesService);

  protected readonly classes = rxResource({
    request: () => ({ all: false, ...new SearchQuery() }),
    loader: (params) => this.#classSvc.search(params.request),
  });
}
