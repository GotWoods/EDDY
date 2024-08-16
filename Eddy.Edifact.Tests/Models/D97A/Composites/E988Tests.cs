using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E988Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "o:a:J";

		var expected = new E988_CompanyIdentification()
		{
			PartyName = "o",
			PartyName2 = "a",
			PartyName3 = "J",
		};

		var actual = Map.MapComposite<E988_CompanyIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E988_CompanyIdentification();
		//Required fields
		subject.PartyName2 = "a";
		subject.PartyName3 = "J";
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredPartyName2(string partyName2, bool isValidExpected)
	{
		var subject = new E988_CompanyIdentification();
		//Required fields
		subject.PartyName = "o";
		subject.PartyName3 = "J";
		//Test Parameters
		subject.PartyName2 = partyName2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredPartyName3(string partyName3, bool isValidExpected)
	{
		var subject = new E988_CompanyIdentification();
		//Required fields
		subject.PartyName = "o";
		subject.PartyName2 = "a";
		//Test Parameters
		subject.PartyName3 = partyName3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
