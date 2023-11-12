using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CHBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CHB*w*Z*mF*K*9*hy*b*a*p";

		var expected = new CHB_ChargebackInformation()
		{
			LocationQualifier = "w",
			LocationIdentifier = "Z",
			ReasonStoppedWorkCode = "mF",
			ClaimTypeCode = "K",
			ClaimStatusCode = "9",
			EntityIdentifierCode = "hy",
			CreditDebitFlagCode = "b",
			IndustryCode = "a",
			AllowanceOrChargeIndicator = "p",
		};

		var actual = Map.MapObject<CHB_ChargebackInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "Z", true)]
	[InlineData("w", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new CHB_ChargebackInformation();
		//Required fields
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
