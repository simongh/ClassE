import { Component, ViewEncapsulation } from '@angular/core';

import { SvgIcon } from './svg';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'svg[buildings-icon]',
  template: `<svg:path stroke="none" d="M0 0h24v24H0z" fill="none" />
    <svg:path d="M4 21v-15c0 -1 1 -2 2 -2h5c1 0 2 1 2 2v15" />
    <svg:path d="M16 8h2c1 0 2 1 2 2v11" />
    <svg:path d="M3 21h18" />
    <svg:path d="M10 12v0" />
    <svg:path d="M10 16v0" />
    <svg:path d="M10 8v0" />
    <svg:path d="M7 12v0" />
    <svg:path d="M7 16v0" />
    <svg:path d="M7 8v0" />
    <svg:path d="M17 12v0" />
    <svg:path d="M17 16v0" />`,
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
    class: 'icon icon-tabler icons-tabler-outline icon-tabler-buildings',
  },
  encapsulation: ViewEncapsulation.None,
})
// eslint-disable-next-line @angular-eslint/component-class-suffix
export class BuildingsIcon extends SvgIcon {}
