using Microsoft.AspNetCore.Mvc;

namespace PortfolioDigital.Web.Models
{
    public class SkillModel
    {
        /// <summary>
        /// Name of the skill.
        /// </summary>
        [BindProperty]
        public string? Name { get; set; }

        /// <summary>
        /// Level of proficiency in the skill.
        /// </summary>
        [BindProperty]
        public string? Level { get; set; }


        /// <summary>
        /// Category of the skill, such as frontend, backend, fullstack, devops, etc.
        /// </summary>
        [BindProperty]
        public string? Category { get; set; }
    }
}