using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCL*L*0*h*4*u*D*wC*S*S*u";

		var expected = new SCL_RateBasisScales()
		{
			RateBasisQualifier = "L",
			RateBasisNumber = "0",
			RateBasisNumber2 = "h",
			LocationQualifier = "4",
			LocationIdentifier = "u",
			LocationIdentifier2 = "D",
			StateOrProvinceCode = "wC",
			TariffAddOnFactor = "S",
			TariffClassAdjustmentReference = "S",
			TariffClassAdjustmentReference2 = "u",
		};

		var actual = Map.MapObject<SCL_RateBasisScales>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredRateBasisQualifier(string rateBasisQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = rateBasisQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "0", true)]
	[InlineData("h", "", false)]
	public void Validation_ARequiresBRateBasisNumber2(string rateBasisNumber2, string rateBasisNumber, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "L";
		subject.RateBasisNumber2 = rateBasisNumber2;
		subject.RateBasisNumber = rateBasisNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "4", true)]
	[InlineData("u", "", false)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "L";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "u", true)]
	[InlineData("D", "", false)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "L";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "4", true)]
	[InlineData("wC", "", false)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string locationQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "L";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.LocationQualifier = locationQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
