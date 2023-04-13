using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.Elements;

public class C703_NatureOfCargo : IElement
{
    [Position(1)]
    public string CargoTypeClassificationCode { get; set; }

    [Position(2)]
    public string CodeListIdentificationCode { get; set; }

    [Position(3)]
    public string CodeListResponsibleAgencyCode { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<C703_NatureOfCargo>(this);
        validator.Length(x => x.CargoTypeClassificationCode, 1, 3);
        validator.Length(x => x.CodeListIdentificationCode, 1, 17);
        validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
    }
}