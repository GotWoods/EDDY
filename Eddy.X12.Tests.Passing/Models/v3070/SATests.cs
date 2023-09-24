using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SA*IJ2O4o*2*Sr*m4*9kmsdL";

		var expected = new SA_StatusAction()
		{
			Date = "IJ2O4o",
			ActionCode = "2",
			StandardCarrierAlphaCode = "Sr",
			Name30CharacterFormat = "m4",
			Date2 = "9kmsdL",
		};

		var actual = Map.MapObject<SA_StatusAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IJ2O4o", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.ActionCode = "2";
		subject.StandardCarrierAlphaCode = "Sr";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "IJ2O4o";
		subject.StandardCarrierAlphaCode = "Sr";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sr", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "IJ2O4o";
		subject.ActionCode = "2";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
