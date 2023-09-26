using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PLCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLC*1*8";

		var expected = new PLC_EquipmentPlacementInformation()
		{
			Number = 1,
			ReferenceIdentification = "8",
		};

		var actual = Map.MapObject<PLC_EquipmentPlacementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new PLC_EquipmentPlacementInformation();
		//Required fields
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
