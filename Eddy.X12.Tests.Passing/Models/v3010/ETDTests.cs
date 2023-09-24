using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ETDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ETD*x*9*bZ*c*4";

		var expected = new ETD_ExcessTransportationDetail()
		{
			ExcessTransportationReasonCode = "x",
			ExcessTransportationResponsibilityCode = "9",
			ReferenceNumberQualifier = "bZ",
			ReferenceNumber = "c",
			ReturnableContainerFreightPaymentResponsibilityCode = "4",
		};

		var actual = Map.MapObject<ETD_ExcessTransportationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredExcessTransportationReasonCode(string excessTransportationReasonCode, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationResponsibilityCode = "9";
		subject.ExcessTransportationReasonCode = excessTransportationReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredExcessTransportationResponsibilityCode(string excessTransportationResponsibilityCode, bool isValidExpected)
	{
		var subject = new ETD_ExcessTransportationDetail();
		subject.ExcessTransportationReasonCode = "x";
		subject.ExcessTransportationResponsibilityCode = excessTransportationResponsibilityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
