using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class NATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NA*Ni*m*b*V*7*t*jC*6394*hA*ub*C*1";

		var expected = new NA_CrossReferenceEquipment()
		{
			ReferenceIdentificationQualifier = "Ni",
			ReferenceIdentification = "m",
			EquipmentInitial = "b",
			EquipmentNumber = "V",
			CrossReferenceTypeCode = "7",
			Position = "t",
			StandardCarrierAlphaCode = "jC",
			EquipmentLength = 6394,
			StandardCarrierAlphaCode2 = "hA",
			ChassisType = "ub",
			YesNoConditionOrResponseCode = "C",
			EquipmentNumberCheckDigit = 1,
		};

		var actual = Map.MapObject<NA_CrossReferenceEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ni", "m", true)]
	[InlineData("Ni", "", false)]
	[InlineData("", "m", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "V";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentNumber = "V";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
