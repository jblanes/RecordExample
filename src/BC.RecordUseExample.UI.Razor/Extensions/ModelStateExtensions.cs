using BC.RecordUseExample.Backend.Domain.BaseTypes;

namespace BC.RecordUseExample.UI.Razor.Extensions
{
    public static class ModelStateExtensions
    {
        public static void SetValidation(this Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState, string field, IBaseType baseType)
        {
            if (baseType.HasError)
            {
                modelState.AddModelError(field, baseType.Error);
            }
        }
    }
}
