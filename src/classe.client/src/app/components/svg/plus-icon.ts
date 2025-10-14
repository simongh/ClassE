import { Component, ViewEncapsulation } from '@angular/core';

import { SvgIcon } from './svg';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'svg[plus-icon]',
  template: `<svg:path d="M12 5l0 14" />
    <svg:path d="M5 12l14 0" />`,
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
    class: 'icon icon-1',
  },
  encapsulation: ViewEncapsulation.None,
})
// eslint-disable-next-line @angular-eslint/component-class-suffix
export class PlusIcon extends SvgIcon {}
