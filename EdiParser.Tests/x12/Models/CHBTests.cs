using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CHBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CHB*s*G*rk*0*h*nK*K*i*M";

		var expected = new CHB_ChargebackInformation()
		{
			LocationQualifier = "s",
			LocationIdentifier = "G",
			ReasonStoppedWorkCode = "rk",
			ClaimTypeCode = "0",
			ClaimStatusCode = "h",
			EntityIdentifierCode = "nK",
			CreditDebitFlagCode = "K",
			IndustryCode = "i",
			AllowanceOrChargeIndicatorCode = "M",
		};

		var actual = Map.MapObject<CHB_ChargebackInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("s", "G", true)]
	[InlineData("", "G", false)]
	[InlineData("s", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new CHB_ChargebackInformation();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
