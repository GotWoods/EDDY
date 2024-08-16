using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class DAVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DAV+s+";

		var expected = new DAV_DailyAvailability()
		{
			CharacteristicDescriptionCode = "s",
			DailyAvailabilityInformation = null,
		};

		var actual = Map.MapObject<DAV_DailyAvailability>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredCharacteristicDescriptionCode(string characteristicDescriptionCode, bool isValidExpected)
	{
		var subject = new DAV_DailyAvailability();
		//Required fields
		subject.DailyAvailabilityInformation = new E009_DailyAvailabilityInformation();
		//Test Parameters
		subject.CharacteristicDescriptionCode = characteristicDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDailyAvailabilityInformation(string dailyAvailabilityInformation, bool isValidExpected)
	{
		var subject = new DAV_DailyAvailability();
		//Required fields
		subject.CharacteristicDescriptionCode = "s";
		//Test Parameters
		if (dailyAvailabilityInformation != "") 
			subject.DailyAvailabilityInformation = new E009_DailyAvailabilityInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
