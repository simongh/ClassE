import { VenuModel } from './venue.model';

export interface Venue extends VenuModel {
  id: number;
  address: string | null;
}
