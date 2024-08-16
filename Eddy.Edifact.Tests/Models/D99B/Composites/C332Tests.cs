using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C332Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:Z:G";

		var expected = new C332_SalesChannelIdentification()
		{
			SalesChannelIdentifier = "M",
			CodeListIdentificationCode = "Z",
			CodeListResponsibleAgencyCode = "G",
		};

		var actual = Map.MapComposite<C332_SalesChannelIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredSalesChannelIdentifier(string salesChannelIdentifier, bool isValidExpected)
	{
		var subject = new C332_SalesChannelIdentification();
		//Required fields
		//Test Parameters
		subject.SalesChannelIdentifier = salesChannelIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
