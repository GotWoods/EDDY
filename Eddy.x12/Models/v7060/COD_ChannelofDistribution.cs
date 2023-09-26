using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060;

[Segment("COD")]
public class COD_ChannelOfDistribution : EdiX12Segment
{
	[Position(01)]
	public string AgencyQualifierCode { get; set; }

	[Position(02)]
	public C070_CompositeChannelOfDistribution CompositeChannelOfDistribution { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<COD_ChannelOfDistribution>(this);
		validator.Required(x=>x.AgencyQualifierCode);
		validator.Required(x=>x.CompositeChannelOfDistribution);
		validator.Length(x => x.AgencyQualifierCode, 2);
		return validator.Results;
	}
}
