using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TXNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXN*A*R*d1M*U*M*qF*C6*7pv88s*U5ch";

		var expected = new TXN_TransactionCapabilities()
		{
			ActionCode = "A",
			ResponsibleAgencyCode = "R",
			TransactionSetIdentifierCode = "d1M",
			VersionReleaseIndustryIdentifierCode = "U",
			ActionCode2 = "M",
			ApplicationReceiversCode = "qF",
			ApplicationSendersCode = "C6",
			Date = "7pv88s",
			Time = "U5ch",
		};

		var actual = Map.MapObject<TXN_TransactionCapabilities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ResponsibleAgencyCode = "R";
		subject.TransactionSetIdentifierCode = "d1M";
		subject.VersionReleaseIndustryIdentifierCode = "U";
		subject.ActionCode2 = "M";
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredResponsibleAgencyCode(string responsibleAgencyCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "A";
		subject.TransactionSetIdentifierCode = "d1M";
		subject.VersionReleaseIndustryIdentifierCode = "U";
		subject.ActionCode2 = "M";
		//Test Parameters
		subject.ResponsibleAgencyCode = responsibleAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d1M", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "A";
		subject.ResponsibleAgencyCode = "R";
		subject.VersionReleaseIndustryIdentifierCode = "U";
		subject.ActionCode2 = "M";
		//Test Parameters
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredVersionReleaseIndustryIdentifierCode(string versionReleaseIndustryIdentifierCode, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "A";
		subject.ResponsibleAgencyCode = "R";
		subject.TransactionSetIdentifierCode = "d1M";
		subject.ActionCode2 = "M";
		//Test Parameters
		subject.VersionReleaseIndustryIdentifierCode = versionReleaseIndustryIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredActionCode2(string actionCode2, bool isValidExpected)
	{
		var subject = new TXN_TransactionCapabilities();
		//Required fields
		subject.ActionCode = "A";
		subject.ResponsibleAgencyCode = "R";
		subject.TransactionSetIdentifierCode = "d1M";
		subject.VersionReleaseIndustryIdentifierCode = "U";
		//Test Parameters
		subject.ActionCode2 = actionCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
