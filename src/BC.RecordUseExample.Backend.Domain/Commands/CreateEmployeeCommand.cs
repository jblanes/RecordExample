using BC.RecordUseExample.Backend.Domain.BaseTypes;

namespace BC.RecordUseExample.UI.Razor.Commands
{
    public readonly record struct CreateEmployeeCommand(uint Id, BirthDate BirthDate, Salary Salary);
}
