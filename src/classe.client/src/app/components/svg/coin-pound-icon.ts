import { Component, ViewEncapsulation } from '@angular/core';

import { SvgIcon } from './svg';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'svg[coin-pound-icon]',
  template: `<svg:path stroke="none" d="M0 0h24v24H0z" fill="none" />
    <svg:path d="M12 12m-9 0a9 9 0 1 0 18 0a9 9 0 1 0 -18 0" />
    <svg:path d="M15 9a2 2 0 1 0 -4 0v5a2 2 0 0 1 -2 2h6" />
    <svg:path d="M9 12h4" />`,
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
    class: 'icon icon-tabler icons-tabler-outline icon-tabler-coin-pound',
  },
  encapsulation: ViewEncapsulation.None,
})
// eslint-disable-next-line @angular-eslint/component-class-suffix
export class CoinPoundIcon extends SvgIcon {}
