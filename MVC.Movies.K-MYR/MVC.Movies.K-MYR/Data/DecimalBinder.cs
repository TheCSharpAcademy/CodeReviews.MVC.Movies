using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;


namespace MVC.Movies.K_MYR.Data;

public class DecimalBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

        if (string.IsNullOrEmpty(valueProviderResult.FirstValue))
        {
            return Task.CompletedTask;
        }

        if (!decimal.TryParse(valueProviderResult.FirstValue.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
        {                
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Could not parse to decimal.");
            return Task.CompletedTask;                
        }

        bindingContext.Result = ModelBindingResult.Success(value);
        return Task.CompletedTask;
    }
}
