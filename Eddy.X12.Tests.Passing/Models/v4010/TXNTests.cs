using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TXNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXN*I*S*cI1*S*e*V2*yz*tKeBf5hg*BQIX";

		var expected = new TXN_TransactionCapabilities()
		{
			ActionCode = "I",
			ResponsibleAgencyCode = "S",
			TransactionSetIdentifierCode = "cI1",
			VersionReleaseIndustryIdentifierCode = "S",
			ActionCode2 = "e",
			ApplicationReceiversCode = "V2",
			ApplicationSendersCode = "yz",
			Date = "tKeBf5hg",
			Time = "BQIX",
		};

		var actual = Map.MapObject<TXN_TransactionCapabilities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ResponsibleAgencyCode = "S";
		subject.TransactionSetIdentifierCode = "cI1";
		subject.VersionReleaseIndustryIdentifierCode = "S";
		subject.ActionCode2 = "e";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredResponsibleAgencyCode(string responsibleAgencyCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "I";
		subject.TransactionSetIdentifierCode = "cI1";
		subject.VersionReleaseIndustryIdentifierCode = "S";
		subject.ActionCode2 = "e";
		//Test Parameters
		subject.ResponsibleAgencyCode = responsibleAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cI1", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "I";
		subject.ResponsibleAgencyCode = "S";
		subject.VersionReleaseIndustryIdentifierCode = "S";
		subject.ActionCode2 = "e";
		//Test Parameters
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "I";
		subject.ResponsibleAgencyCode = "S";
		subject.TransactionSetIdentifierCode = "cI1";
		subject.ActionCode2 = "e";
		//Test Parameters
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredActionCode2(string actionCode2, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "I";
		subject.ResponsibleAgencyCode = "S";
		subject.TransactionSetIdentifierCode = "cI1";
		subject.VersionReleaseIndustryIdentifierCode = "S";
		//Test Parameters
		subject.ActionCode2 = actionCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
