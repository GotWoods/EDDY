using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class CICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CIC*R*2*R*l*9WXB";

		var expected = new CIC_CarInformationControl()
		{
			EquipmentInitial = "R",
			EquipmentNumber = "2",
			CarTypeCode = "R",
			EquipmentNumber2 = "l",
			MechanicalCarCode = "9WXB",
		};

		var actual = Map.MapObject<CIC_CarInformationControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "9WXB", false)]
	[InlineData("R", "", true)]
	[InlineData("", "9WXB", true)]
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
