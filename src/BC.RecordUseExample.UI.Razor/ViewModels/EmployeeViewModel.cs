using BC.RecordUseExample.UI.Razor.Commands;
using System.ComponentModel.DataAnnotations;

namespace BC.RecordUseExample.UI.Razor.ViewModels
{

    public class EmployeeViewModel
    {
        public uint Id { get; set; }

        public DateTime? BirthDate { get; set; } = null;

        public decimal? Salary { get; set; } = null;

        public CreateEmployeeCommand ToCreateEmployeeCommand() => new() { Id = Id, BirthDate = BirthDate, Salary = Salary };
    }
}
