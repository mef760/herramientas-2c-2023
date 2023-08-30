using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace clase1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public List<string> Profesiones { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        var list = new List<string>();

        list.Add("Vendedor");
        list.Add("Analista funcional");
        list.Add("Analista QA");
        list.Add("Profesor");
        list.Add("Politico");

        Profesiones = list;
    }
}
