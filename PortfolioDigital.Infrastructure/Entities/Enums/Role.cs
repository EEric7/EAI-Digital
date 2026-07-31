using PortfolioDigital.Infrastructure.Exceptions;

namespace PortfolioDigital.Infrastructure.Entities
{
    public sealed class Role : AEnumeration
    {
        public static readonly Role Admin = new(1, "Admin");
        public static readonly Role User = new(2, "User");
        public static readonly Role Visitor = new(3, "Visitor");

        private Role(int id, string name) : base(id, name) { }

        public static Role[] SetRole(Role value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            // Return an array containing the provided role

            return new Role[] { value };
        }

        private static string ValidateDisplayName(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleViolationException("DisplayName is required.", new ArgumentNullException(nameof(value)));

            return value;
        }
    }
}