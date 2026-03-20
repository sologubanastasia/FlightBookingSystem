using FlightApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.Infrastructure;

public static class DbInitializer
{
    public static async Task SeedData(FlightDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        await context.Database.EnsureCreatedAsync();

        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            await roleManager.CreateAsync(new IdentityRole<Guid> { Name = UserRoles.Admin, NormalizedName = "ADMIN" });

        if (!await roleManager.RoleExistsAsync(UserRoles.User))
            await roleManager.CreateAsync(new IdentityRole<Guid> { Name = UserRoles.User, NormalizedName = "USER" });

        if (await userManager.FindByEmailAsync("admin@test.com") == null)
        {
            var admin = new User { UserName = "admin@test.com", Email = "admin@test.com", EmailConfirmed = true };
            await userManager.CreateAsync(admin, "Admin123!");
            await userManager.AddToRoleAsync(admin, UserRoles.Admin);
        }

        var testUser = await userManager.FindByEmailAsync("user@test.com");
        if (testUser == null)
        {
            testUser = new User { UserName = "user@test.com", Email = "user@test.com", EmailConfirmed = true };
            await userManager.CreateAsync(testUser, "User123!");
            await userManager.AddToRoleAsync(testUser, UserRoles.User);
        }

        if (!await context.Flights.AnyAsync())
        {
            var flight = new Flight
            {
                Id = Guid.NewGuid(),
                FlightNumber = "PS777",
                Destination = "Kyiv - Sydney",
                DepartureTime = DateTime.UtcNow.AddDays(3),
                ArrivalTime = DateTime.UtcNow.AddDays(3).AddHours(12)
            };

            var seat1 = new Seat { Id = Guid.NewGuid(), SeatNumber = "1A", IsAvailable = false };
            var seat2 = new Seat { Id = Guid.NewGuid(), SeatNumber = "1B", IsAvailable = true };

            flight.Seats.Add(seat1);
            flight.Seats.Add(seat2);

            context.Flights.Add(flight);
            await context.SaveChangesAsync();

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                UserId = testUser.Id,
                FlightId = flight.Id,
                Status = Status.Confirmed,
                BookingDate = DateTime.UtcNow
            };

            context.Bookings.Add(booking);
            await context.SaveChangesAsync();

            var bookingSeat = new BookingSeat
            {
                BookingId = booking.Id,
                SeatId = seat1.Id
            };

            context.BookingSeats.Add(bookingSeat);
            await context.SaveChangesAsync();
        }
    }
}