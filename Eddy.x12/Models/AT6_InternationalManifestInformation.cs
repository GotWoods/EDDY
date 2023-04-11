using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("AT6")]
public class AT6_InternationalManifestInformation : EdiX12Segment 
{
	[Position(01)]
	public string InternationalDutiableStatusCode { get; set; }

	[Position(02)]
	public string ImportExportCode { get; set; }

	[Position(03)]
	public string TransportationTermsCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AT6_InternationalManifestInformation>(this);
		validator.Required(x=>x.InternationalDutiableStatusCode);
		validator.Required(x=>x.ImportExportCode);
		validator.Length(x => x.InternationalDutiableStatusCode, 2);
		validator.Length(x => x.ImportExportCode, 1);
		validator.Length(x => x.TransportationTermsCode, 3);
		return validator.Results;
	}
}
