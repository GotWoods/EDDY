using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C019Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Z:P:7:m";

		var expected = new C019_PaymentTerms()
		{
			PaymentTermsDescriptionIdentifier = "Z",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "7",
			PaymentTermsDescription = "m",
		};

		var actual = Map.MapComposite<C019_PaymentTerms>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
