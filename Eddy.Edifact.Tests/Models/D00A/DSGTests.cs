using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DSGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DSG+m+";

		var expected = new DSG_DosageAdministration()
		{
			DosageAdministrationCodeQualifier = "m",
			DosageDetails = null,
		};

		var actual = Map.MapObject<DSG_DosageAdministration>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredDosageAdministrationCodeQualifier(string dosageAdministrationCodeQualifier, bool isValidExpected)
	{
		var subject = new DSG_DosageAdministration();
		//Required fields
		//Test Parameters
		subject.DosageAdministrationCodeQualifier = dosageAdministrationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
