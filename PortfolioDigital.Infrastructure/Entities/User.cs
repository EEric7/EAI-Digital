using PortfolioDigital.Infrastructure.Exceptions;

namespace PortfolioDigital.Infrastructure.Entities
{
    public class User : AEntityGuid
    {
        /// <summary>
        /// Represents the first name of the user.
        /// This property holds the first name of the user and is used for personalization and identification within the application. It is a required field and should be descriptive enough to give an idea of the user's identity. 
        /// The first name is typically used in user interfaces, notifications, and other areas where the user's identity needs to be displayed or referenced.
        /// </summary>
        public string? Firstname { get; private set; } = string.Empty;

        /// <summary>
        /// Represents the last name of the user.
        /// This property holds the last name of the user and is used for personalization and identification within the application.
        /// It is a required field and should be descriptive enough to give an idea of the user's identity. 
        /// The last name is typically used in user interfaces, notifications, and other areas where the user's identity needs to be displayed or referenced.
        /// </summary>  
        public string? Lastname { get; private set; } = string.Empty;

        /// <summary>
        /// Represents the description of the user.
        /// This property holds a brief description or biography of the user, providing additional context about their background, skills, and interests. 
        /// It is used for personalization and identification within the application.
        /// </summary>
        public string? Description { get; private set; } = string.Empty;

        /// <summary>
        /// Represents the profile photo of the user.
        /// This property holds the profile photo of the user, which is typically used for display purposes in user interfaces, such as profile pages, dashboards, 
        /// and other areas where the user's identity needs to be visually represented. The profile photo can be an image file, such as a JPEG or PNG, and is typically
        ///  stored in a database or file storage system. It is important to ensure that the profile photo is appropriately sized and formatted for display in the application, 
        /// and that it is accessible to users with disabilities through the use of alternative text and other accessibility features.
        /// </summary>
        public StoredFile? ProfilePhoto { get; private set; } = default;

        /// <summary>
        /// Represents the collection of profiles associated with the user.
        /// This property holds a read-only collection of profiles that are associated with the user, allowing for the management and retrieval of user profiles within the application. 
        /// Each profile may contain additional information about the user, such as preferences, settings, and other relevant data. The collection is typically used in applications 
        /// that require user management, such as authentication, authorization, and user profile management.
        /// </summary>
        public IReadOnlyCollection<Profil> Profiles => _profiles.AsReadOnly();

        /// <summary>
        /// Represents a user entity in the system.
        /// This class encapsulates the properties and behaviors associated with a user, including personal information, profile photo, and associated profiles and professions.
        /// It provides methods for creating and updating user information, while enforcing business rules and validation through the use of exceptions.
        /// The User entity is typically used in applications that require user management, such as authentication, authorization, and user profile management.
        /// </summary>
        private readonly List<Profil> _profiles = [];

        /// <summary>
        /// Represents the collection of professions associated with the user.
        /// This property holds a read-only collection of professions that are associated with the user, allowing for the management and retrieval of user professions within the application. 
        /// Each profession may contain additional information about the user's professional background, skills, and expertise. The collection is typically used in applications that require user management, 
        /// such as authentication, authorization, and user profile management.
        /// </summary>
        public IReadOnlyCollection<Profession> Professions => _professions.AsReadOnly();

        /// <summary>
        /// Represents a user profession in the system.
        /// This class encapsulates the properties and behaviors associated with a user's profession, including the profession's details and related information.
        /// It provides methods for creating and updating profession information, while enforcing business rules and validation through the use of exceptions.
        /// The Profession entity is typically used in applications that require user management, such as authentication, authorization, and user profile management.
        /// </summary>
        private readonly List<Profession> _professions = [];


/// <summary>
/// Default constructor for EF Core.
/// This constructor is used by Entity Framework Core to create instances of the User entity when retrieving data from the database. 
/// It is marked as private to prevent direct instantiation of the User class outside of the Entity Framework context. 
/// The constructor initializes the User entity with default values for its properties, ensuring
/// </summary>
#pragma warning disable CS8618
        private User() { } // EF Core
#pragma warning restore CS8618

        /// <summary>
        /// Creates a new User instance with the specified first name, last name, description, and profile photo.
        /// This static method is used to create a new User entity with the provided information, while enforcing business rules and validation through the use of exceptions. 
        /// It validates the input parameters and throws a BusinessRuleViolationException if any of the required fields are missing or invalid. 
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="description"></param>
        /// <param name="profilePhoto"></param>
        /// <returns></returns>
        public static User Create(string? firstname, string? lastname, string? description, StoredFile? profilePhoto, List<Profil>? profiles = null, List<Profession>? professions = null)
        {
            User result = new User();
            result.SetFirstname(firstname);
            result.SetLastname(lastname);
            result.SetDescription(description);
            result.ProfilePhoto?.SetStoredFile(profilePhoto);
            result.SetProfiles(profiles);
            result.SetProfessions(professions);
            return result;
        }

