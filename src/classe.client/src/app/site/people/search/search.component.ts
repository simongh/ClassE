import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { injectQueryParams } from 'ngxtension/inject-query-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { PagerComponent } from '@components/pager/pager.component';
import { SorterComponent } from '@components/sorter/sorter.component';
import { PlusIcon } from '@components/svg';

import { PersonService } from '@api/people/person.service';
import { withDefaultFilters } from '@app-types/search-query';

@Component({
  selector: 'app-people',
  imports: [PageHeaderComponent, RouterLink, PagerComponent, SorterComponent, CardsModule, PlusIcon],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  readonly #peopleSvc = inject(PersonService);

  readonly #router = inject(Router);

  protected readonly qry = injectQueryParams((p) => withDefaultFilters(p));

  protected readonly people = this.#peopleSvc.search(() => this.qry());

  protected viewPerson(id: number) {
    this.#router.navigateByUrl(`/people/${id}`);
  }
}
