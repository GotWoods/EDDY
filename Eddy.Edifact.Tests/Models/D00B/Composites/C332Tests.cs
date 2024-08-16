using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C332Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:9:p";

		var expected = new C332_SalesChannelIdentification()
		{
			SalesChannelIdentifier = "x",
			CodeListIdentificationCode = "9",
			CodeListResponsibleAgencyCode = "p",
		};

		var actual = Map.MapComposite<C332_SalesChannelIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredSalesChannelIdentifier(string salesChannelIdentifier, bool isValidExpected)
	{
		var subject = new C332_SalesChannelIdentification();
		//Required fields
		//Test Parameters
		subject.SalesChannelIdentifier = salesChannelIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
