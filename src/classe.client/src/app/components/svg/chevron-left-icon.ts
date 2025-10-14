import { Component, ViewEncapsulation } from '@angular/core';

import { SvgIcon } from './svg';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'svg[cheveron-left-icon]',
  template: `<svg:path stroke="none" d="M0 0h24v24H0z" fill="none" />
    <svg:path d="M15 6l-6 6l6 6" />`,
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
    class: 'icon icon-tabler icons-tabler-outline icon-tabler-chevron-left',
  },
  encapsulation: ViewEncapsulation.None,
})
// eslint-disable-next-line @angular-eslint/component-class-suffix
export class ChevronLeftIcon extends SvgIcon {}
