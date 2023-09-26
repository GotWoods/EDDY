using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCI*3*2*h*kT*35*B*8B*FN4";

		var expected = new BCI_BasicClaimInformation()
		{
			IndustryCode = "3",
			InsuranceTypeCode = "2",
			ReferenceIdentification = "h",
			StateOrProvinceCode = "kT",
			DateTimePeriodFormatQualifier = "35",
			DateTimePeriod = "B",
			ReportTypeCode = "8B",
			CurrencyCode = "FN4",
		};

		var actual = Map.MapObject<BCI_BasicClaimInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("35", "B", true)]
	[InlineData("35", "", false)]
	[InlineData("", "B", false)]
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
