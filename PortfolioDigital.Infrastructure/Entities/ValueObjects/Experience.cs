using PortfolioDigital.Infrastructure.Exceptions;

namespace PortfolioDigital.Infrastructure.Entities
{
    public class Experience
    {
        /// <summary>
        /// ProjectName of the experience.
        /// This property represents the ProjectName of the experience.
        /// It is a required field and should be descriptive enough to give an idea of the experience's nature.
        /// </summary>
        public string? ProjectName { get; private set; } = string.Empty;

        /// <summary>
        /// Description of the experience.
        /// This property provides a detailed description of the experience, including the tasks performed,
        /// skills acquired, and any notable achievements.
        /// </summary>
        public string Description { get; private set; } = string.Empty;

        /// <summary>
        /// Description of the position in the experience. 
        /// This property provides details about the role held during the experience.
        /// </summary>
        public string? Position { get; private set; } = string.Empty;

        /// <summary>
        /// URL of the image representing the experience.  
        /// This property holds the URL of an image associated with the experience.
        /// It is typically used to display a visual representation of the experience in user interfaces.
        /// </summary>
        public StoredFile? ImageUrl { get; private set; } = default;

        /// <summary>
        /// Start date of the experience.
        /// This property represents the date when the experience began.
        /// It is important to ensure that the start date is valid and not in the future.
        /// </summary>
        public DateTime StartDate { get; private set; } = default!;

        /// <summary>
        /// End date of the experience.
        /// This property represents the date when the experience ended.
        /// It is important to ensure that the end date is valid and not before the start date.
        /// </summary>
        public DateTime EndDate { get; private set; } = default!;

        /// <summary>
        /// Name of the company where the experience was gained.
        /// This property represents the name of the company or organization where the experience was gained.
        /// It is a required field and should be descriptive enough to give an idea of the company's identity.
        /// </summary>
        public string Company { get; private set; } = string.Empty;

        /// <summary>
        /// Address of the company where the experience was gained.
        /// This property represents the address of the company or organization where the experience was gained.
        /// It is an optional field and can be null if the address is not available or not applicable.
        /// The address is stored as a value object of type <see cref="Address"/>
        /// which encapsulates the details of the address, such as street, city, postal code, and country.
        /// </summary>
        public Address? Address { get; private set; } = default;

        /// <summary>
        /// StackTechnologies used during the experience.
        /// This property represents the technologies, tools, or frameworks used during the experience.
        /// It is a required field and should be descriptive enough to give an idea of the technical skills and expertise gained during the experience.
        /// The stackTechnologies should be a comma-separated list of technologies, tools, or frameworks used during the experience.
        /// </summary>
        public string StackTechnologies { get; private set; } = string.Empty;

        /// <summary>
        /// Missions performed during the experience.
        /// This property represents the missions or tasks performed during the experience.
        /// It is an optional field and can be null if the missions are not available or not applicable.
        /// The missions are stored as a list of strings, where each string represents a mission or task performed during the experience.
        /// </summary>
        public IReadOnlyCollection<string>? Missions => _missions.AsReadOnly();

        private List<string> _missions = [];

        /// <summary>
        /// Default constructor for EF Core.
        /// This constructor is used by Entity Framework Core to create instances of the Experience class when retrieving data from the database.
        /// It is marked as private to prevent direct instantiation of the Experience class outside of the Entity Framework Core context.   
        /// </summary>
// Default constructor for EF Core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private Experience() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        /// <summary>
        /// Creates a new instance of the Experience class with the specified parameters.
        /// </summary>
        /// <param name="company"></param>
        /// <param name="position"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static Experience Create(string? projectName, string? Description,  string? company, string? position, DateTime startDate, DateTime endDate, string? description, params string[] _missions)
        {
            var experience = new Experience();
            experience.SetProjectName(projectName);
            experience.SetCompany(company);
            experience.SetPosition(position);
            experience.SetStartDate(startDate);
            experience.SetEndDate(endDate);
            experience.SetDescription(description);
            experience.SetMissions(_missions);
            return experience;
        }

        private void SetProjectName(string? projectName)
        {
            ProjectName = ValidateProjectName(projectName);
        }

        private void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }

        private void SetStartDate(DateTime startDate)
        {
            StartDate = startDate;
        }

        private void SetPosition(string? position)
        {
                Position = ValidatePosition(position);
        }

        /// <summary>
        /// Sets the company name for the experience.
        /// This method allows you to set the company name for the experience.
        /// It is important to ensure that the company name being set is not null or empty,
        /// and meets the length requirements.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="BusinessRuleViolationException"></exception>
        public void SetCompany(string? value)
        {
            try
            {
                Company = ValidateCompany(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

       /// <summary>
       ///  Sets the description for the experience.
       ///  This method allows you to set the description for the experience.
       ///  It is important to ensure that the description being set is not null or empty,
       ///  and meets the length requirements.
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

        public void SetStackTechnologies(string? value)
        {
            try
            {
                StackTechnologies = ValidateStackTechnologies(value);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, ex);
            }
        }

        public void SetMissions(params string[] value)
        {
            foreach (var result in value)
            {
                string valueValidate = ValidateMission(result);
                if(!_missions.Contains(valueValidate))
                    _missions.Add(valueValidate);
                else
                    _missions = _missions.Select(x => x == valueValidate ? valueValidate : x).ToList();
            }
        }

        public void AddMissions(params string[] value)
        {
            foreach (var result in value)
            {
                string valueValidate = ValidateMission(result);
                if(!_missions.Contains(valueValidate))
                    _missions.Add(valueValidate);
                else
                    _missions = _missions.Select(x => x == valueValidate ? valueValidate : x).ToList();
            }
        }

        public void RemoveMissions(params string[] value)
        {
            foreach (var result in value)
            {
                string valueValidate = ValidateMission(result);
                if(_missions.Contains(valueValidate))
                    _missions.Remove(valueValidate);
            }
        }

        private static string ValidateProjectName(string? value)
        {
            return value?? string.Empty;
        }

        private static string ValidateDescription(string? value)
        {
            // Descrition bulk can be empty, but not null
            return value?? string.Empty;
        }

        private static string ValidatePosition(string? value)
        {
            // Position bulk can be empty, but not null
            return value?? string.Empty;
        }
        
        private static string ValidateCompany(string? value)
        {
            return value?? string.Empty;
        }

        private static DateTime ValidateStartDate(string value)
        {
            return DateTime.Parse(value);
        }

        private static DateTime ValidateEndDate(string value)
        {
            return DateTime.Parse(value);
        }

        private static string ValidateStackTechnologies(string? value)
        {
            return value?? string.Empty;
        }

        private static string ValidateMission(string? value)
        {
            return value?? string.Empty;
        }
    }
}