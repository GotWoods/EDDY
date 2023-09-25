using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TXNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXN*J*4*LHK*x*U*G7*wN*XtxJLH*Fsn0";

		var expected = new TXN_TransactionCapabilities()
		{
			ActionCode = "J",
			ResponsibleAgencyCode = "4",
			TransactionSetIdentifierCode = "LHK",
			VersionReleaseIndustryIdentifierCode = "x",
			ActionCode2 = "U",
			ApplicationReceiversCode = "G7",
			ApplicationSendersCode = "wN",
			Date = "XtxJLH",
			Time = "Fsn0",
		};

		var actual = Map.MapObject<TXN_TransactionCapabilities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ResponsibleAgencyCode = "4";
		subject.TransactionSetIdentifierCode = "LHK";
		subject.VersionReleaseIndustryIdentifierCode = "x";
		subject.ActionCode2 = "U";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredResponsibleAgencyCode(string responsibleAgencyCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "J";
		subject.TransactionSetIdentifierCode = "LHK";
		subject.VersionReleaseIndustryIdentifierCode = "x";
		subject.ActionCode2 = "U";
		//Test Parameters
		subject.ResponsibleAgencyCode = responsibleAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LHK", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "J";
		subject.ResponsibleAgencyCode = "4";
		subject.VersionReleaseIndustryIdentifierCode = "x";
		subject.ActionCode2 = "U";
		//Test Parameters
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "J";
		subject.ResponsibleAgencyCode = "4";
		subject.TransactionSetIdentifierCode = "LHK";
		subject.ActionCode2 = "U";
		//Test Parameters
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredActionCode2(string actionCode2, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "J";
		subject.ResponsibleAgencyCode = "4";
		subject.TransactionSetIdentifierCode = "LHK";
		subject.VersionReleaseIndustryIdentifierCode = "x";
		//Test Parameters
		subject.ActionCode2 = actionCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
