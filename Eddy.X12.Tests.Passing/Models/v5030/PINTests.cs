using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PIN*2*X*Q*z*Xg*Q*n";

		var expected = new PIN_PreviousIncident()
		{
			AssignedNumber = 2,
			YesNoConditionOrResponseCode = "X",
			ReferenceIdentification = "Q",
			Name = "z",
			DateTimePeriodFormatQualifier = "Xg",
			DateTimePeriod = "Q",
			IndustryCode = "n",
		};

		var actual = Map.MapObject<PIN_PreviousIncident>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new PIN_PreviousIncident();
		//Required fields
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Xg";
			subject.DateTimePeriod = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xg", "Q", true)]
	[InlineData("Xg", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PIN_PreviousIncident();
		//Required fields
		subject.AssignedNumber = 2;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
