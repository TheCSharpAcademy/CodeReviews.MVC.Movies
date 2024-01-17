using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MVC.Movies.K_MYR.Data;

public class CustomModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
        {
            return new DecimalBinder();
        }

        return null;
    }

}
