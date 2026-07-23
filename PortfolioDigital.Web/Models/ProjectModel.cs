

namespace PortfolioDigital.Web.Models
{
    public class ProjectModel
    {
        /// <summary>
        /// Title of the project.
        /// This property represents the name or title of the project.
        /// It is a required field and should be descriptive enough to give an idea of what the project is about.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description of the project.
        /// This property provides a detailed description of the project, including its purpose, features, and any other relevant information.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Position held during the experience.
        /// This property represents the position or job title held during the experience.
        /// It is a required field and should be descriptive enough to give an idea of the role
        /// and responsibilities associated with the experience.
        /// </summary>
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// Start date of the project.
        /// This property represents the date when the project started.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// End date of the project.
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// URL of the project.
        /// This property represents the URL where the project can be accessed or viewed.
        /// It is typically a web address that points to the project's homepage or repository.
        /// This URL is used to provide users with direct access to the project online.
        /// It is important that this URL is valid and accessible.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}