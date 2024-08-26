using BC.RecordUseExample.Backend.Domain.Validation;
using System.Reflection.Metadata.Ecma335;

namespace BC.RecordUseExample.Backend.Domain.BaseTypes
{
    public record struct Salary : IBaseType
    {
        private string _error = string.Empty;
        public readonly bool HasError => _error != string.Empty;
        public string Error
        {
            readonly get { return _error ?? string.Empty; }
            set
            {
                if (string.IsNullOrWhiteSpace(_error))
                {
                    _error = value;
                }
            }
        }

        private readonly decimal? _salary;
        public readonly decimal? Value => _salary;

       

        public Salary(decimal? salary)
        {
            _error ??= string.Empty;

            Error = Validate.Value(salary).Where(a => !a.HasValue, "Favor entrar el valor del Salario.");
            if (Error != string.Empty)
            {
                return;
            }

            Error = Validate.Value(salary).Where(a => a < decimal.Zero, "Salario no puede ser negativo.");
            Error = Validate.Value(salary).Where(a => a > 1_000_000M, "Salario no puede ser mayor de $1 millón.");

            if (Error != string.Empty)
            {
                return;
            }

            _salary = salary;
        }


        public override string? ToString() => _salary?.ToString();

        public static implicit operator decimal(Salary d) => d.Value ?? decimal.Zero;
        public static implicit operator Salary(decimal id) => new(id);

        public static implicit operator decimal?(Salary d) => d.Value;
        public static implicit operator Salary(decimal? id) => new(id);
    }
}
