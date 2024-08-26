using BC.RecordUseExample.Backend.Domain.Validation;

namespace BC.RecordUseExample.Backend.Domain.BaseTypes
{
    public record struct BirthDate : IBaseType
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

        private readonly DateTime? _birthDate;
        public readonly DateTime? Value => _birthDate;


        public BirthDate(DateTime? birthDate)
        {
            _error ??= string.Empty;

            Error = Validate.Value(birthDate).Where(a => !a.HasValue, "Favor entrar Fecha de nacimiento.");
            if (Error != string.Empty)
            {
                return;
            }

            Error = Validate.Value(birthDate).Where(a => a < new DateTime(DateTime.Now.Year - 125, DateTime.Now.Month, DateTime.Now.Day), "Fecha de nacimiento incorrecta: Persona no puede tener más de 125 años.");
            Error = Validate.Value(birthDate).Where(a => a > DateTime.Now, "Fecha de nacimiento incorrecta: Fechas futuras no son permitidas.");

            if (Error != string.Empty)
            {
                return;
            }

            _birthDate = birthDate;
        }


        public override string? ToString() => _birthDate?.ToShortDateString();

        public static implicit operator DateTime?(BirthDate d) => d.Value;
        public static implicit operator BirthDate(DateTime? id) => new(id);

        public static implicit operator DateTime(BirthDate d) => d.Value ?? DateTime.MinValue;
        public static implicit operator BirthDate(DateTime id) => new(id);
    }
}
