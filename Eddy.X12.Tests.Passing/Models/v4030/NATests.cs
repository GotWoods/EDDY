using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class NATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NA*I9*b*G*1*S*t*Ae*7715*Hm*nX*o*5";

		var expected = new NA_CrossReferenceEquipment()
		{
			ReferenceIdentificationQualifier = "I9",
			ReferenceIdentification = "b",
			EquipmentInitial = "G",
			EquipmentNumber = "1",
			CrossReferenceTypeCode = "S",
			Position = "t",
			StandardCarrierAlphaCode = "Ae",
			EquipmentLength = 7715,
			StandardCarrierAlphaCode2 = "Hm",
			ChassisType = "nX",
			YesNoConditionOrResponseCode = "o",
			EquipmentNumberCheckDigit = 5,
		};

		var actual = Map.MapObject<NA_CrossReferenceEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I9", "b", true)]
	[InlineData("I9", "", false)]
	[InlineData("", "b", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = "1";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentNumber = "1";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentInitial = "G";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
