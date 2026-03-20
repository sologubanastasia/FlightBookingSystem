namespace FlightApp.Application.Dto.Auth;

public record AuthResponseDto(
    string Token,
    string Email,
    string Password
);