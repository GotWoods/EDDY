using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("IN2")]
public class IN2_IndividualNameStructureComponents : EdiX12Segment
{
	[Position(01)]
	public string NameComponentQualifier { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string Name2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IN2_IndividualNameStructureComponents>(this);
		validator.Required(x=>x.NameComponentQualifier);
		validator.Required(x=>x.Name);
		validator.Length(x => x.NameComponentQualifier, 2);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Name2, 1, 60);
		return validator.Results;
	}
}
