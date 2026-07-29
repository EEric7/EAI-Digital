using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioDigital.Web.Models;

namespace PortfolioDigital.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    // Model for the Accueil page
    [BindProperty]
    public IndexHomeModel? IndexHomeModel { get; private set; } = new IndexHomeModel();

    public void OnGet() {}
}
