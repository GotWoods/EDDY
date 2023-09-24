using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SCLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCL*V*S*x*6*V*T*6G*W*s*x";

		var expected = new SCL_RateBasisScales()
		{
			RateBasisQualifier = "V",
			RateBasisNumber = "S",
			RateBasisNumber2 = "x",
			LocationQualifier = "6",
			LocationIdentifier = "V",
			LocationIdentifier2 = "T",
			StateOrProvinceCode = "6G",
			TariffAddOnFactor = "W",
			TariffClassAdjustmentReference = "s",
			TariffClassAdjustmentReference2 = "x",
		};

		var actual = Map.MapObject<SCL_RateBasisScales>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredRateBasisQualifier(string rateBasisQualifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = rateBasisQualifier;
			subject.LocationQualifier = "6";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "S", true)]
	[InlineData("x", "", false)]
	[InlineData("", "S", true)]
	public void Validation_ARequiresBRateBasisNumber2(string rateBasisNumber2, string rateBasisNumber, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "V";
		subject.RateBasisNumber2 = rateBasisNumber2;
		subject.RateBasisNumber = rateBasisNumber;
			subject.LocationQualifier = "6";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("6", "V", true)]
	[InlineData("6", "", true)]
	[InlineData("", "V", true)]
	public void Validation_AtLeastOneLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "V";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "V", true)]
	[InlineData("T", "", false)]
	[InlineData("", "V", true)]
	public void Validation_ARequiresBLocationIdentifier2(string locationIdentifier2, string locationIdentifier, bool isValidExpected)
	{
		var subject = new SCL_RateBasisScales();
		subject.RateBasisQualifier = "V";
		subject.LocationIdentifier2 = locationIdentifier2;
		subject.LocationIdentifier = locationIdentifier;
			subject.LocationQualifier = "6";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
