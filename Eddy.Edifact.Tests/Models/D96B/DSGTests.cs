using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class DSGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DSG+D+";

		var expected = new DSG_DosageAdministration()
		{
			DosageAdministrationQualifier = "D",
			DosageDetails = null,
		};

		var actual = Map.MapObject<DSG_DosageAdministration>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDosageAdministrationQualifier(string dosageAdministrationQualifier, bool isValidExpected)
	{
		var subject = new DSG_DosageAdministration();
		//Required fields
		//Test Parameters
		subject.DosageAdministrationQualifier = dosageAdministrationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
