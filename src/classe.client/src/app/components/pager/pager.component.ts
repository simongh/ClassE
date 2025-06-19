import { NgClass } from '@angular/common';
import { Component, computed, input } from '@angular/core';
import { RouterLink } from '@angular/router';

import { SearchQuery } from '@app-types/search-query';

import { SvgComponent } from '../svg.component';

@Component({
  selector: 'app-pager',
  imports: [NgClass, RouterLink, SvgComponent],
  templateUrl: './pager.component.html',
  styleUrl: './pager.component.css',
})
export class PagerComponent {
  public readonly total = input(0);

  public readonly query = input<SearchQuery>(new SearchQuery());

  public readonly offset = computed(() => this.query().offset ?? 0);

  public readonly limit = computed(() => this.query().limit ?? 20);

  protected readonly current = computed(() => this.offset() / this.limit());

  protected readonly pages = computed(() => new Array<number>(Math.ceil(this.total() / this.limit())));

  protected readonly showPrevious = computed(() => this.offset() > 0);

  protected readonly showNext = computed(() => this.offset() + this.limit() < this.total());
}
