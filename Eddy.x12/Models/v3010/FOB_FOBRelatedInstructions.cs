using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("FOB")]
public class FOB_FOBRelatedInstructions : EdiX12Segment
{
	[Position(01)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(02)]
	public string LocationQualifier { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string TransportationTermsQualifierCode { get; set; }

	[Position(05)]
	public string TransportationTermsCode { get; set; }

	[Position(06)]
	public string LocationQualifier2 { get; set; }

	[Position(07)]
	public string Description2 { get; set; }

	[Position(08)]
	public string RiskOfLossQualifier { get; set; }

	[Position(09)]
	public string Description3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FOB_FOBRelatedInstructions>(this);
		validator.Required(x=>x.ShipmentMethodOfPayment);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.TransportationTermsQualifierCode, 2);
		validator.Length(x => x.TransportationTermsCode, 3);
		validator.Length(x => x.LocationQualifier2, 1, 2);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.RiskOfLossQualifier, 2);
		validator.Length(x => x.Description3, 1, 80);
		return validator.Results;
	}
}
