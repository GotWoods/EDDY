using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E971Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "1:Q:w:d:K";

		var expected = new E971_FreeTextQualification()
		{
			TextSubjectQualifier = "1",
			InformationTypeIdentification = "Q",
			StatusCoded = "w",
			PartyName = "d",
			LanguageCoded = "K",
		};

		var actual = Map.MapComposite<E971_FreeTextQualification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredTextSubjectQualifier(string textSubjectQualifier, bool isValidExpected)
	{
		var subject = new E971_FreeTextQualification();
		//Required fields
		//Test Parameters
		subject.TextSubjectQualifier = textSubjectQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
