using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasicWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string ClientIp { get; private set; } = "Unknown";
    public string ClientOs { get; private set; } = "Unknown";
    public string ClientBrowser { get; private set; } = "Unknown";
    public string ClientColor { get; private set; } = "black";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        ClientIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
        var userAgent = Request.Headers["User-Agent"].ToString();

        ClientOs = DetermineOperatingSystem(userAgent);
        ClientBrowser = DetermineBrowser(userAgent);
        ClientColor = GetColorForOs(ClientOs);
        
        _logger.LogInformation("Frontpage Loaded");
    }

    private static string DetermineOperatingSystem(string userAgent)
    {
        if (string.IsNullOrWhiteSpace(userAgent))
        {
            return "Unknown";
        }

        if (userAgent.Contains("Windows", StringComparison.OrdinalIgnoreCase))
        {
            return "Windows";
        }

        if (userAgent.Contains("Mac OS X", StringComparison.OrdinalIgnoreCase) ||
            userAgent.Contains("Macintosh", StringComparison.OrdinalIgnoreCase))
        {
            return "macOS";
        }

        if (userAgent.Contains("Android", StringComparison.OrdinalIgnoreCase))
        {
            return "Android";
        }

        return "Unknown";
    }

    private static string DetermineBrowser(string userAgent)
    {
        if (string.IsNullOrWhiteSpace(userAgent))
        {
            return "Unknown";
        }

        if (userAgent.Contains("Edg", StringComparison.OrdinalIgnoreCase))
        {
            return "Microsoft Edge";
        }

        if (userAgent.Contains("Firefox", StringComparison.OrdinalIgnoreCase))
        {
            return "Firefox";
        }

        if (userAgent.Contains("Chrome", StringComparison.OrdinalIgnoreCase))
        {
            return "Chrome";
        }

        if (userAgent.Contains("Safari", StringComparison.OrdinalIgnoreCase))
        {
            return "Safari";
        }

        return "Unknown";
    }

    private static string GetColorForOs(string os)
    {
        return os switch
        {
            "Windows" => "red",
            "macOS" => "blue",
            "Android" => "green",
            _ => "black"
        };
    }
}
