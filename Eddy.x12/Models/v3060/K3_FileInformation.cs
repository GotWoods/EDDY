using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("K3")]
public class K3_FileInformation : EdiX12Segment
{
	[Position(01)]
	public string FixedFormatInformation { get; set; }

	[Position(02)]
	public string RecordFormatCode { get; set; }

	[Position(03)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<K3_FileInformation>(this);
		validator.Required(x=>x.FixedFormatInformation);
		validator.Length(x => x.FixedFormatInformation, 1, 80);
		validator.Length(x => x.RecordFormatCode, 1, 2);
		return validator.Results;
	}
}
