import { Component, input, ViewEncapsulation } from '@angular/core';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'svg[chevron-right-icon]',
  template: `<svg:path stroke="none" d="M0 0h24v24H0z" fill="none" />
      <svg:path d="M9 6l6 6l-6 6" />`,
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
    class: 'icon icon-tabler icons-tabler-outline icon-tabler-chevron-right',
  },
  encapsulation: ViewEncapsulation.None,
})
// eslint-disable-next-line @angular-eslint/component-class-suffix
export class ChevronRightIcon {
  protected readonly xmlns = 'http://www.w3.org/2000/svg';

  public readonly width = input<string | number>('24');

  public readonly height = input<string | number>('24');

  public readonly viewBox = input<string>('0 0 24 24');

  public readonly fill = input<string>('none');
}
