using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SMCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMC*A*s*e*E*W*9Yrn8o";

		var expected = new SMC_CustomerInformation()
		{
			ReciprocalSwitchCode = "A",
			MarksAndNumbersQualifier = "s",
			AddressInformation = "e",
			SwitchingZoneIdentifier = "E",
			ServiceRestrictionInformation = "W",
			Date = "9Yrn8o",
		};

		var actual = Map.MapObject<SMC_CustomerInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReciprocalSwitchCode(string reciprocalSwitchCode, bool isValidExpected)
	{
		var subject = new SMC_CustomerInformation();
		//Required fields
		subject.MarksAndNumbersQualifier = "s";
		//Test Parameters
		subject.ReciprocalSwitchCode = reciprocalSwitchCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredMarksAndNumbersQualifier(string marksAndNumbersQualifier, bool isValidExpected)
	{
		var subject = new SMC_CustomerInformation();
		//Required fields
		subject.ReciprocalSwitchCode = "A";
		//Test Parameters
		subject.MarksAndNumbersQualifier = marksAndNumbersQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
