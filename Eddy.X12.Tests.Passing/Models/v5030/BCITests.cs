using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BCI*n*o*V*QX*WS*p*Dk*rtz";

		var expected = new BCI_BasicClaimInformation()
		{
			IndustryCode = "n",
			InsuranceTypeCode = "o",
			ReferenceIdentification = "V",
			StateOrProvinceCode = "QX",
			DateTimePeriodFormatQualifier = "WS",
			DateTimePeriod = "p",
			ReportTypeCode = "Dk",
			CurrencyCode = "rtz",
		};

		var actual = Map.MapObject<BCI_BasicClaimInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WS", "p", true)]
	[InlineData("WS", "", false)]
	[InlineData("", "p", false)]
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
