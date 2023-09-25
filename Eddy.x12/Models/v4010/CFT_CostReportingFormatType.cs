using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("CFT")]
public class CFT_CostReportingFormatType : EdiX12Segment
{
	[Position(01)]
	public string ReportTypeCode { get; set; }

	[Position(02)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(03)]
	public string ContractingFundingCode { get; set; }

	[Position(04)]
	public string DateTimeQualifier { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string DateTimeQualifier2 { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public string AppropriationCode { get; set; }

	[Position(09)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CFT_CostReportingFormatType>(this);
		validator.Required(x=>x.ReportTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimeQualifier, x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimeQualifier2, x=>x.Date2);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.ContractingFundingCode, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.AppropriationCode, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
