using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("CLD")]
public class CLD_LoadDetail : EdiX12Segment
{
	[Position(01)]
	public int? NumberOfLoads { get; set; }

	[Position(02)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(03)]
	public string PackagingCode { get; set; }

	[Position(04)]
	public decimal? Size { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CLD_LoadDetail>(this);
		validator.Required(x=>x.NumberOfLoads);
		validator.Required(x=>x.NumberOfUnitsShipped);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode, x=>x.Size);
		validator.Length(x => x.NumberOfLoads, 1, 5);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.PackagingCode, 3, 5);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
