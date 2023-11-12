using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class EITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EI*3*P*y*T*m*o";

		var expected = new EI_AutomaticEquipmentIdentification()
		{
			Count = 3,
			EquipmentInitial = "P",
			EquipmentNumber = "y",
			EquipmentOrientationCode = "T",
			Position = "m",
			TagStatusCode = "o",
		};

		var actual = Map.MapObject<EI_AutomaticEquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "y", true)]
	[InlineData("P", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new EI_AutomaticEquipmentIdentification();
		//Required fields
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
