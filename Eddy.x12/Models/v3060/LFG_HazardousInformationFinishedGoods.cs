using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("LFG")]
public class LFG_HazardousInformationFinishedGoods : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	[Position(02)]
	public string HazardousClassification { get; set; }

	[Position(03)]
	public string UNNAIdentificationCode { get; set; }

	[Position(04)]
	public string HazardousPlacardNotation { get; set; }

	[Position(05)]
	public string PackingGroupCode { get; set; }

	[Position(06)]
	public string HazardousMaterialRegulationsExceptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LFG_HazardousInformationFinishedGoods>(this);
		validator.Required(x=>x.Description);
		validator.Required(x=>x.HazardousClassification);
		validator.Required(x=>x.UNNAIdentificationCode);
		validator.Required(x=>x.HazardousPlacardNotation);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.HazardousClassification, 1, 30);
		validator.Length(x => x.UNNAIdentificationCode, 6);
		validator.Length(x => x.HazardousPlacardNotation, 14, 40);
		validator.Length(x => x.PackingGroupCode, 1, 3);
		validator.Length(x => x.HazardousMaterialRegulationsExceptionCode, 1);
		return validator.Results;
	}
}
