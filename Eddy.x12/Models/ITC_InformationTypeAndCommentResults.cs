using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("ITC")]
public class ITC_InformationTypeAndCommentResults : EdiX12Segment
{
	[Position(01)]
	public string InformationRequestResultCode { get; set; }

	[Position(02)]
	public string InformationTypeCode { get; set; }

	[Position(03)]
	public string InformationStatusCode { get; set; }

	[Position(04)]
	public string ActionCode { get; set; }

	[Position(05)]
	public string FinancialInformationTypeCode { get; set; }

	[Position(06)]
	public string ConsolidationCode { get; set; }

	[Position(07)]
	public string ConditionIndicatorCode { get; set; }

	[Position(08)]
	public string FinancialStatementFormatCode { get; set; }

	[Position(09)]
	public string FreeFormInformation { get; set; }

	[Position(10)]
	public string UnitOfTimePeriodOrIntervalCode { get; set; }

	[Position(11)]
	public string Description { get; set; }

	[Position(12)]
	public string SourceOfDisclosureCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITC_InformationTypeAndCommentResults>(this);
		validator.Required(x=>x.InformationRequestResultCode);
		validator.ARequiresB(x=>x.InformationStatusCode, x=>x.InformationTypeCode);
		validator.ARequiresB(x=>x.ActionCode, x=>x.InformationTypeCode);
		validator.OnlyOneOf(x=>x.FinancialInformationTypeCode, x=>x.FreeFormInformation);
		validator.ARequiresB(x=>x.ConsolidationCode, x=>x.FinancialInformationTypeCode);
		validator.ARequiresB(x=>x.ConditionIndicatorCode, x=>x.FinancialInformationTypeCode);
		validator.ARequiresB(x=>x.FinancialStatementFormatCode, x=>x.FinancialInformationTypeCode);
		validator.OnlyOneOf(x=>x.UnitOfTimePeriodOrIntervalCode, x=>x.Description);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UnitOfTimePeriodOrIntervalCode, x=>x.FinancialInformationTypeCode, x=>x.FreeFormInformation);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Description, x=>x.FinancialInformationTypeCode, x=>x.FreeFormInformation);
		validator.Length(x => x.InformationRequestResultCode, 1);
		validator.Length(x => x.InformationTypeCode, 2);
		validator.Length(x => x.InformationStatusCode, 1);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.FinancialInformationTypeCode, 1);
		validator.Length(x => x.ConsolidationCode, 1);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		validator.Length(x => x.FinancialStatementFormatCode, 1);
		validator.Length(x => x.FreeFormInformation, 1, 30);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.SourceOfDisclosureCode, 1);
		return validator.Results;
	}
}
