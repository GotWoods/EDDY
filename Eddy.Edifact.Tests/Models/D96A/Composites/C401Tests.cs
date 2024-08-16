using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C401Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "g:u:r";

		var expected = new C401_ExcessTransportationInformation()
		{
			ExcessTransportationReasonCoded = "g",
			ExcessTransportationResponsibilityCoded = "u",
			CustomerAuthorizationNumber = "r",
		};

		var actual = Map.MapComposite<C401_ExcessTransportationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredExcessTransportationReasonCoded(string excessTransportationReasonCoded, bool isValidExpected)
	{
		var subject = new C401_ExcessTransportationInformation();
		//Required fields
		subject.ExcessTransportationResponsibilityCoded = "u";
		//Test Parameters
		subject.ExcessTransportationReasonCoded = excessTransportationReasonCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredExcessTransportationResponsibilityCoded(string excessTransportationResponsibilityCoded, bool isValidExpected)
	{
		var subject = new C401_ExcessTransportationInformation();
		//Required fields
		subject.ExcessTransportationReasonCoded = "g";
		//Test Parameters
		subject.ExcessTransportationResponsibilityCoded = excessTransportationResponsibilityCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
