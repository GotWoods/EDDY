using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class A4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "A4*dWrx*P*O*Vo*O*3*2VSrIG*2";

		var expected = new A4_ApplicationAcceptance()
		{
			TransactionSetControlNumber = "dWrx",
			EquipmentInitial = "P",
			EquipmentNumber = "O",
			ReferenceIdentificationQualifier = "Vo",
			ReferenceIdentification = "O",
			WaybillNumber = 3,
			Date = "2VSrIG",
			TotalEquipment = 2,
		};

		var actual = Map.MapObject<A4_ApplicationAcceptance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentNumber = "O";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Vo", "O", true)]
	[InlineData("", "O", false)]
	[InlineData("Vo", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = "O";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
