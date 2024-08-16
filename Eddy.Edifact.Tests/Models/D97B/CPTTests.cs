using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class CPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CPT+6+";

		var expected = new CPT_AccountIdentification()
		{
			AccountTypeQualifier = "6",
			AccountIdentification = null,
		};

		var actual = Map.MapObject<CPT_AccountIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredAccountTypeQualifier(string accountTypeQualifier, bool isValidExpected)
	{
		var subject = new CPT_AccountIdentification();
		//Required fields
		subject.AccountIdentification = new C593_AccountIdentification();
		//Test Parameters
		subject.AccountTypeQualifier = accountTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAccountIdentification(string accountIdentification, bool isValidExpected)
	{
		var subject = new CPT_AccountIdentification();
		//Required fields
		subject.AccountTypeQualifier = "6";
		//Test Parameters
		if (accountIdentification != "") 
			subject.AccountIdentification = new C593_AccountIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
