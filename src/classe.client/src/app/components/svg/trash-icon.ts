import { Component, ViewEncapsulation } from '@angular/core';

import { SvgIcon } from './svg';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'svg[trash]',
  template: ` <svg:path stroke="none" d="M0 0h24v24H0z" fill="none" />
    <svg:path d="M4 7l16 0" />
    <svg:path d="M10 11l0 6" />
    <svg:path d="M14 11l0 6" />
    <svg:path d="M5 7l1 12a2 2 0 0 0 2 2h8a2 2 0 0 0 2 -2l1 -12" />
    <svg:path d="M9 7v-3a1 1 0 0 1 1 -1h4a1 1 0 0 1 1 1v3" />`,
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
    class: 'icon icon-tabler icons-tabler-outline icon-tabler-trash',
  },
  encapsulation: ViewEncapsulation.None,
})
// eslint-disable-next-line @angular-eslint/component-class-suffix
export class TrashIcon extends SvgIcon {}
