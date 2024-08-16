using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C019Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "0:h:X:k";

		var expected = new C019_PaymentTerms()
		{
			PaymentTermsDescriptionIdentifier = "0",
			CodeListIdentificationCode = "h",
			CodeListResponsibleAgencyCode = "X",
			PaymentTermsDescription = "k",
		};

		var actual = Map.MapComposite<C019_PaymentTerms>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
