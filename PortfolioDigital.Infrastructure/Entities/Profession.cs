using PortfolioDigital.Infrastructure.Exceptions;

namespace PortfolioDigital.Infrastructure.Entities
{
    public class Profession : AggregateRoot
    {
        public string? Name { get; private set; } = string.Empty;
        public string? Description { get; private set; } = string.Empty;
        public StoredFile? CV { get; private set; } = default;
        public UrlObject? GitHubUrl { get; private set; } = default;
        public string? Enseigne { get; private set; } = string.Empty;
        public StoredFile? Logo { get; private set; } = default;
        public Address? Address { get; private set; } = default;
        public IReadOnlyCollection<Prestation> Prestations { get; private set; } = [];
        public IReadOnlyCollection<Skill> Skills { get; private set; } = [];
        public IReadOnlyCollection<Experience> Experiences { get; private set; } = [];

#pragma warning disable CS8618
        private Profession() { } // EF Core
#pragma warning restore CS8618 

        public static Profession Create(string name, string description, StoredFile cv, UrlObject gitHubUrl, string enseigne, StoredFile logo, Address address, IReadOnlyCollection<Prestation> prestations, IReadOnlyCollection<Skill> skills, IReadOnlyCollection<Experience> experiences)
        {
            return new Profession
            {
                Name = ValidateName(name),
                Description = ValidateDescription(description),
                CV = cv,
                GitHubUrl = gitHubUrl,
                Enseigne = ValidateEnseigne(enseigne),
                Logo = logo,
                Address = address,
                Prestations = prestations,
                Skills = skills,
                Experiences = experiences
            };
        }

        public void SetName(string value)
        {
            try
            {
                Name = ValidateName(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        public void SetDescription(string value)
        {
            try
            {
                Description = ValidateDescription(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        public void SetEnseigne(string value)
        {
            try
            {
                Enseigne = ValidateEnseigne(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        private static string ValidateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be null or empty.");

            return value;
        }

        private static string ValidateDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Description cannot be null or empty.");

            return value;
        }
        
        private static string ValidateEnseigne(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Enseigne cannot be null or empty.");

            return value;
        }
    }
}