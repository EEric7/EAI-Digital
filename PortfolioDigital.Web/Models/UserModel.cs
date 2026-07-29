using Microsoft.AspNetCore.Mvc;
using PortfolioDigital.Web.Models.Commun;

namespace PortfolioDigital.Web.Models
{
    public class UserModel
    {
        public UserModel() {}

        /// <summary>
        /// UserName of the admin user.
        /// This property represents the name of the admin user.
        /// It is typically used for display purposes in user interfaces.
        /// The name can be a full name or a username, depending on the application's requirements.
        /// </summary>
        [BindProperty]
        public string? UserName => string.Format("{0} {1}", FirstName, LastName);

        /// <summary>
        /// First name of the admin user.
        /// This property holds the first name of the admin user.
        /// It is used for personalization and identification within the application.
        /// </summary>
        [BindProperty]
        public string? FirstName => UIDataText.FirstName;

        /// <summary>
        /// Last name of the admin user.
        /// This property holds the last name of the admin user.
        /// It is used for personalization and identification within the application.
        /// </summary>
        [BindProperty]
        public string? LastName => UIDataText.LastName;

        /// <summary>
        /// Profile image alternative text for the admin user.
        /// This property provides alternative text for the profile image of the admin user.
        /// It is used for accessibility purposes, allowing screen readers to describe the image to visually impaired users.
        /// The alternative text should accurately describe the content and purpose of the image.
        /// </summary>
        [BindProperty]
        public string? ProfileImage => UIDataText.IconsPath?.Find(x => x.Item1 == "Profile")?.Item2;

        /// <summary>
        /// Email address of the admin user.
        /// This property holds the email address associated with the admin user.
        /// It is used for communication purposes, such as sending notifications or password reset links.
        /// The email should be a valid format and unique within the system.
        /// </summary>
        [BindProperty]
        public string? Email => UIDataText.Email;

        /// <summary>
        /// Phone number of the admin user.
        /// This property holds the phone number associated with the admin user.
        /// It is used for communication purposes, such as sending notifications or for contact information.
        /// The phone number should be a valid format and may include country code, area code, and the local number. It is important to ensure that the phone number is accurate and up-to-date
        /// </summary>
        [BindProperty]
        public string? PhoneNumber => UIDataText.PhoneNumber;

        /// <summary>
        ///  Description of the admin user.
        /// </summary>
        [BindProperty]
        public string? Description => UIDataText.Description;

        /// <summary>
        /// Profession of the admin user.
        /// This property represents the profession or job title of the admin user.
        /// It is used for display purposes and to provide additional context about the user's background and expertise
        /// </summary>
        [BindProperty]
        public string? Profession => UIDataText.Profession;

        /// <summary>
        /// Gets or sets the path to the CV (Curriculum Vitae) of the admin user.
        /// This property holds the file path or URL to the CV document associated with the admin user.
        /// It is used to provide access to the user's CV for download or viewing purposes.
        /// The CV path should point to a valid file location or a web address where the CV can be accessed. It is important to ensure that the CV is up-to-date and accurately represents the
        /// </summary>
        [BindProperty]
        public string? CVPath => UIDataText.CVPath;

        /// <summary>
        ///     Gets or sets the path to the Enseigne icon of the admin user.
        ///     This property holds the file path or URL to the Enseigne icon associated with the admin user.
        ///     It is used to provide access to the user's Enseigne icon for display purposes.
        /// </summary>
        [BindProperty]
        public string? EnseigneIcon => UIDataText.IconsPath?.Find(x => x.Item1 == "Company")?.Item2;

        [BindProperty]
        public string? Enseigne => UIDataText.FreelanceName;

        /// <summary>
        /// Gets or sets the postal address of the admin user.
        /// This property represents the postal address associated with the admin user.
        /// It is an optional field and can be null if the admin user does not have a postal address.
        /// The postal address is stored as a value object of type <see cref="PostalAddressDto"/>
        /// which encapsulates the details of the address, such as street, city, postal code, and country.
        /// </summary>
        [BindProperty]
        public string? Address => UIDataText.Address;

        /// <summary>
        /// GitHub URL of the admin user.
        /// This property holds the URL to the admin user's GitHub profile.
        /// It is used to showcase the user's projects and contributions on GitHub.
        /// The URL should be a valid web address pointing to the user's GitHub page.
        /// </summary>
        [BindProperty]
        public string? GitHubUrl => UIDataText.GitHubUrl;

        /// <summary>
        /// Gets or sets the LinkedIn URL of the admin user.
        /// This property holds the URL to the admin user's LinkedIn profile.
        /// It is used to showcase the user's professional background and connections on LinkedIn.
        /// The URL should be a valid web address pointing to the user's LinkedIn page. 
        /// </summary>
        [BindProperty]
        public string[,]? Prestations => UIDataText.Prestations;

        /// <summary>
        /// Gets or sets the service logo path folder for the admin user.
        /// This property represents the folder path where the service logos are stored for the admin user.
        /// It is used to retrieve the logos associated with the services offered by the admin user.
        /// The folder path should be a valid directory path on the server or a relative path within the application. It is important to ensure that the folder path is accessible and contains the necessary logo files    
        /// </summary>
        public string[,]? ServiceLogoPath => UIDataText.ServicesIconPath;
    }
}