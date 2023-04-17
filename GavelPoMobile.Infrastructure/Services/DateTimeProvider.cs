using GavelPoMobile.Application.Common.Interfaces.Services;

namespace GavelPoMobile.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}
