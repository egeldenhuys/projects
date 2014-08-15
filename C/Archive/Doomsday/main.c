/*
 * doomsday.c
 * A program to test a function dayOfWeek which determines which
 * day of the week a particular date falls on.
 * (only for dates after the start of the Gregorian calendar).
 *
 * Program stub created by Richard Buckland on 27/03/12
 * This program by Janie Geldenhuys (z3417609)
 * Tutorial Class: FridayMoog
 * Tutor: Alex Hixon
 * Completion Date: 04.04.2013
 * Freely licensed under Creative Commons CC-BY-3.0
 */

#include <stdio.h>
#include <stdlib.h>
#include <assert.h>

#define THURSDAY 0
#define FRIDAY  1
#define SATURDAY 2
#define SUNDAY  3
#define MONDAY  4
#define TUESDAY    5
#define WEDNESDAY 6

#define TRUE 1
#define FALSE 0
#define DAYS_PER_WEEK 7

int dayOfWeek (int doomsday, int leapYear, int month, int day);

int main (int argc, char *argv[]) {

   assert (dayOfWeek (THURSDAY,     FALSE,  4,  4) == THURSDAY);
   assert (dayOfWeek (FRIDAY,       FALSE,  6,  6) == FRIDAY);
   assert (dayOfWeek (MONDAY,       FALSE,  8,  8) == MONDAY);
   assert (dayOfWeek (WEDNESDAY,    FALSE, 10, 10) == WEDNESDAY);
   assert (dayOfWeek (FRIDAY,       FALSE, 12, 12) == FRIDAY);
   assert (dayOfWeek (THURSDAY,     FALSE,  9,  5) == THURSDAY);
   assert (dayOfWeek (FRIDAY,       FALSE,  5,  9) == FRIDAY);
   assert (dayOfWeek (SUNDAY,       FALSE,  7, 11) == SUNDAY);
   assert (dayOfWeek (TUESDAY,      FALSE, 11,  7) == TUESDAY);
   assert (dayOfWeek (WEDNESDAY,    FALSE,  3,  7) == WEDNESDAY);

   assert (dayOfWeek (THURSDAY,     FALSE,   4,  5) == FRIDAY);
   assert (dayOfWeek (SATURDAY,     FALSE,   6,  5) == FRIDAY);
   assert (dayOfWeek (MONDAY,       FALSE,   8,  9) == TUESDAY);
   assert (dayOfWeek (WEDNESDAY,    FALSE,  10,  9) == TUESDAY);
   assert (dayOfWeek (FRIDAY,       FALSE,  12, 20) == SATURDAY);
   assert (dayOfWeek (THURSDAY,     FALSE,   9,  9) == MONDAY);
   assert (dayOfWeek (FRIDAY,       FALSE,   5,  5) == MONDAY);
   assert (dayOfWeek (SUNDAY,       FALSE,   7,  7) == WEDNESDAY);
   assert (dayOfWeek (TUESDAY,      FALSE,  11, 11) == SATURDAY);
   assert (dayOfWeek (THURSDAY,     FALSE,   3, 30) == SATURDAY);

   assert (dayOfWeek (TUESDAY,      FALSE,  2, 28)  == TUESDAY);
   assert (dayOfWeek (TUESDAY,      FALSE,  2, 27)  == MONDAY);
   assert (dayOfWeek (THURSDAY,     FALSE,  1,  3)  == THURSDAY);
   assert (dayOfWeek (SATURDAY,     FALSE, 12, 18)  == FRIDAY);
   assert (dayOfWeek (WEDNESDAY,     TRUE, 10,  5)  == FRIDAY);
   assert (dayOfWeek (MONDAY,        TRUE,  2, 10)  == WEDNESDAY);
   assert (dayOfWeek (TUESDAY,       TRUE,  2, 29)  == TUESDAY);
   assert (dayOfWeek (TUESDAY,       TRUE, 12, 31)  == SUNDAY);
   assert (dayOfWeek (TUESDAY,       TRUE,  1,  1)  == SATURDAY);
   assert (dayOfWeek (TUESDAY,       TRUE,  4,  4)  == TUESDAY);

   printf ("all tests passed - You are awesome!\n");
   return EXIT_SUCCESS;
}


// given the doomsday for a year, and whether or not it is a
// leap year, this function return the day of the week for any
// given month and day in the year.

int dayOfWeek (int doomsday, int leapYear, int month, int day) {
   int dayOfWeek closestDoomsday, daysTillDoomsday, calculatingDay;
   int dayOfYear = 0;
   int findDoomsday = 0;
   int i;                           // i will serve as a counter for a loop

   /*
    *The function of the following array is to store the day of
    * year that each doomsday is on (when it is not a leap year).
    * Zeroth of March = 59th day of the year
    * 4/4 = 94th day of the year
    * 9/5 = 129th day of the year
    * 6/6 = 157th day of the year
    * 11/7 = 192nd day of the year
    * 8/8 = 220th day of the year
    * 5/9 = 248th day of the year
    * 10/10 = 283rd day of the year
    * 7/11 = 311th day of the year
    * 12/12 = 346th day of the year
    */

   int Doomsdays[] = {59, 94, 129, 157, 192, 220, 248, 283, 311, 346};

   // This array holds how many days in each month.
   int Months[] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

   if (leapYear == TRUE) {
      // This loop adds one day to each of the doomsday in the array Doomsdays
      for (i = 0; i < 10; i++) {
         Doomsdays[i]++;
      }
      Months[1]++;                  // This adds one day to February
   }

   for (i = 0; i < month - 1; i++) {
      dayOfYear = dayOfYear + Months[i];
   }

   dayOfYear = dayOfYear + day;

   i = 0;
   if (dayOfYear <= Doomsdays[9]) {

      // If the day of year is not bigger than the last Doomsday in the year
      // then the following loop finds the closest Doomsday to the day of year entered.
      while (findDoomsday != 1) {
         if (dayOfYear <= Doomsdays[i]) {
            closestDoomsday = Doomsdays[i];
            findDoomsday = 1;
         }
         i = i + 1;
      }

      daysTillDoomsday = closestDoomsday - dayOfYear;

      if (daysTillDoomsday == 0) {
         dayOfWeek = doomsday;
      } else {
         calculatingDay = (daysTillDoomsday % DAYS_PER_WEEK);

         if (calculatingDay != 0 ) {
            dayOfWeek = doomsday - calculatingDay;

            if (dayOfWeek < 0) {
               dayOfWeek = 7 + dayOfWeek;
            }

         } else {
            dayOfWeek = doomsday;
         }
      }

   } else {

      closestDoomsday = Doomsdays[9];
      daysTillDoomsday = dayOfYear - closestDoomsday;
      calculatingDay = (daysTillDoomsday % DAYS_PER_WEEK);
      dayOfWeek = doomsday + calculatingDay;

      if (dayOfWeek > 6) {
         dayOfWeek = dayOfWeek - 7;
      }
   }

   return (dayOfWeek);
}
