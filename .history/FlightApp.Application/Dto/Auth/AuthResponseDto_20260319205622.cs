namespace FlightApp.Application.Dto.Auth;

public record AuthResponseDto(
    string Email,
    string Password
);