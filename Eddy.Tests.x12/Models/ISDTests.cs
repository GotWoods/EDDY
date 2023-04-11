using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ISDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISD*rm*i2wZGt*hK5*K4I6";

		var expected = new ISD_RailroadInterlineServiceDefinitionDetail()
		{
			StandardCarrierAlphaCode = "rm",
			StandardPointLocationCode = "i2wZGt",
			EventCode = "hK5",
			Time = "K4I6",
		};

		var actual = Map.MapObject<ISD_RailroadInterlineServiceDefinitionDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rm", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ISD_RailroadInterlineServiceDefinitionDetail();
		subject.StandardPointLocationCode = "i2wZGt";
		subject.EventCode = "hK5";
		subject.Time = "K4I6";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i2wZGt", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ISD_RailroadInterlineServiceDefinitionDetail();
		subject.StandardCarrierAlphaCode = "rm";
		subject.EventCode = "hK5";
		subject.Time = "K4I6";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hK5", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ISD_RailroadInterlineServiceDefinitionDetail();
		subject.StandardCarrierAlphaCode = "rm";
		subject.StandardPointLocationCode = "i2wZGt";
		subject.Time = "K4I6";
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K4I6", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new ISD_RailroadInterlineServiceDefinitionDetail();
		subject.StandardCarrierAlphaCode = "rm";
		subject.StandardPointLocationCode = "i2wZGt";
		subject.EventCode = "hK5";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
