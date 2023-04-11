using Eddy.Core.Attributes;
using Eddy.Core.EdiFact.Models.Elements;
using Eddy.Core.Validation;

namespace Eddy.Core.EdiFact.Models.Beta;

public class CNT_ControlTotal
{
    [Position(1)]
    public C270_Control Control { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<CNT_ControlTotal>(this);
    }
}