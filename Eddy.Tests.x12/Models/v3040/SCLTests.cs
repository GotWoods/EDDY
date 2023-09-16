using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCL*0*T*D*n*V*y*na*h*w*n";

		var expected = new SCL_RateBasisScales()
		{
			RateBasisQualifier = "0",
			RateBasisNumber = "T",
			RateBasisNumber2 = "D",
			LocationQualifier = "n",
			LocationIdentifier = "V",
			LocationIdentifier2 = "y",
			StateOrProvinceCode = "na",
			TariffAddOnFactor = "h",
			TariffClassAdjustmentReference = "w",
			TariffClassAdjustmentReference2 = "n",
		};

		var actual = Map.MapObject<SCL_RateBasisScales>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredRateBasisQualifier(string rateBasisQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = rateBasisQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "T", true)]
	[InlineData("D", "", false)]
	[InlineData("", "T", true)]
	public void Validation_ARequiresBRateBasisNumber2(string rateBasisNumber2, string rateBasisNumber, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "0";
		subject.RateBasisNumber2 = rateBasisNumber2;
		subject.RateBasisNumber = rateBasisNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "n", true)]
	[InlineData("V", "", false)]
	[InlineData("", "n", true)]
	public void Validation_ARequiresBLocationIdentifier(string locationIdentifier, string locationQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "0";
		subject.LocationIdentifier = locationIdentifier;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "V", true)]
	[InlineData("y", "", false)]
	[InlineData("", "V", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "0";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;
		if (locationIdentifier != "")
			subject.LocationQualifier = "n";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("na", "n", true)]
	[InlineData("na", "", false)]
	[InlineData("", "n", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string locationQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "0";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
