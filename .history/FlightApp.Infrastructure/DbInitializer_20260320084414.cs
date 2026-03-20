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
            await roleManager.CreateAsync(new IdentityRole<Guid> { Name = UserRoles.Admin, NormalizedName = UserRoles.Admin.ToUpper() });

        if (!await roleManager.RoleExistsAsync(UserRoles.User))
            await roleManager.CreateAsync(new IdentityRole<Guid> { Name = UserRoles.User, NormalizedName = UserRoles.User.ToUpper() });

        var adminEmail = "admin@test.com";
        var userEmail = "user@test.com";

        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var admin = new User { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
            await userManager.CreateAsync(admin, "Admin123!");
            await userManager.AddToRoleAsync(admin, UserRoles.Admin);
        }

        User testUser = await userManager.FindByEmailAsync(userEmail);
        if (testUser == null)
        {
            testUser = new User { UserName = userEmail, Email = userEmail, EmailConfirmed = true };
            await userManager.CreateAsync(testUser, "User123!");
            await userManager.AddToRoleAsync(testUser, UserRoles.User);
        }

        if (!await context.Flights.AnyAsync())
        {
            var flight1 = new Flight
            {
                Id = Guid.NewGuid(),
                FlightNumber = "PS123",
                Destination = "Kyiv - Sydney",
                DepartureTime = DateTime.UtcNow.AddDays(2),
                ArrivalTime = DateTime.UtcNow.AddDays(2).AddHours(15)
            };

            for (int i = 1; i <= 10; i++)
            {
                flight1.Seats.Add(new Seat 
                { 
                    Id = Guid.NewGuid(), 
                    SeatNumber = $"{i}A", 
                    IsAvailable = true 
                });
            }

            context.Flights.Add(flight1);
            await context.SaveChangesAsync();

            var seat = flight1.Seats.First();
            seat.IsAvailable = false;

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                UserId = testUser.Id,
                FlightId = flight1.Id,
                Status = Status.Confirmed,
                BookingDate = DateTime.UtcNow
            };

            context.Bookings.Add(booking);
            await context.SaveChangesAsync();

            context.BookingSeats.Add(new BookingSeat 
            { 
                BookingId = booking.Id, 
                SeatId = seat.Id 
            });
            
            await context.SaveChangesAsync();
        }
    }
}