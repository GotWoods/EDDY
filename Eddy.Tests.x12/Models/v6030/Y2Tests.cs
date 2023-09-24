using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class Y2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y2*2*z*nR*z64H*T*Y*Rn*7FS*8*7";

		var expected = new Y2_ContainerDetails()
		{
			NumberOfContainers = 2,
			ContainerTypeRequestCode = "z",
			TypeOfServiceCode = "nR",
			EquipmentTypeCode = "z64H",
			TransportationMethodTypeCode = "T",
			IntermodalServiceCode = "Y",
			StandardCarrierAlphaCode = "Rn",
			ContainerTermsCode = "7FS",
			ContainerTermsCodeQualifier = "8",
			TotalStopOffs = 7,
		};

		var actual = Map.MapObject<Y2_ContainerDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumberOfContainers(int numberOfContainers, bool isValidExpected)
	{
		var subject = new Y2_ContainerDetails();
		//Required fields
		subject.EquipmentTypeCode = "z64H";
		//Test Parameters
		if (numberOfContainers > 0) 
			subject.NumberOfContainers = numberOfContainers;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z64H", true)]
	public void Validation_RequiredEquipmentTypeCode(string equipmentTypeCode, bool isValidExpected)
	{
		var subject = new Y2_ContainerDetails();
		//Required fields
		subject.NumberOfContainers = 2;
		//Test Parameters
		subject.EquipmentTypeCode = equipmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
