using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class LEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEP*Xs3f*jIuZIWndP8ml*Ry*K";

		var expected = new LEP_EPARequiredData()
		{
			EPAWasteStreamNumberCode = "Xs3f",
			WasteCharacteristicsCode = "jIuZIWndP8ml",
			StateOrProvinceCode = "Ry",
			ReferenceIdentification = "K",
		};

		var actual = Map.MapObject<LEP_EPARequiredData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ry", "K", true)]
	[InlineData("Ry", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredStateOrProvinceCode(string stateOrProvinceCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new LEP_EPARequiredData();
		//Required fields
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
