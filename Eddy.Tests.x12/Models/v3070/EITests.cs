using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class EITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EI*8*x*N*M*5*6";

		var expected = new EI_AutomaticEquipmentIdentification()
		{
			Count = 8,
			EquipmentInitial = "x",
			EquipmentNumber = "N",
			EquipmentOrientationCode = "M",
			Position = "5",
			TagStatusCode = "6",
		};

		var actual = Map.MapObject<EI_AutomaticEquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "N", true)]
	[InlineData("x", "", false)]
	[InlineData("", "N", false)]
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
