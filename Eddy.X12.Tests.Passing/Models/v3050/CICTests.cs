using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CIC*W*L*t*1*i7lw";

		var expected = new CIC_CarInformationControl()
		{
			EquipmentInitial = "W",
			EquipmentNumber = "L",
			CarTypeCode = "t",
			EquipmentNumber2 = "1",
			MechanicalCarCode = "i7lw",
		};

		var actual = Map.MapObject<CIC_CarInformationControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "i7lw", false)]
	[InlineData("t", "", true)]
	[InlineData("", "i7lw", true)]
	public void Validation_OnlyOneOfCarTypeCode(string carTypeCode, string mechanicalCarCode, bool isValidExpected)
	{
		var subject = new CIC_CarInformationControl();
		//Required fields
		//Test Parameters
		subject.CarTypeCode = carTypeCode;
		subject.MechanicalCarCode = mechanicalCarCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
