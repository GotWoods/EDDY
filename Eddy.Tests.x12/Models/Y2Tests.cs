using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Y2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y2*4*X*Qq*H7kL*i*9*oW*slo*z*1";

		var expected = new Y2_ContainerDetails()
		{
			NumberOfContainers = 4,
			ContainerTypeRequestCode = "X",
			TypeOfServiceCode = "Qq",
			EquipmentTypeCode = "H7kL",
			TransportationMethodTypeCode = "i",
			IntermodalServiceCode = "9",
			StandardCarrierAlphaCode = "oW",
			ContainerTermsCode = "slo",
			ContainerTermsCodeQualifier = "z",
			TotalStopOffs = 1,
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
		subject.EquipmentTypeCode = "H7kL";
		if (numberOfContainers > 0)
		subject.NumberOfContainers = numberOfContainers;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H7kL", true)]
	public void Validation_RequiredEquipmentTypeCode(string equipmentTypeCode, bool isValidExpected)
	{
		var subject = new Y2_ContainerDetails();
		subject.NumberOfContainers = 4;
		subject.EquipmentTypeCode = equipmentTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
