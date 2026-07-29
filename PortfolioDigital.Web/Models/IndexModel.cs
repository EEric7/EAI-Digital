using Microsoft.AspNetCore.Mvc;
using PortfolioDigital.Web.Models.Commun;

namespace PortfolioDigital.Web.Models
{
    public class IndexHomeModel
    {
        [BindProperty]
        public List<(string Name, string Path)>? MenuModel { get; private set; }

        [BindProperty]
        public UserModel? UserModel { get; private set; }

        [BindProperty]
        public List<(string Name, string Path)>? IconsPath { get; private set; }

        [BindProperty]
        public string[,]? ServiceIconPath { get; private set; }

        [BindProperty]
        public List<SkillModel>? SkillsModelDisplay { get;private set; }

        [BindProperty]
        public List<ProjectModel>? ProjectModelDisplay { get;private set; }

        public IndexHomeModel()
        {
            UserModel = new UserModel();
            MenuModel = UIText.MenuItems.Select(x => (x.Item1, x.Item2)).ToList();
            IconsPath = UIDataText.IconsPath?.Select(x => (x.Item1, x.Item2)).ToList();
            ServiceIconPath = UIDataText.ServicesIconPath;

            SkillsModelDisplay = new List<SkillModel>();
            for (int i = 0; i < UIDataText.SkillLevels.GetLength(0); i++)
            {
                SkillsModelDisplay.Add(new SkillModel
                {
                    Name = UIDataText.SkillLevels[i, 0],
                    Level = UIDataText.SkillLevels[i, 1],
                    Category = UIDataText.SkillLevels[i, 2]
                });
            }

            ProjectModelDisplay = new List<ProjectModel>();
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