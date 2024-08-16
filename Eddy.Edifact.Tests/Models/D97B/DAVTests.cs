using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class DAVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DAV+I+";

		var expected = new DAV_DailyAvailability()
		{
			CharacteristicIdentification = "I",
			DailyAvailabilityInformation = null,
		};

		var actual = Map.MapObject<DAV_DailyAvailability>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredCharacteristicIdentification(string characteristicIdentification, bool isValidExpected)
	{
		var subject = new DAV_DailyAvailability();
		//Required fields
		subject.DailyAvailabilityInformation = new E009_DailyAvailabilityInformation();
		//Test Parameters
		subject.CharacteristicIdentification = characteristicIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDailyAvailabilityInformation(string dailyAvailabilityInformation, bool isValidExpected)
	{
		var subject = new DAV_DailyAvailability();
		//Required fields
		subject.CharacteristicIdentification = "I";
		//Test Parameters
		if (dailyAvailabilityInformation != "") 
			subject.DailyAvailabilityInformation = new E009_DailyAvailabilityInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