        /// <summary>
        /// Sets the properties of the User instance based on the provided User object.
        /// This method allows you to update the properties of the User instance with the values from another User object. 
        /// It is useful for copying the properties from one instance to another while ensuring that the validation rules are applied to each property.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User SetUser(User? user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            this.SetFirstname(user?.Firstname);
            this.SetLastname(user?.Lastname);
            this.SetDescription(user?.Description);
            this.ProfilePhoto?.SetStoredFile(user?.ProfilePhoto);
            this.SetProfiles(user?._profiles);
            this.SetProfessions(user?._professions);
            return this;
        }

        /// <summary>
        /// Sets the first description of the user.
        /// This method allows you to change the description of the user to a new value.
        /// It validates that the description is not null, empty, or whitespace. If the description is invalid, it throws a BusinessRuleViolationException. This method is used to manage the user's personal information.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        public void SetDescription(string? value)
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

        /// <summary>
        ///     Sets the last name of the user.
        ///     This method allows you to change the last name of the user to a new value. It validates that the last name is not null, empty, or whitespace.
        ///     If the last name is invalid, it throws a BusinessRuleViolationException. This method is used to manage the user's personal information.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        public void SetLastname(string? value)
        {
            try
            {
                Lastname = ValidateLastname(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Sets the profile photo of the user.
        /// This method allows you to change the profile photo of the user to a new value.
        /// It validates the provided StoredFile object and updates the user's profile photo accordingly.
        /// If the provided StoredFile object is null, it initializes a new StoredFile instance.
        /// The method ensures that the user's profile photo is updated correctly and throws a BusinessRuleViolationException in case of any validation errors or exceptions during the update process. 
        /// It is used to manage the user's visual representation within the application, such as profile pages, dashboards, and other areas where the user's identity needs to be visually represented.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        public void SetFirstname(string? value)
        {
            try
            {
                Firstname = ValidateFirstname(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Sets the profile photo of the user.
        /// This method allows you to change the profile photo of the user to a new value.
        /// It validates the provided StoredFile object and updates the user's profile photo accordingly.
        /// If the provided StoredFile object is null, it initializes a new StoredFile instance.
        /// The method ensures that the user's profile photo is updated correctly and throws a BusinessRuleViolationException in case of any validation errors or exceptions during the update process. 
        /// It is used to manage the user's visual representation within the application, such as profile pages, dashboards, and other areas where the user's identity needs to be visually represented.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        public void SetProfiles(List<Profil>? value)
        {
            try
            {
                foreach (var profile in value ?? new List<Profil>())
                {
                    if (!_profiles.Contains(profile))
                        _profiles.Add(profile);
                    else
                        _profiles[_profiles.IndexOf(profile)] = profile;
                }
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Sets the professions associated with the user.
        /// This method allows you to change the professions associated with the user to a new list of professions. 
        /// It validates that the provided list of professions is not null and updates the user's professions accordingly.
        /// If the provided list is null, it initializes an empty list of professions. The method ensures that the user's professions are updated correctly and
        /// throws a BusinessRuleViolationException in case of any validation errors or exceptions during the update process. 
        /// It is used to manage the user's professional background and expertise within
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        public void SetProfessions(List<Profession>? value)
        {
            try
            {
                foreach (var profession in value ?? new List<Profession>())
                {
                    if (!_professions.Contains(profession))
                        _professions.Add(profession);
                    else
                        _professions[_professions.IndexOf(profession)] = profession;
                }
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Validates the provided first name for the user.
        /// This method checks if the first name is null or whitespace and throws a BusinessRuleViolationException if it is. 
        /// It ensures that the first name is a required field and provides meaningful feedback in case of validation failure. 
        /// The method returns the validated first name if it passes the checks.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="BusinessRuleViolationException"></exception>
        private static string ValidateFirstname(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleViolationException("Firstname is required.", new ArgumentNullException(nameof(value)));

            return value;
        }

        /// <summary>
        /// Validates the provided last name for the user.
        /// This method checks if the last name is null or whitespace and throws a BusinessRuleViolationException if it is. 
        /// It ensures that the last name is a required field and provides meaningful feedback in case of validation failure. 
        /// The method returns the validated last name if it passes the checks.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="BusinessRuleViolationException"></exception>
        private static string ValidateLastname(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleViolationException("Lastname is required.", new ArgumentNullException(nameof(value)));

            return value;
        }

        /// <summary>
        /// Validates the provided description for the user.
        /// This method checks if the description is null or whitespace and throws a BusinessRuleViolationException if it is. 
        /// It ensures that the description is a required field and provides meaningful feedback in case of validation failure. 
        /// The method returns the validated description if it passes the checks.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="BusinessRuleViolationException"></exception>
        private static string ValidateDescription(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessRuleViolationException("Description is required.", new ArgumentNullException(nameof(value)));

            return value;
        }
    }
}