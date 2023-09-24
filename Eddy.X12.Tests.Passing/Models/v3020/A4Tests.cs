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
		string x12Line = "A4*5M5f*q*t*R2*k*3*Z8nWBf*7";

		var expected = new A4_ApplicationAcceptance()
		{
			TransactionSetControlNumber = "5M5f",
			EquipmentInitial = "q",
			EquipmentNumber = "t",
			ReferenceNumberQualifier = "R2",
			ReferenceNumber = "k",
			WaybillNumber = 3,
			Date = "Z8nWBf",
			TotalEquipment = 7,
		};

		var actual = Map.MapObject<A4_ApplicationAcceptance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentInitial = "q";
		subject.EquipmentNumber = "t";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentInitial = "q";
		subject.EquipmentNumber = "t";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R2", "k", true)]
	[InlineData("R2", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new A4_ApplicationAcceptance();
		subject.EquipmentInitial = "q";
		subject.EquipmentNumber = "t";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
