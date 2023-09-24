using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class NATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NA*7P*1*N*j*C*6*5*4933";

		var expected = new NA_CrossReferenceEquipment()
		{
			ReferenceNumberQualifier = "7P",
			ReferenceNumber = "1",
			EquipmentInitial = "N",
			EquipmentNumber = "j",
			CrossReferenceTypeCode = "C",
			Position = "6",
			EquipmentOwnerCode = "5",
			EquipmentLength = 4933,
		};

		var actual = Map.MapObject<NA_CrossReferenceEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentNumber = "j";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new NA_CrossReferenceEquipment();
		subject.EquipmentInitial = "N";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
