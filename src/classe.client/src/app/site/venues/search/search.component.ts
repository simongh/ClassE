import { Component, DestroyRef, inject } from '@angular/core';
import { rxResource, takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { RouterLink } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { injectQueryParams } from 'ngxtension/inject-query-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { PagerComponent } from '@components/pager/pager.component';
import { SorterComponent } from '@components/sorter/sorter.component';
import { SvgComponent } from '@components/svg.component';

import { VenueService } from '@api/venues/venue.service';
import { withDefaultFilters } from '@app-types/search-query';

import { EditModalComponent } from '../edit-modal/edit-modal.component';

@Component({
  selector: 'app-search',
  imports: [PageHeaderComponent, RouterLink, PagerComponent, SorterComponent, CardsModule, SvgComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  readonly #venueSvc = inject(VenueService);

  readonly #modalSvc = inject(NgbModal);

  readonly #destroyed = inject(DestroyRef);

  protected readonly qry = injectQueryParams((p) => withDefaultFilters(p));

  protected readonly venues = rxResource({
    request: () => this.qry(),
    loader: (params) => this.#venueSvc.search(params.request),
  });

  protected open(id = 0) {
    const modal = this.#modalSvc.open(EditModalComponent);

    modal.closed.pipe(takeUntilDestroyed(this.#destroyed)).subscribe(() => this.venues.reload());

    modal.componentInstance.load(id);
  }
}
