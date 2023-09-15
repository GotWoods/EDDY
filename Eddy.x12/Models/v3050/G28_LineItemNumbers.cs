using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G28")]
public class G28_LineItemNumbers : EdiX12Segment
{
	[Position(01)]
	public string UPCCaseCode { get; set; }

	[Position(02)]
	public string UPCEANConsumerPackageCode { get; set; }

	[Position(03)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(04)]
	public string ProductServiceID { get; set; }

	[Position(05)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(06)]
	public string ProductServiceID2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G28_LineItemNumbers>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.UPCEANConsumerPackageCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 40);
		return validator.Results;
	}
}
