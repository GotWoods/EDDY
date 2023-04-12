using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TXNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXN*0*0*zYh*E*G*LO*vm*XksQGJKm*HBic*";

		var expected = new TXN_TransactionCapabilities()
		{
			ActionCode = "0",
			ResponsibleAgencyCode = "0",
			TransactionSetIdentifierCode = "zYh",
			VersionReleaseIndustryIdentifierCode = "E",
			ActionCode2 = "G",
			ApplicationReceiversCode = "LO",
			ApplicationSendersCode = "vm",
			Date = "XksQGJKm",
			Time = "HBic",
			StandardsInformation = "",
		};

		var actual = Map.MapObject<TXN_TransactionCapabilities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		subject.ActionCode2 = "G";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "", false)]
	[InlineData("", "", true)]
	[InlineData("E", "", true)]
	public void Validation_OnlyOneOfVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, C053_StandardsInformation standardsInformation, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		subject.ActionCode = "0";
		subject.ActionCode2 = "G";
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		subject.StandardsInformation = standardsInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredActionCode2(string actionCode2, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		subject.ActionCode = "0";
		subject.ActionCode2 = actionCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
