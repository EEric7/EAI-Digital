using PortfolioDigital.Infrastructure.Exceptions;

namespace PortfolioDigital.Infrastructure.Entities
{
    public class Profil : AggregateRoot
    {
        /// <summary>
        /// Email address of the user profile.
        /// This property holds the email address associated with the user profile.
        /// It is used for communication purposes, such as sending notifications or password reset links.
        /// The email should be a valid format and unique within the system.
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Role of the user profile.
        /// This property represents the role assigned to the user profile, such as Visitor, User, Admin, etc.
        /// It is used to manage access control and permissions within the application.
        /// The role determines what actions the user can perform and what resources they can access.
        /// </summary>  
        public Role Role { get; private set; } = Role.Visitor;

        /// <summary>
        /// Password of the user profile.
        /// This property holds the password associated with the user profile.
        /// It is used for authentication purposes, allowing the user to securely log in to the application.
        /// The password should be stored securely, typically using hashing and salting techniques, to protect against unauthorized access.
        /// </summary>
        public Password? Password { get; private set; }

        /// <summary>
        /// Address of the user profile.
        /// This property holds the address information associated with the user profile.
        /// It is used for contact purposes, such as shipping, billing, or location-based services.
        /// The address should be a valid format and may include street, city, state, postal code, and country information. It is important to ensure that the address is accurate and up-to-date
        /// </summary>
        public Address? Address { get; private set; } = default;

        /// <summary>
        /// Display name of the user profile.
        /// This property represents the display name of the user profile, which is typically used for personalization and identification within the application.
        /// It can be a full name, username, or any other identifier that the user chooses to represent themselves.
        /// The display name should be unique and descriptive enough to give an idea of the user's identity within the application.
        /// </summary>
        public string? DisplayName { get; private set; } = string.Empty;

/// <summary>
/// Default constructor for EF Core
/// This constructor is used by Entity Framework Core to create instances of the Profil class when retrieving data from the database. It is marked as private to prevent direct instantiation of the Profil class outside of the class itself.
/// </summary>
#pragma warning disable CS8618
        private Profil() { } // EF Core
#pragma warning restore CS8618 


        /// <summary>
        /// Creates a new Profil instance with the specified email, role, display name, password, and address.
        /// This static method is used to create a new instance of the Profil class with the provided parameters. It initializes the properties of the Profil instance and returns the newly created object.
        /// The method ensures that the provided parameters are valid and throws a BusinessRuleViolationException in case of any validation errors or exceptions during the creation process. 
        /// It is used to manage user profiles within the application, allowing for the creation of new user profiles with specific attributes such as email, role, display name, password, and address.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="role"></param>
        /// <param name="displayName"></param>
        /// <param name="password"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static Profil Create(Email email, Role role, string? displayName, Password? password, Address? address)
        {
            Profil result = new Profil();
            result.Email.SetEmail(email);
            //TODO: result.Role = role;
            result.Role.SetRole(role);
            result.SetDisplayName(displayName);
            result.Password?.SetPassword(password);
            result.Address?.SetAddress(address);

            return result;
        }

        public void SetUser(Profil? value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.Email.SetEmail(value.Email);
            //TODO: this.Role = value.Role;
            this.Role.SetRole(value.Role);
            this.SetDisplayName(value.DisplayName);
            this.Password?.SetPassword(value.Password);
            this.Address?.SetAddress(value.Address);
        }

        public void SetDisplayName(string? value)
        {
            try
            {
                DisplayName = ValidateDisplayName(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        private static string ValidateDisplayName(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleViolationException("DisplayName is required.", new ArgumentNullException(nameof(value)));

            return value;
        }
    }
}