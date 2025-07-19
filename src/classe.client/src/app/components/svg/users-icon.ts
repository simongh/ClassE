import { Component, input, ViewEncapsulation } from '@angular/core';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'svg[users-icon]',
  template: `<svg:path stroke="none" d="M0 0h24v24H0z" fill="none" />
      <svg:path d="M9 7m-4 0a4 4 0 1 0 8 0a4 4 0 1 0 -8 0" />
      <svg:path d="M3 21v-2a4 4 0 0 1 4 -4h4a4 4 0 0 1 4 4v2" />
      <svg:path d="M16 3.13a4 4 0 0 1 0 7.75" />
      <svg:path d="M21 21v-2a4 4 0 0 0 -3 -3.85" />`,
  host: {
    '[attr.xmlns]': 'xmlns',
    '[attr.width]': 'width()',
    '[attr.height]': 'height()',
    '[attr.viewBox]': 'viewBox()',
    '[attr.fill]': 'fill()',
    stroke: 'currentColor',
    'stroke-width': '2',
    'stroke-linecap': 'round',
    'stroke-linejoin': 'round',
    class: 'icon icon-tabler icons-tabler-outline icon-tabler-users',
  },
  encapsulation: ViewEncapsulation.None,
})
// eslint-disable-next-line @angular-eslint/component-class-suffix
export class UsersIcon {
  protected readonly xmlns = 'http://www.w3.org/2000/svg';

  public readonly width = input<string | number>('24');

  public readonly height = input<string | number>('24');

  public readonly viewBox = input<string>('0 0 24 24');

  public readonly fill = input<string>('none');
}
