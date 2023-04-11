using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NA*vE*6*s*H*A*t*UY*8656*s0*mC*u*9";

		var expected = new NA_CrossReferenceEquipment()
		{
			ReferenceIdentificationQualifier = "vE",
			ReferenceIdentification = "6",
			EquipmentInitial = "s",
			EquipmentNumber = "H",
			CrossReferenceTypeCode = "A",
			Position = "t",
			StandardCarrierAlphaCode = "UY",
			EquipmentLength = 8656,
			StandardCarrierAlphaCode2 = "s0",
			ChassisTypeCode = "mC",
			YesNoConditionOrResponseCode = "u",
			EquipmentNumberCheckDigit = 9,
		};

		var actual = Map.MapObject<NA_CrossReferenceEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "6", true)]
	[InlineData("vE", "", false)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = "H";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentNumber = "H";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentInitial = "s";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
