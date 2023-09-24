using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCL*M*e*2*4*U*M*p0*U*r*J";

		var expected = new SCL_RateBasisScales()
		{
			RateBasisQualifier = "M",
			RateBasisNumber = "e",
			RateBasisNumber2 = "2",
			LocationQualifier = "4",
			LocationIdentifier = "U",
			LocationIdentifier2 = "M",
			StateOrProvinceCode = "p0",
			TariffAddOnFactor = "U",
			TariffClassAdjustmentReference = "r",
			TariffClassAdjustmentReference2 = "J",
		};

		var actual = Map.MapObject<SCL_RateBasisScales>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredRateBasisQualifier(string rateBasisQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = rateBasisQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "e", true)]
	[InlineData("2", "", false)]
	[InlineData("", "e", true)]
	public void Validation_ARequiresBRateBasisNumber2(string rateBasisNumber2, string rateBasisNumber, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "M";
		subject.RateBasisNumber2 = rateBasisNumber2;
		subject.RateBasisNumber = rateBasisNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "4", true)]
	[InlineData("U", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "M";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "U", true)]
	[InlineData("M", "", false)]
	[InlineData("", "U", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "M";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;
		if (locationIdentifier != "")
			subject.LocationQualifier = "4";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p0", "4", true)]
	[InlineData("p0", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string locationQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "M";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
