using Eddy.Core.Attributes;
using Eddy.Core.EdiFact.Models.Elements;
using Eddy.Core.Validation;

namespace Eddy.Core.EdiFact.Models.Beta;

public class DTM_DateTimePeriod 
{
    [Position(1)]
    public C507_DateTimePeriod DateTimePeriod { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<DTM_DateTimePeriod> (this);
    }
}