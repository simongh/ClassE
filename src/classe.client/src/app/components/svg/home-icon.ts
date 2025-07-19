import { Component, input, ViewEncapsulation } from '@angular/core';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'svg[home-icon]',
  template: `<svg:path stroke="none" d="M0 0h24v24H0z" fill="none" />
    <svg:path d="M5 12l-2 0l9 -9l9 9l-2 0" />
    <svg:path d="M5 12v7a2 2 0 0 0 2 2h10a2 2 0 0 0 2 -2v-7" />
    <svg:path d="M9 21v-6a2 2 0 0 1 2 -2h2a2 2 0 0 1 2 2v6" />`,
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
    class: 'icon icon-tabler icons-tabler-outline icon-tabler-home',
  },
  encapsulation: ViewEncapsulation.None,
})
// eslint-disable-next-line @angular-eslint/component-class-suffix
export class HomeIcon {
  protected readonly xmlns = 'http://www.w3.org/2000/svg';

  public readonly width = input<string | number>('24');

  public readonly height = input<string | number>('24');

  public readonly viewBox = input<string>('0 0 24 24');

  public readonly fill = input<string>('none');
}
