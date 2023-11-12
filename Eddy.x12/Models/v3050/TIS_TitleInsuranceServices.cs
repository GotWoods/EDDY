using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("TIS")]
public class TIS_TitleInsuranceServices : EdiX12Segment
{
	[Position(01)]
	public string TitleInsuranceServicesCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public int? Century { get; set; }

	[Position(04)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(05)]
	public string ProductServiceID { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TIS_TitleInsuranceServices>(this);
		validator.Required(x=>x.TitleInsuranceServicesCode);
		validator.ARequiresB(x=>x.Century, x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.Length(x => x.TitleInsuranceServicesCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Century, 2);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		return validator.Results;
	}
}
