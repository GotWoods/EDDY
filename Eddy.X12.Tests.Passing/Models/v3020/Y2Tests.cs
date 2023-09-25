using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class Y2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y2*4*z*qi*DJqd*H*e*Nq*mUn*E*2";

		var expected = new Y2_ContainerDetails()
		{
			NumberOfContainers = 4,
			ContainerTypeRequestCode = "z",
			TypeOfServiceCode = "qi",
			EquipmentType = "DJqd",
			TransportationMethodTypeCode = "H",
			IntermodalServiceCode = "e",
			StandardCarrierAlphaCode = "Nq",
			ContainerTermsCode = "mUn",
			ContainerTermsCodeQualifier = "E",
			TotalStopoffs = 2,
		};

		var actual = Map.MapObject<Y2_ContainerDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumberOfContainers(int numberOfContainers, bool isValidExpected)
	{
		var subject = new Y2_ContainerDetails();
		//Required fields
		subject.EquipmentType = "DJqd";
		//Test Parameters
		if (numberOfContainers > 0) 
			subject.NumberOfContainers = numberOfContainers;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DJqd", true)]
	public void Validation_RequiredEquipmentType(string equipmentType, bool isValidExpected)
	{
		var subject = new Y2_ContainerDetails();
		//Required fields
		subject.NumberOfContainers = 4;
		//Test Parameters
		subject.EquipmentType = equipmentType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
