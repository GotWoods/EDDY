using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCI*W*w*3*8F*8f*v*Fj*a6y";

		var expected = new BCI_BasicClaimInformation()
		{
			IndustryCode = "W",
			InsuranceTypeCode = "w",
			ReferenceNumber = "3",
			StateOrProvinceCode = "8F",
			DateTimePeriodFormatQualifier = "8f",
			DateTimePeriod = "v",
			ReportTypeCode = "Fj",
			CurrencyCode = "a6y",
		};

		var actual = Map.MapObject<BCI_BasicClaimInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8f", "v", true)]
	[InlineData("8f", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new BCI_BasicClaimInformation();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
