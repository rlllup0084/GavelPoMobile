using ErrorOr;

namespace GavelPoMobile.Domain.Common.Errors;
public static partial class Errors {
    public static class Authentication {
        public static Error InvalidCredentials => Error.Validation(code: "Invalid Credentials", description: "Invalid credentials.");
        public static Error InvalidToken => Error.Validation(code: "Invalid Token", description: "Invalid token.");
        public static Error TokenExpired => Error.Validation(code: "Token Expired", description: "Token expired.");
    }
}
