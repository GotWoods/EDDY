using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PIN*6*3*u*e*E3*2*V";

		var expected = new PIN_PreviousIncident()
		{
			AssignedNumber = 6,
			YesNoConditionOrResponseCode = "3",
			ReferenceIdentification = "u",
			Name = "e",
			DateTimePeriodFormatQualifier = "E3",
			DateTimePeriod = "2",
			IndustryCode = "V",
		};

		var actual = Map.MapObject<PIN_PreviousIncident>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new PIN_PreviousIncident();
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("E3", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("E3", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PIN_PreviousIncident();
		subject.AssignedNumber = 6;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
