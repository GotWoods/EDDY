using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("V2")]
public class V2_VesselInformation : EdiX12Segment
{
	[Position(01)]
	public string StandardPointLocationCode { get; set; }

	[Position(02)]
	public int? NetTonnage { get; set; }

	[Position(03)]
	public string StandardPointLocationCode2 { get; set; }

	[Position(04)]
	public string RegistryDate { get; set; }

	[Position(05)]
	public string Master { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<V2_VesselInformation>(this);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.NetTonnage);
		validator.Required(x=>x.StandardPointLocationCode2);
		validator.Required(x=>x.RegistryDate);
		validator.Required(x=>x.Master);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.NetTonnage, 2, 6);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		validator.Length(x => x.RegistryDate, 6);
		validator.Length(x => x.Master, 2, 18);
		return validator.Results;
	}
}
