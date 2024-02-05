using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v4020._815;

public class LCSC {
	[SectionPosition(1)] public CSC_CryptographicServiceMessageCertificatesAndKeys CryptographicServiceMessageCertificatesAndKeys { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCSC>(this);
		validator.Required(x => x.CryptographicServiceMessageCertificatesAndKeys);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 9);
		return validator.Results;
	}
}
