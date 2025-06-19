import { NgModule } from '@angular/core';

import { CardFooterComponent } from './card-footer.component';
import { CardHeaderComponent } from './card-header.component';
import { CardTitleComponent } from './card-title.component';
import { CardComponent } from './card.component';

@NgModule({
  imports: [CardComponent, CardHeaderComponent, CardTitleComponent, CardFooterComponent],
  exports: [CardComponent, CardHeaderComponent, CardTitleComponent, CardFooterComponent],
})
export class CardsModule {}
