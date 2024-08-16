using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C401Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "5:0:C";

		var expected = new C401_ExcessTransportationInformation()
		{
			ExcessTransportationReasonCode = "5",
			ExcessTransportationResponsibilityCode = "0",
			CustomerShipmentAuthorisationIdentifier = "C",
		};

		var actual = Map.MapComposite<C401_ExcessTransportationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredExcessTransportationReasonCode(string excessTransportationReasonCode, bool isValidExpected)
	{
		var subject = new C401_ExcessTransportationInformation();
		//Required fields
		subject.ExcessTransportationResponsibilityCode = "0";
		//Test Parameters
		subject.ExcessTransportationReasonCode = excessTransportationReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredExcessTransportationResponsibilityCode(string excessTransportationResponsibilityCode, bool isValidExpected)
	{
		var subject = new C401_ExcessTransportationInformation();
		//Required fields
		subject.ExcessTransportationReasonCode = "5";
		//Test Parameters
		subject.ExcessTransportationResponsibilityCode = excessTransportationResponsibilityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
