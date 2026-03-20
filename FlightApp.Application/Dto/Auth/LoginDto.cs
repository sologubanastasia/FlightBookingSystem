namespace FlightApp.Application.Dto.Auth;

public record LoginDto(
    string Email,
    string Password
);