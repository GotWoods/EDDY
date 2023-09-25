using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2A*E*x*i*2*5*p*nL*4434*4*8*m*r*1";

		var expected = new W2A_EquipmentInformation()
		{
			EquipmentStatusCode = "E",
			EquipmentInitial = "x",
			EquipmentNumber = "i",
			EquipmentNumberCheckDigit = 2,
			Weight = 5,
			WeightQualifier = "p",
			EquipmentDescriptionCode = "nL",
			EquipmentLength = 4434,
			Height = 4,
			Width = 8,
			EquipmentInitial2 = "m",
			EquipmentNumber2 = "r",
			EquipmentNumberCheckDigit2 = 1,
		};

		var actual = Map.MapObject<W2A_EquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentInitial = "x";
		subject.EquipmentNumber = "i";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "E";
		subject.EquipmentNumber = "i";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "E";
		subject.EquipmentInitial = "x";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
