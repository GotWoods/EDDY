using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("TVL")]
public class TVL_TravelProductInformation : EdifactSegment
{
	[Position(1)]
	public E987_ProductDateAndTime ProductDateAndTime { get; set; }

	[Position(2)]
	public E975_Location Location { get; set; }

	[Position(3)]
	public E988_CompanyIdentification CompanyIdentification { get; set; }

	[Position(4)]
	public E989_ProductIdentificationDetails ProductIdentificationDetails { get; set; }

	[Position(5)]
	public E990_SequenceNumberDetails SequenceNumberDetails { get; set; }

	[Position(6)]
	public string LineItemNumber { get; set; }

	[Position(7)]
	public string ProcessingIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TVL_TravelProductInformation>(this);
		validator.Length(x => x.LineItemNumber, 1, 6);
		validator.Length(x => x.ProcessingIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
