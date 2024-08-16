using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C332Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:q:i";

		var expected = new C332_SalesChannelIdentification()
		{
			SalesChannelIdentifier = "b",
			CodeListQualifier = "q",
			CodeListResponsibleAgencyCoded = "i",
		};

		var actual = Map.MapComposite<C332_SalesChannelIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredSalesChannelIdentifier(string salesChannelIdentifier, bool isValidExpected)
	{
		var subject = new C332_SalesChannelIdentification();
		//Required fields
		//Test Parameters
		subject.SalesChannelIdentifier = salesChannelIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
