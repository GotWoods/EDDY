using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C222")]
public class C222_TransportIdentification : EdifactComponent
{
	[Position(1)]
	public string TransportMeansIdentificationNameIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string TransportMeansIdentificationName { get; set; }

	[Position(5)]
	public string TransportMeansNationalityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C222_TransportIdentification>(this);
		validator.Length(x => x.TransportMeansIdentificationNameIdentifier, 1, 9);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.TransportMeansIdentificationName, 1, 35);
		validator.Length(x => x.TransportMeansNationalityCode, 1, 3);
		return validator.Results;
	}
}
