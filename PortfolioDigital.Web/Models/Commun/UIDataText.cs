using System.Diagnostics.SymbolStore;

namespace PortfolioDigital.Web.Models.Commun
{
    public static class UIDataText
    {
        // Homepage resscources
        public const string ProfileImageAlt = "assets/img/Moi.png";
        public const string CVImageAlt = "assets/ico/cv.ico";

        // User Information
        public const string FirstName = "Eric";
        public const string LastName = "ELEMBA ADI";
        public const string Email = "elembaadi@icloud.com";
        public const string Description = @"Développeur .NET passionné et polyvalent avec plus de 5 ans d’expérience professionnelle et académique dans le développement de solutions innovantes.\r\n 
                            Certifié Manager en systèmes d’information, développeur analyste développeur, j’ai construit ma carrière sur des bases solides en programmation, gestion de projets et migration vers le cloud.\r\n
                            Je maîtrise des technologies telles que C#, SQL, HTML5/CSS3 et des frameworks comme ASP.NET Core,MVC et Blazor, en intégrant des bases de données complexes grâce à SQL Server et des outils comme Entity Framework.\r\n
                            Mon expertise s’étend également aux méthodes Agiles, aux principes SOLID et aux design patterns.";
        public const string Profession = "Développeur .NET";
        public const string Address = "25 rue des Carmes, 67100 Strasbourg, France";
        public const string PhoneNumber = "+33 6 12 34 56 78";
        public const string GitHubUrl = "https://github.com/EEric7";

        // Skill Information
        public static readonly string[,] SkillLevels = new string[11, 3]
        {
            { "C#", "Advanced", "Languages" },
            { ".NET Core", "Advanced", "Frameworks" },
            { "ASP.NET Core", "Advanced", "Frameworks" },
            { "Entity Framework Core", "Advanced", "Frameworks" },
            { "SQL Server", "Intermediate", "Languages" },
            { "xUnit", "Intermediate", "Frameworks" },
            { "Agiles développement & Scrum", "Advanced", "Design" },
            { "Testing & Debugging", "Intermediate", "Design" },
            { "SOLID Principales", "Advanced", "Design" },
            { "HTML5/CSS3", "Advanced", "Languages" },
            { "Git", "Advanced", "Version Control" }
        };

        // Project Information
        public static readonly string[,] ProjectInformation = new string[3,4]
        {
            { "Service de gestion d'impression encoder", "Pilotage de projets clients de la phase d’analyse jusqu’au déploiement des solutions informatiques. Rédaction de cahiers des charges fonctionnels et techniques, développement, test et mise en production d’applications, participation à la gestion et à l’évolution du système d’information de l’entreprise.", "Apprentis manager en systèmes d'information", "assets/img/PID.jpg" },
            { "Signature électronique", "Participation à l’étude de faisabilité technique pour l’intégration de partenaires tiers, à la planification et au suivi des projets, ainsi qu’au développement de nouvelles fonctionnalités web services. Montée en compétence sur les technologies, processus métier, audite et outils internes de l’entreprise.", "Conseiller It", "assets/img/Wacken2.jpg"},
            { "Web Service de déploiement cognitif", "Participation à l’analyse des besoins d’évolution d’un web service de déploiement cognitif, à la modernisation de l’infrastructure pour une migration vers le cloud, ainsi qu’à la configuration des environnements de déploiement. Vérification de la compatibilité avec les normes et protocoles cloud et optimisation des performances du service après migration.", "Conseiller It", "assets/img/Wacken.jpg"}
        };
    }
}