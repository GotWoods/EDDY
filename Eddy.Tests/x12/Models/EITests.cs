using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class EITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EI*2*M*N*p*5*F";

		var expected = new EI_AutomaticEquipmentIdentification()
		{
			Count = 2,
			EquipmentInitial = "M",
			EquipmentNumber = "N",
			EquipmentOrientationCode = "p",
			Position = "5",
			TagStatusCode = "F",
		};

		var actual = Map.MapObject<EI_AutomaticEquipmentIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("M", "N", true)]
	[InlineData("", "N", false)]
	[InlineData("M", "", false)]
	public void Validation_AllAreRequiredEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new EI_AutomaticEquipmentIdentification();
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
