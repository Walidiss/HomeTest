using GetDinners.Domain.Entities;

namespace GetDinners.Application.Authentication;

public record AuthenticationResult(
   User user,
    string token);