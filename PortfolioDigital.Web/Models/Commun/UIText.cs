namespace PortfolioDigital.Web.Models.Commun
{
    public static class UIText
    {
        public static readonly List<(string Name, string Path)> MenuItems = new List<(string Name, string Path)>
        {
            new ("Services", "#services"),
            new ("Tarifs", "#tarifs"),
            new ("About", "#about"),
            new ("Contacts", "#contacts")
        };
        
        //Homepage dashboard
        public const string HomePageTitle = "Bienvenue sur mon portfolio";

        // Header Section
        public const string DefaultTitle = "Mon Portfolio";
        public const string DefaultProfession = "Profession inconnue";

        // Navigation and Actions
        public const string WhoAmIButton = "Qui-suis je?";
        
        // Section Headers
        public const string WhoAmIHeader = "Qui-suis je?";
        public const string AboutHeader = @"À propos";

        public const string AboutSubtitle = "Mes expériences professionnelles.";
        public const string ServicesTitle = "MES SERVICES";
        public const string TarifTitle = "Prestations et Tarifs";
        public const string ServicesSubtitle = "Transformez vos idées en solutions digitales.";
        public const string TarifSloganHeader = "L’expertise logicielle au service de votre croissance.";

        public const string TarifFormuleHeader = "Formule ";

        public const string TarifFromHeader = "À Partir de ";

        public const string Freelance = "Disponible pour des missions en freelance";
        public const string SkillsLanguageHeader = "PROGRAMMING LANGUAGE & TOOLS";
        public const string SkillsWorkflowHeader = "WORKFLOW";
        public const string ExperiencesHeader = "EXPERIENCE";
        public const string ContactsHeader = "Contacts";
        
        // Project Section
        public const string ProjectsTitle = "Built with ASP.NET Core Razor";
        public const string LinkGrayscale = "https://startbootstrap.com/theme/grayscale/";
        public const string ProjectsDescription = "Ce modèle est un thème Bootstrap gratuit créé par Start Bootstrap. Il peut être à vous dès maintenant : téléchargez simplement le modèle sur la page de prévisualisation. Le thème est open source, et vous pouvez l'utiliser à n'importe quelle fin, qu'elle soit personnelle ou commerciale.";
        
        // Contact Section
        public const string AddressLabel = "Adresse";
        public const string EmailLabel = "Email";
        public const string PhoneLabel = "Téléphone";
        
        // CV Section
        public const string CVHeader = "C.V";
        public const string DownloadLabel = "Télécharger";
        
        // Alt Text
        public const string ProfileImageAlt = "Photo de profil";
        public const string ProjectImageAlt = "Image du projet";
        public const string CVImageAlt = "C.V";
    }
}