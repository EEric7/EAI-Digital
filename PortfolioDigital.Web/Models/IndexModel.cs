using Microsoft.AspNetCore.Mvc;
using PortfolioDigital.Web.Models.Commun;

namespace PortfolioDigital.Web.Models
{
    public class IndexHomeModel
    {
        [BindProperty]
        public List<Tuple<string, string>> MenuModel { get; set; } = new List<Tuple<string, string>>()
        {
            new Tuple<string, string>("About", "#about"),
            new Tuple<string, string>("Skills", "#skills"),
            new Tuple<string, string>("Projects", "#projects"),
            new Tuple<string, string>("Contacts", "#contacts")
        };

        [BindProperty]
        public UserModel? UserModel { get; set; } = new UserModel();

        [BindProperty]
        public List<SkillModel> SkillsModelDisplay { get; set; } = new List<SkillModel>();

        [BindProperty]
        public List<ProjectModel> ProjectModelDisplay { get; set; } = new List<ProjectModel>();

        public IndexHomeModel()
        {
            for (int i = 0; i < UIDataText.SkillLevels.GetLength(0); i++)
            {
                SkillsModelDisplay.Add(new SkillModel
                {
                    Name = UIDataText.SkillLevels[i, 0],
                    Level = UIDataText.SkillLevels[i, 1],
                    Category = UIDataText.SkillLevels[i, 2]
                });
            }
            
            ProjectModelDisplay.Add(new ProjectModel
            {
                Title = UIDataText.ProjectInformation[0, 0],
                Description = UIDataText.ProjectInformation[0, 1],
                Position = UIDataText.ProjectInformation[0, 2],
                StartDate = new DateOnly(2018, 9, 1),
                EndDate = new DateOnly(2021, 9, 1),
                ImageUrl = UIDataText.ProjectInformation[0, 3]
            });

            ProjectModelDisplay.Add(new ProjectModel
            {
                Title = UIDataText.ProjectInformation[1, 0],
                Description = UIDataText.ProjectInformation[1, 1],
                Position = UIDataText.ProjectInformation[1, 2],
                StartDate = new DateOnly(2022, 3, 1),
                EndDate = new DateOnly(2023, 2, 1),
                ImageUrl = UIDataText.ProjectInformation[1, 3]
            });

            ProjectModelDisplay.Add(new ProjectModel
            {
                Title = UIDataText.ProjectInformation[2, 0],
                Description = UIDataText.ProjectInformation[2, 1],
                Position = UIDataText.ProjectInformation[2, 2],
                StartDate = new DateOnly(2023, 4, 1),
                EndDate = new DateOnly(2024, 4, 1),
                ImageUrl = UIDataText.ProjectInformation[2, 3]
            });
        }
    }
}