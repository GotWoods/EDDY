using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CIC*6*Q*k*h";

		var expected = new CIC_CarInformationControl()
		{
			EquipmentInitial = "6",
			EquipmentNumber = "Q",
			CarTypeCode = "k",
			EquipmentNumber2 = "h",
			//MechanicalCarCode = "nneY",
		};

		var actual = Map.MapObject<CIC_CarInformationControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "nneY", false)]
	[InlineData("", "nneY", true)]
	[InlineData("k", "", true)]
	public void Validation_OnlyOneOfCarTypeCode(string carTypeCode, string mechanicalCarCode, bool isValidExpected)
	{
		var subject = new CIC_CarInformationControl();
		subject.CarTypeCode = carTypeCode;
		subject.MechanicalCarCode = mechanicalCarCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
