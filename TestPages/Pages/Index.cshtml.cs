using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestPages.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, ILoggerProvider p)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _ = p ?? throw new ArgumentNullException(nameof(p));
    }

    public void OnGet()
    {
        this._logger.LogInformation("OnGet log");
    }
}
