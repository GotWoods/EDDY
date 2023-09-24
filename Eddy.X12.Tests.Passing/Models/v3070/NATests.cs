using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class NATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NA*dj*2*m*K*A*X*wM*5826*Ya*bu*T";

		var expected = new NA_CrossReferenceEquipment()
		{
			ReferenceIdentificationQualifier = "dj",
			ReferenceIdentification = "2",
			EquipmentInitial = "m",
			EquipmentNumber = "K",
			CrossReferenceTypeCode = "A",
			Position = "X",
			StandardCarrierAlphaCode = "wM",
			EquipmentLength = 5826,
			StandardCarrierAlphaCode2 = "Ya",
			ChassisType = "bu",
			YesNoConditionOrResponseCode = "T",
		};

		var actual = Map.MapObject<NA_CrossReferenceEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dj", "2", true)]
	[InlineData("dj", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "K";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentNumber = "K";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
