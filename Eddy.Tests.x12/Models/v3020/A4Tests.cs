using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class A4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "A4*6paz*y*0*QR*L*9*jeRIzy*1";

		var expected = new A4_ApplicationAcceptance()
		{
			TransactionSetControlNumber = "6paz",
			EquipmentInitial = "y",
			EquipmentNumber = "0",
			ReferenceNumberQualifier = "QR",
			ReferenceNumber = "L",
			WaybillNumber = 9,
			Date = "jeRIzy",
			TotalEquipment = 1,
		};

		var actual = Map.MapObject<A4_ApplicationAcceptance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentNumber = "0";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("QR", "L", true)]
	[InlineData("", "L", false)]
	[InlineData("QR", "", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "0";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
