using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5050;

[Segment("M7A")]
public class M7A_SealNumberReplacement : EdiX12Segment
{
	[Position(01)]
	public string SealNumber { get; set; }

	[Position(02)]
	public string SealNumber2 { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string EntityIdentifierCode { get; set; }

	[Position(05)]
	public string Name { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public string LocationOnEquipment { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M7A_SealNumberReplacement>(this);
		validator.Required(x=>x.SealNumber);
		validator.Required(x=>x.SealNumber2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EntityIdentifierCode, x=>x.Name);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.SealNumber2, 2, 15);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.LocationOnEquipment, 1, 3);
		return validator.Results;
	}
}
