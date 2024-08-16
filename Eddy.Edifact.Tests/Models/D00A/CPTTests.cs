using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CPT+0+";

		var expected = new CPT_AccountIdentification()
		{
			AccountTypeCodeQualifier = "0",
			AccountIdentification = null,
		};

		var actual = Map.MapObject<CPT_AccountIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredAccountTypeCodeQualifier(string accountTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new CPT_AccountIdentification();
		//Required fields
		subject.AccountIdentification = new C593_AccountIdentification();
		//Test Parameters
		subject.AccountTypeCodeQualifier = accountTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAccountIdentification(string accountIdentification, bool isValidExpected)
	{
		var subject = new CPT_AccountIdentification();
		//Required fields
		subject.AccountTypeCodeQualifier = "0";
		//Test Parameters
		if (accountIdentification != "") 
			subject.AccountIdentification = new C593_AccountIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
