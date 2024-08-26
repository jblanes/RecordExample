namespace BC.RecordUseExample.Backend.Domain.BaseTypes
{
    public interface IBaseType
    {
        bool HasError { get; }
        string Error { get; }
    }
}
