using BasicWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasicWebApp.Pages;

public class NewsModel : PageModel
{
    private readonly ILogger<NewsModel> _logger;
    public List<NewsItem> newsItems;

    public NewsModel(ILogger<NewsModel> logger)
    {
        _logger = logger;
        newsItems = new List<NewsItem>()
        {
            new()
            {
                Title = "Nothing To Report", When = new DateTime(2026, 02, 03, 12, 00, 00),
                Story = "There is no news, except another war has occurred. Hopefully I don't die."
            }
        };
    }

    public void OnGet()
    {
    }

}
