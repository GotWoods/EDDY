using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C816Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "z:B:6:h";

		var expected = new C816_NameComponentDetails()
		{
			NameComponentTypeCodeQualifier = "z",
			NameComponentDescription = "B",
			NameComponentUsageCode = "6",
			NameOriginalAlphabetCode = "h",
		};

		var actual = Map.MapComposite<C816_NameComponentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredNameComponentTypeCodeQualifier(string nameComponentTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C816_NameComponentDetails();
		//Required fields
		//Test Parameters
		subject.NameComponentTypeCodeQualifier = nameComponentTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
