using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E816Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "2:4:7:Y";

		var expected = new E816_NameComponentDetails()
		{
			NameComponentTypeCodeQualifier = "2",
			NameComponentDescription = "4",
			NameComponentUsageCode = "7",
			NameOriginalAlphabetCode = "Y",
		};

		var actual = Map.MapComposite<E816_NameComponentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredNameComponentTypeCodeQualifier(string nameComponentTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new E816_NameComponentDetails();
		//Required fields
		//Test Parameters
		subject.NameComponentTypeCodeQualifier = nameComponentTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
