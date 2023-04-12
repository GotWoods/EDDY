using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TIS")]
public class TIS_TitleInsuranceServices : EdiX12Segment
{
	[Position(01)]
	public string TitleInsuranceServicesCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(04)]
	public string ProductServiceID { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TIS_TitleInsuranceServices>(this);
		validator.Required(x=>x.TitleInsuranceServicesCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.Length(x => x.TitleInsuranceServicesCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		return validator.Results;
	}
}
