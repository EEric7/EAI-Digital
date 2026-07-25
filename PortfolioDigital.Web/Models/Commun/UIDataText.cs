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
        public const string FreelanceName = "EAI Digital";
        public const bool Available = true;

        // Skill Information
        public static readonly string[,] SkillLevels = new string[11, 3]
        {
            { "C#", "Advanced", "Language" },
            { ".NET Core", "Advanced", "Framework" },
            { "ASP.NET Core", "Advanced", "Framework" },
            { "Entity Framework Core", "Advanced", "Framework" },
            { "SQL Server", "Intermediate", "Language" },
            { "xUnit", "Intermediate", "Framework" },
            { "Agiles développement & Scrum", "Advanced", "Design" },
            { "Testing & Debugging", "Intermediate", "Design" },
            { "SOLID Principales", "Advanced", "Design" },
            { "HTML5/CSS3", "Advanced", "Language" },
            { "Git", "Advanced", "Version Control" }
        };

        // Project Information
        public static readonly string[,] ProjectInformation = new string[3,9]
        {
            { 
                "Project Applicationde gestion d'impression encoder",
                "Pilotage de développement d'un projet clients de la phase d’analyse jusqu’au déploiement des solutions informatiques.",
                "Apprentis manager en systèmes d'information", 
                "assets/img/PID.jpg",
                "2018-09-01",
                "2021-09-01",
                "Paragon ID",
                "Argent-sur-Sauldre",
                "C#/WPF/XML/.NET 4.6/ASP.NET Core/Entity Framework Core/Microservices/Dapper/API REST/SQL Server"
            },
            { 
                "Project Web Service Signature électronique",
                "L’étude de faisabilité technique pour l’intégration de partenaires tiers, ainsi qu’au développement de nouvelles fonctionnalités web services.",
                "Conseiller It", 
                "assets/img/Wacken2.jpg",
                "2022-03-01",
                "2023-02-01",
                "Euro Information",
                "Strasbourg",
                "C#/.NET/ASP.NET Core/SQL Server/Dapper/API REST/Microservices/Visual Studio/Git."
            },
            { 
                "Project Web Service de déploiement cognitif",
                "La modernisation de l’infrastructure pour une migration vers le cloud, ainsi qu’à la configuration des environnements de déploiement.",
                "Conseiller It", 
                "assets/img/Wacken.jpg",
                "2023-04-01",
                "2024-04-01",
                "Euro Information",
                "Strasbourg",
                "C#/.NET Core/ASP.NET Core/Entity Framework Core/SQL Server/API REST/Domain-Driven Design/Docker/Git/Visual Studio"
            }
        };

        public static readonly IList<string[]> ProjectsMissions = new List<string[]>
        {
            new string[]
            {
                "Participation au développement et à l’évolution d’une application métier dédiée à la gestion de l’impression et de la personnalisation de cartes.",
                "Analyse des besoins métiers et contribution à la conception des évolutions fonctionnelles.",
                "Développement de nouvelles fonctionnalités et réalisation de la maintenance corrective et évolutive.",
                "Intégration de périphériques d’impression et d’encodage de cartes.",
                "Conception et exécution de tests fonctionnels afin de valider les développements.",
                "Rédaction de documentation technique et de guides utilisateurs.",
                "Collaboration avec les équipes projets, les consultants et les parties prenantes.",
                "Veille technologique autour de l’écosystème .NET (ASP.NET Core MVC, WPF, WinForms, etc.)."
            },
            new string[]
            {
                "Contribution à l’évolution d’un service de signature utilisée dans un environnement bancaire.",
                "Étude et Intégration d’un nouveau prestataire de signature électronique.",
                "Analyse des besoins fonctionnels et techniques en collaboration avec les équipes métier.",
                "Développement et optimisation des services et traitement de l’API.",
                "Suivi du cycle de développement et coordination du projet.",
                "Veilles technologies sur les processus et outils EI."
            },
            new string[]
            {
                "Refonte d’un service web permettant le déploiement des solutions cognitive du groupe.",
                "Migration de l’application vers une infrastructure cloud privé afin d’améliorer la disponibilité et la maintenabilité.",
                "Développement et adaptation des services REST aux nouveaux standards de l’infrastructure.",
                "Participation à la configuration des environnements de deploiement.",
                "Assurer de la compatibilité avec les normes et les protocoles du cloud spécifique.",
                "Évolution et optimisation des performances après migration.",
                "Maintenance et évolution et correction de la plateforme."
            }
        };

        public static readonly string[,] SkillsLogoPathFolder = new string[4,3]
        {
            { "~/assets/img/Dev-logo.png", "Sur-Mesure" , "3000€"},
            { "~/assets/img/Bdd-logo.png", "BDD" , "1800€"},
            { "~/assets/img/Cld-logo.png", "Cloud", "1299€" },
            { "~/assets/img/Tools-logo.png", "Maintenance", "400€ /AN" }
        };

        public static readonly string[,] MenuItems = new string[4, 2]
        {
            { "Services", "#service" },
            { "Tarifs", "#tarifs" },
            { "About", "#about" },
            { "Contacts", "#contacts" }
        };
    }
}