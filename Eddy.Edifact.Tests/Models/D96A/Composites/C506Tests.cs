using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C506Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:8:p:y";

		var expected = new C506_Reference()
		{
			ReferenceQualifier = "7",
			ReferenceNumber = "8",
			LineNumber = "p",
			ReferenceVersionNumber = "y",
		};

		var actual = Map.MapComposite<C506_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReferenceQualifier(string referenceQualifier, bool isValidExpected)
	{
		var subject = new C506_Reference();
		//Required fields
		//Test Parameters
		subject.ReferenceQualifier = referenceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
