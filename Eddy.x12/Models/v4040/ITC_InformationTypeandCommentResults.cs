using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("ITC")]
public class ITC_InformationTypeAndCommentResults : EdiX12Segment
{
	[Position(01)]
	public string InformationRequestResultCode { get; set; }

	[Position(02)]
	public string InformationType { get; set; }

	[Position(03)]
	public string InformationStatusCode { get; set; }

	[Position(04)]
	public string ActionCode { get; set; }

	[Position(05)]
	public string FinancialInformationTypeCode { get; set; }

	[Position(06)]
	public string ConsolidationCode { get; set; }

	[Position(07)]
	public string ConditionIndicator { get; set; }

	[Position(08)]
	public string FinancialStatementFormatCode { get; set; }

	[Position(09)]
	public string FreeFormMessage { get; set; }

	[Position(10)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(11)]
	public string Description { get; set; }

	[Position(12)]
	public string SourceOfDisclosureCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITC_InformationTypeAndCommentResults>(this);
		validator.Required(x=>x.InformationRequestResultCode);
		validator.ARequiresB(x=>x.InformationStatusCode, x=>x.InformationType);
		validator.ARequiresB(x=>x.ActionCode, x=>x.InformationType);
		validator.OnlyOneOf(x=>x.FinancialInformationTypeCode, x=>x.FreeFormMessage);
		validator.ARequiresB(x=>x.ConsolidationCode, x=>x.FinancialInformationTypeCode);
		validator.ARequiresB(x=>x.ConditionIndicator, x=>x.FinancialInformationTypeCode);
		validator.ARequiresB(x=>x.FinancialStatementFormatCode, x=>x.FinancialInformationTypeCode);
		validator.OnlyOneOf(x=>x.UnitOfTimePeriodOrInterval, x=>x.Description);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.UnitOfTimePeriodOrInterval, x=>x.FinancialInformationTypeCode, x=>x.FreeFormMessage);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Description, x=>x.FinancialInformationTypeCode, x=>x.FreeFormMessage);
		validator.Length(x => x.InformationRequestResultCode, 1);
		validator.Length(x => x.InformationType, 2);
		validator.Length(x => x.InformationStatusCode, 1);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.FinancialInformationTypeCode, 1);
		validator.Length(x => x.ConsolidationCode, 1);
		validator.Length(x => x.ConditionIndicator, 2, 3);
		validator.Length(x => x.FinancialStatementFormatCode, 1);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.SourceOfDisclosureCode, 1);
		return validator.Results;
	}
}
