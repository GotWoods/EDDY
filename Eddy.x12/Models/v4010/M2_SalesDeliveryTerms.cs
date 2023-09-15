using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("M2")]
public class M2_SalesDeliveryTerms : EdiX12Segment
{
	[Position(01)]
	public string SalesTermsCode { get; set; }

	[Position(02)]
	public string SalesReferenceNumber { get; set; }

	[Position(03)]
	public string SalesReferenceDate { get; set; }

	[Position(04)]
	public string TransportationTermsCode { get; set; }

	[Position(05)]
	public string SalesComment { get; set; }

	[Position(06)]
	public string DeliveryDate { get; set; }

	[Position(07)]
	public string LocationQualifier { get; set; }

	[Position(08)]
	public string LocationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M2_SalesDeliveryTerms>(this);
		validator.Required(x=>x.SalesTermsCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.Length(x => x.SalesTermsCode, 2);
		validator.Length(x => x.SalesReferenceNumber, 4, 6);
		validator.Length(x => x.SalesReferenceDate, 8);
		validator.Length(x => x.TransportationTermsCode, 3);
		validator.Length(x => x.SalesComment, 2, 30);
		validator.Length(x => x.DeliveryDate, 8);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		return validator.Results;
	}
}
