using BC.RecordUseExample.Backend.Infrastructure;
using BC.RecordUseExample.Backend.Infrastructure.DbModels;
using BC.RecordUseExample.UI.Razor.Commands;

namespace BC.RecordUseExample.UI.Razor.Services
{
    public class EmployeeService(SqlDbContext db)
    {
        public readonly SqlDbContext _db = db;

        public async Task TryCreateAndSaveEmployeeAsync(CreateEmployeeCommand createEmployeeCommand)
        {
            // Convierte el comando a modelo de Base de datos y lo guarda.
            // Al estar el comando ya validado, no es necesário código de validación aquí.
            // Si el Save falla es por errores a conexión de base de datos, que se pueden mitigar con retries automáticos usando librerías como Polly, etc.
            Employee employee = Employee.MapFromCreateEmployeeCommand(createEmployeeCommand);
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
        }
    }
}
