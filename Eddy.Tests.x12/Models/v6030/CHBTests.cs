using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CHBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CHB*C*4*T8*U*P*Sz*8*5*a";

		var expected = new CHB_ChargebackInformation()
		{
			LocationQualifier = "C",
			LocationIdentifier = "4",
			ReasonStoppedWorkCode = "T8",
			ClaimTypeCode = "U",
			ClaimStatusCode = "P",
			EntityIdentifierCode = "Sz",
			CreditDebitFlagCode = "8",
			IndustryCode = "5",
			AllowanceOrChargeIndicatorCode = "a",
		};

		var actual = Map.MapObject<CHB_ChargebackInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "4", true)]
	[InlineData("C", "", false)]
	[InlineData("", "4", false)]
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
