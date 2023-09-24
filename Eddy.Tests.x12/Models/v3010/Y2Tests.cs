using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Y2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y2*2*X*3p*eA6O*a*M*Wk*1Uo*y*2";

		var expected = new Y2_ContainerDetails()
		{
			NumberOfContainers = 2,
			ContainerTypeRequestCode = "X",
			TypeOfServiceCode = "3p",
			EquipmentType = "eA6O",
			TransportationMethodTypeCode = "a",
			TOFCIntermodalCodeQualifier = "M",
			StandardCarrierAlphaCode = "Wk",
			ContainerTermsCode = "1Uo",
			ContainerTermsCodeQualifier = "y",
			TotalStopoffs = 2,
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
		subject.EquipmentType = "eA6O";
		//Test Parameters
		if (numberOfContainers > 0) 
			subject.NumberOfContainers = numberOfContainers;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eA6O", true)]
	public void Validation_RequiredEquipmentType(string equipmentType, bool isValidExpected)
	{
		var subject = new Y2_ContainerDetails();
		//Required fields
		subject.NumberOfContainers = 2;
		//Test Parameters
		subject.EquipmentType = equipmentType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
