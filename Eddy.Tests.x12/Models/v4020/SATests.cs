using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class SATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SA*bzs0XIHP*M*hX*m*KPWQXl8I";

		var expected = new SA_StatusAction()
		{
			Date = "bzs0XIHP",
			ActionCode = "M",
			StandardCarrierAlphaCode = "hX",
			Name = "m",
			Date2 = "KPWQXl8I",
		};

		var actual = Map.MapObject<SA_StatusAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bzs0XIHP", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.ActionCode = "M";
		subject.StandardCarrierAlphaCode = "hX";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "bzs0XIHP";
		subject.StandardCarrierAlphaCode = "hX";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hX", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "bzs0XIHP";
		subject.ActionCode = "M";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
