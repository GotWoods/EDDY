using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class LEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEP*jCU8*o5Gf5M3h0Jup*3A*L";

		var expected = new LEP_EPARequiredData()
		{
			EPAWasteStreamNumberCode = "jCU8",
			WasteCharacteristicsCode = "o5Gf5M3h0Jup",
			StateOrProvinceCode = "3A",
			ReferenceIdentification = "L",
		};

		var actual = Map.MapObject<LEP_EPARequiredData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3A", "L", true)]
	[InlineData("3A", "", false)]
	[InlineData("", "L", false)]
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
