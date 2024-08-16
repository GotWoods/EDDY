using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C222")]
public class C222_TransportIdentification : EdifactComponent
{
	[Position(1)]
	public string IdOfMeansOfTransportIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string IdOfTheMeansOfTransport { get; set; }

	[Position(5)]
	public string NationalityOfMeansOfTransportCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C222_TransportIdentification>(this);
		validator.Length(x => x.IdOfMeansOfTransportIdentification, 1, 9);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.IdOfTheMeansOfTransport, 1, 35);
		validator.Length(x => x.NationalityOfMeansOfTransportCoded, 1, 3);
		return validator.Results;
	}
}
