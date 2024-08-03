using GetDinners.Domain.Entities;

namespace GetDinners.Application.Authentication.Common;

public record AuthenticationResult(
   User user,
    string token);