import { dayOfWeek } from "@app-types/dayOfWeek";
import { timeString } from "@app-types/timeString";

export interface Booking {
  day: dayOfWeek;
  startTime: timeString;
}
