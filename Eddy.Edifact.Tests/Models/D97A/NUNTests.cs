using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class NUNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NUN+";

		var expected = new NUN_NumberOfUnits()
		{
			NumberOfUnitDetails = null,
		};

		var actual = Map.MapObject<NUN_NumberOfUnits>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredNumberOfUnitDetails(string numberOfUnitDetails, bool isValidExpected)
	{
		var subject = new NUN_NumberOfUnits();
		//Required fields
		//Test Parameters
		if (numberOfUnitDetails != "") 
			subject.NumberOfUnitDetails = new E523_NumberOfUnitDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
