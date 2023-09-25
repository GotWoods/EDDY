using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class Y2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y2*8*r*yQ*luxR*6*o*pt*7wj*m*2";

		var expected = new Y2_ContainerDetails()
		{
			NumberOfContainers = 8,
			ContainerTypeRequestCode = "r",
			TypeOfServiceCode = "yQ",
			EquipmentType = "luxR",
			TransportationMethodTypeCode = "6",
			IntermodalServiceCode = "o",
			StandardCarrierAlphaCode = "pt",
			ContainerTermsCode = "7wj",
			ContainerTermsCodeQualifier = "m",
			TotalStopOffs = 2,
		};

		var actual = Map.MapObject<Y2_ContainerDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfContainers(int numberOfContainers, bool isValidExpected)
	{
		var subject = new Y2_ContainerDetails();
		//Required fields
		subject.EquipmentType = "luxR";
		//Test Parameters
		if (numberOfContainers > 0) 
			subject.NumberOfContainers = numberOfContainers;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("luxR", true)]
	public void Validation_RequiredEquipmentType(string equipmentType, bool isValidExpected)
	{
		var subject = new Y2_ContainerDetails();
		//Required fields
		subject.NumberOfContainers = 8;
		//Test Parameters
		subject.EquipmentType = equipmentType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
