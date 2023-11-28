using System;
using Xunit;
using System.IO;
using CinemaModel;

namespace CIS.Tests
{
    public class Tests
    {
        /*������ ��� ������������:
            Basket, Seating(���������������), Schedule(���������������)*/
        [Fact]
        public void Booking_the_right_place()
        {
            //arrange
            int[][] places = new int[4][];
            places[0] = new int[4] { 1, 2, 3, 4 };
            places[1] = new int[4] { 5, 6, 7, 8 };
            places[2] = new int[4] { 9, 10, 11, 12 };
            places[3] = new int[4] { 13, 14, 15, 16 };
            Seating seating = new Seating(places, 1);

            Place placeForBooking = new Place(0,0,100);
            int[][] placePositiv = new int[4][];
            placePositiv[0] = new int[4] { -1, 2, 3, 4 };
            placePositiv[1] = new int[4] { 5, 6, 7, 8 };
            placePositiv[2] = new int[4] { 9, 10, 11, 12 };
            placePositiv[3] = new int[4] { 13, 14, 15, 16 };
            Seating seatingPositiv = new Seating(placePositiv, 1);

            //act
            seating.BookingPlace(placeForBooking);

            //assert
            Assert.Equal(seating.Places, seatingPositiv.Places);
        }

        [Fact]
        public void Booking_an_already_booked_seat()
        {
            //arrange
            int[][] places = new int[4][];
            places[0] = new int[4] { -1, 2, 3, 4 };
            places[1] = new int[4] { 5, 6, 7, 8 };
            places[2] = new int[4] { 9, 10, 11, 12 };
            places[3] = new int[4] { 13, 14, 15, 16 };
            Seating seating = new Seating(places, 1);

            Place placeForBooking = new Place(0, 0, 100);
            int[][] placePositiv = new int[4][];
            placePositiv[0] = new int[4] { -1, 2, 3, 4 };
            placePositiv[1] = new int[4] { 5, 6, 7, 8 };
            placePositiv[2] = new int[4] { 9, 10, 11, 12 };
            placePositiv[3] = new int[4] { 13, 14, 15, 16 };
            Seating seatingPositiv = new Seating(placePositiv, 1);

            //act
            seating.BookingPlace(placeForBooking);

            //assert
            Assert.Equal(seating.Places, seatingPositiv.Places);
        }

        [Fact]
        public void Booking_a_seat_that_is_not_in_the_hall()
        {
            //arrange
            int[][] places = new int[4][];
            places[0] = new int[4] { 1, 2, 3, 4 };
            places[1] = new int[4] { 5, 6, 7, 8 };
            places[2] = new int[4] { 9, 10, 11, 12 };
            places[3] = new int[4] { 13, 14, 15, 16 };
            Seating seating = new Seating(places, 1);

            Place placeForBooking = new Place(4, 4, 100);
            int[][] placePositiv = new int[4][];
            placePositiv[0] = new int[4] { 1, 2, 3, 4 };
            placePositiv[1] = new int[4] { 5, 6, 7, 8 };
            placePositiv[2] = new int[4] { 9, 10, 11, 12 };
            placePositiv[3] = new int[4] { 13, 14, 15, 16 };
            Seating seatingPositiv = new Seating(placePositiv, 1);

            //act
            seating.BookingPlace(placeForBooking);

            //assert
            Assert.Equal(seating.Places, seatingPositiv.Places);
            
        }
        [Fact]
        public void Find_Schedule_by_name_film_show()
        {
            Schedule scheduleAll = new Schedule(new List<Show> { 
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 1", new DateOnly(2023,11,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 2", new DateOnly(2023,11,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 2", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 2", new DateOnly(2023,11,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1)
            });

            Schedule scheduleForFilmOne = new Schedule(new List<Show> {
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 1", new DateOnly(2023,11,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1)
            });

            Schedule scheduleForFilmOneTest = scheduleAll.FindByName("����� 1");

            Assert.Equal(scheduleForFilmOneTest.Shows.Count, scheduleForFilmOne.Shows.Count);
            Assert.Equal(scheduleForFilmOneTest.Shows[0].Name, scheduleForFilmOne.Shows[0].Name);
            Assert.Equal(scheduleForFilmOneTest.Shows[1].Name, scheduleForFilmOne.Shows[1].Name);
            Assert.Equal(scheduleForFilmOneTest.Shows[2].Name, scheduleForFilmOne.Shows[2].Name);
        }
        [Fact]
        public void Find_Schedule_by_date()
        {
            Schedule scheduleAll = new Schedule(new List<Show> {
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 1", new DateOnly(2023,11,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 2", new DateOnly(2023,11,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 2", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 2", new DateOnly(2023,11,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1)
            });

            Schedule scheduleForFilmOne = new Schedule(new List<Show> {
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 2", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1)
            });

            Schedule scheduleForFilmOneTest = scheduleAll.FindByDate(new DateOnly(2023,10,2));
            Assert.Equal(scheduleForFilmOneTest.Shows.Count, scheduleForFilmOne.Shows.Count);
            Assert.Equal(scheduleForFilmOneTest.Shows[0].Name, scheduleForFilmOne.Shows[0].Name);
            Assert.Equal(scheduleForFilmOneTest.Shows[1].Name, scheduleForFilmOne.Shows[1].Name);
            Assert.Equal(scheduleForFilmOneTest.Shows[2].Name, scheduleForFilmOne.Shows[2].Name);
        }
        [Fact]
        public void Check_Schedule_is_not_null()
        {
            Schedule schedule = new Schedule(new List<Show> {
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 1", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1),
                new Show("����� 2", new DateOnly(2023,10,2), new TimeOnly(12,12), new Seating(new int[1][], 1), 1)
            });

            bool result = schedule.IsNull();

            Assert.False(result);
        }
        [Fact]
        public void Check_Schedule_is_null()
        {
            Schedule schedule = new Schedule(new List<Show> {});

            bool result = schedule.IsNull();

            Assert.True(result);
        }
        [Fact]
        public void Add_Ticket_in_Basket()
        {
            Basket basket= new Basket();

            int[][] places = new int[4][];
            places[0] = new int[4] { 1, 2, 3, 4 };
            places[1] = new int[4] { 5, 6, 7, 8 };
            places[2] = new int[4] { 9, 10, 11, 12 };
            places[3] = new int[4] { 13, 14, 15, 16 };

            Seating seating = new Seating(places, 1);

            Place placeForBooking = new Place(0, 0, 100);

            Ticket ticket = new Ticket(
                1,
                new Show("����� 1", new DateOnly(2023, 10, 2), new TimeOnly(12, 12), seating, 1),
                placeForBooking
                );

            basket.AddTicket(ticket);

            Assert.Same(basket.Tickets[0], ticket);
            Assert.Equal(basket.Price,placeForBooking.Price);
        }
    }
}