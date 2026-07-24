

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
        
        /// <summary>
        /// Company associated with the project.
        /// This property represents the name of the company or organization associated with the project.
        /// It provides context about the project and its affiliation.
        /// </summary>
        public string Company { get; set; } = string.Empty;

        /// <summary>
        /// Location of the project.
        /// This property represents the geographical location where the project took place or is associated with.
        /// It provides additional context about the project and can be useful for understanding its scope and relevance.
        /// The location can be a city, region, or country, depending on the nature of the project and its associated activities.
        /// It is important to provide accurate and relevant location information to enhance the understanding of the project and its context.
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Technologies used in the project.
        /// This property represents the list of technologies, tools, or frameworks that were utilized in the project.
        /// It provides insight into the technical aspects of the project and the skills required to complete it.
        /// The technologies can include programming languages, libraries, frameworks, databases, and other relevant tools that were employed during the development and implementation of the project.
        /// It is important to provide accurate and relevant technology information to showcase the technical expertise and capabilities demonstrated in the project.
        /// </summary>
        public string[] Technologies { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Missions or responsibilities associated with the project.
        /// This property represents the list of missions, tasks, or responsibilities that were undertaken during the project.
        /// It provides insight into the specific contributions and roles played by the individual or team involved in the project.
        /// The missions can include specific tasks, objectives, or deliverables that were accomplished during the project, highlighting the skills and expertise demonstrated in achieving project goals.
        /// It is important to provide accurate and relevant mission information to showcase the contributions and impact made during the project, as well as to provide a comprehensive understanding of the project experience and its associated responsibilities.
        /// </summary>
        public string[] Missions { get; set; } = Array.Empty<string>();
    }
}