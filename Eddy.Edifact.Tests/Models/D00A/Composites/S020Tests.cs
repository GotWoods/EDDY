using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S020Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:Y";

		var expected = new S020_ReferenceIdentification()
		{
			ReferenceQualifier = "M",
			ReferenceIdentificationNumber = "Y",
		};

		var actual = Map.MapComposite<S020_ReferenceIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceQualifier(string referenceQualifier, bool isValidExpected)
	{
		var subject = new S020_ReferenceIdentification();
		//Required fields
		subject.ReferenceIdentificationNumber = "Y";
		//Test Parameters
		subject.ReferenceQualifier = referenceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceIdentificationNumber(string referenceIdentificationNumber, bool isValidExpected)
	{
		var subject = new S020_ReferenceIdentification();
		//Required fields
		subject.ReferenceQualifier = "M";
		//Test Parameters
		subject.ReferenceIdentificationNumber = referenceIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
