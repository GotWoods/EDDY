using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class LEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEP*KFcW*vwjPYIuto66b*z0*k";

		var expected = new LEP_EPARequiredData()
		{
			EPAWasteStreamNumberCode = "KFcW",
			WasteCharacteristicsCode = "vwjPYIuto66b",
			StateOrProvinceCode = "z0",
			ReferenceIdentification = "k",
		};

		var actual = Map.MapObject<LEP_EPARequiredData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z0", "k", true)]
	[InlineData("z0", "", false)]
	[InlineData("", "k", false)]
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
