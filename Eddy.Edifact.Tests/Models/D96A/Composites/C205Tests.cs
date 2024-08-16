using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C205Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:B:5";

		var expected = new C205_HazardCode()
		{
			HazardCodeIdentification = "u",
			HazardSubstanceItemPageNumber = "B",
			HazardCodeVersionNumber = "5",
		};

		var actual = Map.MapComposite<C205_HazardCode>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredHazardCodeIdentification(string hazardCodeIdentification, bool isValidExpected)
	{
		var subject = new C205_HazardCode();
		//Required fields
		//Test Parameters
		subject.HazardCodeIdentification = hazardCodeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
