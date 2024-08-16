using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class GIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GIR+3+++++";

		var expected = new GIR_RelatedIdentificationNumbers()
		{
			SetTypeCodeQualifier = "3",
			IdentificationNumber = null,
			IdentificationNumber2 = null,
			IdentificationNumber3 = null,
			IdentificationNumber4 = null,
			IdentificationNumber5 = null,
		};

		var actual = Map.MapObject<GIR_RelatedIdentificationNumbers>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredSetTypeCodeQualifier(string setTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new GIR_RelatedIdentificationNumbers();
		//Required fields
		subject.IdentificationNumber = new C206_IdentificationNumber();
		//Test Parameters
		subject.SetTypeCodeQualifier = setTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredIdentificationNumber(string identificationNumber, bool isValidExpected)
	{
		var subject = new GIR_RelatedIdentificationNumbers();
		//Required fields
		subject.SetTypeCodeQualifier = "3";
		//Test Parameters
		if (identificationNumber != "") 
			subject.IdentificationNumber = new C206_IdentificationNumber();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
