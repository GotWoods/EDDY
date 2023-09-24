using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PLCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLC*5*Y";

		var expected = new PLC_EquipmentPlacementInformation()
		{
			Number = 5,
			ReferenceIdentification = "Y",
		};

		var actual = Map.MapObject<PLC_EquipmentPlacementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new PLC_EquipmentPlacementInformation();
		if (number > 0)
		subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
