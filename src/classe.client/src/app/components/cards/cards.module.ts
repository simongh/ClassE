import { NgModule } from '@angular/core';

import { CardFooterComponent } from './card-footer.component';
import { CardHeaderComponent } from './card-header.component';
import { CardComponent } from './card.component';

@NgModule({
  imports: [CardComponent, CardHeaderComponent, CardFooterComponent],
  exports: [CardComponent, CardHeaderComponent, CardFooterComponent],
})
export class CardsModule {}
