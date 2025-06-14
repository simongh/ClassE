import { Component, inject, numberAttribute } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { injectParams } from 'ngxtension/inject-params';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { PeopleService } from '../people.service';

@Component({
  selector: 'app-view',
  imports: [PageHeaderComponent],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css',
})
export class ViewComponent {
  readonly #svc = inject(PeopleService);

  protected readonly id = injectParams('id', { parse: numberAttribute });

  protected readonly person = rxResource({
    request: () => this.id()!,
    loader: (params) => this.#svc.get(params.request),
  });
}
