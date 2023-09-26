using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ISDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISD*Ls*CWuFCw*zCF*oIBe";

		var expected = new ISD_RailroadInterlineServiceDefinitionDetail()
		{
			StandardCarrierAlphaCode = "Ls",
			StandardPointLocationCode = "CWuFCw",
			EventCode = "zCF",
			Time = "oIBe",
		};

		var actual = Map.MapObject<ISD_RailroadInterlineServiceDefinitionDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ls", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ISD_RailroadInterlineServiceDefinitionDetail();
		//Required fields
		subject.StandardPointLocationCode = "CWuFCw";
		subject.EventCode = "zCF";
		subject.Time = "oIBe";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CWuFCw", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ISD_RailroadInterlineServiceDefinitionDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "Ls";
		subject.EventCode = "zCF";
		subject.Time = "oIBe";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zCF", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ISD_RailroadInterlineServiceDefinitionDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "Ls";
		subject.StandardPointLocationCode = "CWuFCw";
		subject.Time = "oIBe";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oIBe", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new ISD_RailroadInterlineServiceDefinitionDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "Ls";
		subject.StandardPointLocationCode = "CWuFCw";
		subject.EventCode = "zCF";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
