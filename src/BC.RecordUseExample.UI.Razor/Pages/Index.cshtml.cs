using BC.RecordUseExample.UI.Razor.Extensions;
using BC.RecordUseExample.UI.Razor.Services;
using BC.RecordUseExample.UI.Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BC.RecordUseExample.UI.Razor.Pages
{
    public class IndexModel(ILogger<IndexModel> logger, EmployeeService employeeService) : PageModel
    {
        private readonly ILogger<IndexModel> _logger = logger;
        private readonly EmployeeService _employeeService = employeeService;

        [BindProperty]
        public EmployeeViewModel EmployeeData { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Los datos entrados por el usuario se convierten a un comando, en este caso para crear un nuevo empleado.
                // El comando tiene campos de validación y al ser creado automáticamente indica si ha habido errores.
                // las validacioens se hacen por campos del comando como BirthDate y Salary que son autovalidados (ver el proyecto BC.RecordUseExample.Backend.Domain)
                var createEmployeeCmd = EmployeeData.ToCreateEmployeeCommand();

                // actualizar el ModelState con los posibles errores al crear el comando, si no hay errores, el ModelState queda inalterado
                ModelState.SetValidation("EmployeeData.Salary", createEmployeeCmd.Salary);
                ModelState.SetValidation("EmployeeData.BirthDate", createEmployeeCmd.BirthDate);

                // regresar si hay errores
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                // Ejecutar el comando, en este ejemplo con un simple servicio local que llama a la DB, pero el comando podría ser enviado a un API, Bus, etc para su procesamiento.
                // También se puede usar una librería como MediatR para ejecución de comandos
                // Nota: los comandos están en el proyecto de Domain, ya que pueden ser enviados o recibidos por cualquier proyecto (Infraestructura, Apps, API's, etc)
                await _employeeService.TryCreateAndSaveEmployeeAsync(createEmployeeCmd);

                // redireccionar a página de éxito, en este ejemplo un simple mensaje, pero normalmente algún tipo de listado que muestre la nueva entrada
                return RedirectToPage("/EmployeeCreated");
            }
            catch (Exception ex)  //En caso de errores graves (generalmente por pérdida de conexión a DB)
            {
                
                // log el error y relanzar para que se presente la página de error genérica (/Error)
                _logger.LogError(ex, ex.Message);
                throw;  
            }
        }
    }
}
