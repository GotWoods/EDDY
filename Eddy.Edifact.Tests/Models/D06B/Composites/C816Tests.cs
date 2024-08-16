using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06B;
using Eddy.Edifact.Models.D06B.Composites;

namespace Eddy.Edifact.Tests.Models.D06B.Composites;

public class C816Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "V:y:Y:3";

		var expected = new C816_NameComponentDetails()
		{
			NameComponentTypeCodeQualifier = "V",
			NameComponentDescription = "y",
			NameComponentUsageCode = "Y",
			NameOriginalAlphabetCode = "3",
		};

		var actual = Map.MapComposite<C816_NameComponentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredNameComponentTypeCodeQualifier(string nameComponentTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C816_NameComponentDetails();
		//Required fields
		//Test Parameters
		subject.NameComponentTypeCodeQualifier = nameComponentTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
