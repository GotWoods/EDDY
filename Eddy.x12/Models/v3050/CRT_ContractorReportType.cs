using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050.Composites;

namespace Eddy.x12.Models.v3050;

[Segment("CRT")]
public class CRT_ContractorReportType : EdiX12Segment
{
	[Position(01)]
	public string ReportTypeCode { get; set; }

	[Position(02)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure2 { get; set; }

	[Position(04)]
	public string BreakdownStructureDetailCode { get; set; }

	[Position(05)]
	public string ActionCode { get; set; }

	[Position(06)]
	public string RateOrValueTypeCode { get; set; }

	[Position(07)]
	public string ContractActionCode { get; set; }

	[Position(08)]
	public string ProgramTypeCode { get; set; }

	[Position(09)]
	public string FreeFormDescription { get; set; }

	[Position(10)]
	public string SecurityLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRT_ContractorReportType>(this);
		validator.Required(x=>x.ReportTypeCode);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.BreakdownStructureDetailCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.RateOrValueTypeCode, 1, 2);
		validator.Length(x => x.ContractActionCode, 2);
		validator.Length(x => x.ProgramTypeCode, 2);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.SecurityLevelCode, 2);
		return validator.Results;
	}
}
