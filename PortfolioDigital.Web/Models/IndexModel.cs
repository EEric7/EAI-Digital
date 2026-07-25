using Microsoft.AspNetCore.Mvc;
using PortfolioDigital.Web.Models.Commun;

namespace PortfolioDigital.Web.Models
{
    public class IndexHomeModel
    {
        [BindProperty]
        public List<Tuple<string, string>> MenuModel { get; set; } = Enumerable.Range(0, UIDataText.MenuItems.GetLength(0))
            .Select(i => new Tuple<string, string>(UIDataText.MenuItems[i, 0], UIDataText.MenuItems[i, 1]))
            .ToList();

        [BindProperty]
        public UserModel? UserModel { get; set; } = new UserModel();

        [BindProperty]
        public string[] IconsContactPath { get; set; } = UIDataText.IconsContactPath;

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

            for (int i = 0; i < UIDataText.ProjectInformation.GetLength(0); i++)
            {
                ProjectModelDisplay.Add(new ProjectModel
                {
                    Title = UIDataText.ProjectInformation[i, 0],
                    Description = UIDataText.ProjectInformation[i, 1],
                    Position = UIDataText.ProjectInformation[i, 2],
                    ImageUrl = UIDataText.ProjectInformation[i, 3],
                    StartDate = DateOnly.Parse(UIDataText.ProjectInformation[i, 4]),
                    EndDate = DateOnly.Parse(UIDataText.ProjectInformation[i, 5]),
                    Company = UIDataText.ProjectInformation[i, 6],
                    Location = UIDataText.ProjectInformation[i, 7],
                    Technologies = UIDataText.ProjectInformation[i, 8].Split('/'),
                    Missions = UIDataText.ProjectsMissions[i]
                });
            }
        }
    }
}