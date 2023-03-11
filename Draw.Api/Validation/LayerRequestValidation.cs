using Draw.Api.Models.Layer;
using FluentValidation;

namespace Draw.Api.Validation
{
    public class LayerRequestValidation:AbstractValidator<LayerRequest>
    {
        public LayerRequestValidation()
        {
            RuleFor(x=>x.layers).NotEmpty().WithMessage("Layers is required");
            RuleForEach(x => x.layers).ChildRules(layer =>
            {
                layer.RuleFor(x => x.LayerName).NotNull().WithMessage("Layer Name is Required");
                layer.RuleFor(x => x.LayerThickness).NotNull().WithMessage("Layer Thickness Required");
            });          
        }
    }
}
