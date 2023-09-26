using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class TXNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXN*a*f*Go0*5*E*jv*Rh*Zom5dZpT*dxY1*";

		var expected = new TXN_TransactionCapabilities()
		{
			ActionCode = "a",
			ResponsibleAgencyCode = "f",
			TransactionSetIdentifierCode = "Go0",
			VersionReleaseIndustryIdentifierCode = "5",
			ActionCode2 = "E",
			ApplicationReceiversCode = "jv",
			ApplicationSendersCode = "Rh",
			Date = "Zom5dZpT",
			Time = "dxY1",
			StandardsInformation = null,
		};

		var actual = Map.MapObject<TXN_TransactionCapabilities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode2 = "E";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "A", false)]
	[InlineData("5", "", true)]
	[InlineData("", "", true)]
	public void Validation_OnlyOneOfVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, string standardsInformation, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "a";
		subject.ActionCode2 = "E";
		//Test Parameters
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		if (standardsInformation != "") 
			subject.StandardsInformation = new C053_StandardsInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredActionCode2(string actionCode2, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "a";
		//Test Parameters
		subject.ActionCode2 = actionCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
