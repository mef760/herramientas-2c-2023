using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace clase2.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    [DisplayName("Nombre de usuario")]
    [Required]
    public string UserName { get; set; }
    [DisplayName("Correo electronico")]
    [Required]
    public string Mail { get; set; }
    [Range(18, 99)]
    public int Age { get; set; }
    public string Telephone { get; set; }
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        UserName = "usuario nuevo";
    }

    public void OnPost(IndexModel obj){
        if(!ModelState.IsValid)
        {
           // logica de validacion
        }

        var name = obj.UserName;
        var mail = obj.Mail;
    }
}
