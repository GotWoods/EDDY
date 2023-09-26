using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class INTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INT*N*3*kT*n*6";

		var expected = new INT_Interest()
		{
			InterestTypeCode = "N",
			InterestRate = 3,
			DateTimePeriodFormatQualifier = "kT",
			DateTimePeriod = "n",
			Quantity = 6,
		};

		var actual = Map.MapObject<INT_Interest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredInterestTypeCode(string interestTypeCode, bool isValidExpected)
	{
		var subject = new INT_Interest();
		//Required fields
		//Test Parameters
		subject.InterestTypeCode = interestTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "kT";
			subject.DateTimePeriod = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kT", "n", true)]
	[InlineData("kT", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new INT_Interest();
		//Required fields
		subject.InterestTypeCode = "N";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
