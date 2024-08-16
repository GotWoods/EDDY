using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Models.D00B;

[Segment("HDR")]
public class HDR_HeaderInformation : EdifactSegment
{
	[Position(1)]
	public string StatusDescriptionCode { get; set; }

	[Position(2)]
	public E013_DateAndTimeInformation DateAndTimeInformation { get; set; }

	[Position(3)]
	public string ReferenceIdentifier { get; set; }

	[Position(4)]
	public string FreeTextValue { get; set; }

	[Position(5)]
	public string ProductIdentifier { get; set; }

	[Position(6)]
	public string LanguageNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HDR_HeaderInformation>(this);
		validator.Required(x=>x.StatusDescriptionCode);
		validator.Required(x=>x.DateAndTimeInformation);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.ReferenceIdentifier, 1, 70);
		validator.Length(x => x.FreeTextValue, 1, 512);
		validator.Length(x => x.ProductIdentifier, 1, 35);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		return validator.Results;
	}
}
