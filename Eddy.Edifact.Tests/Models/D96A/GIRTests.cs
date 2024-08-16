using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class GIRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GIR+k+++++";

		var expected = new GIR_RelatedIdentificationNumbers()
		{
			SetIdentificationQualifier = "k",
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
	[InlineData("k", true)]
	public void Validation_RequiredSetIdentificationQualifier(string setIdentificationQualifier, bool isValidExpected)
	{
		var subject = new GIR_RelatedIdentificationNumbers();
		//Required fields
		subject.IdentificationNumber = new C206_IdentificationNumber();
		//Test Parameters
		subject.SetIdentificationQualifier = setIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredIdentificationNumber(string identificationNumber, bool isValidExpected)
	{
		var subject = new GIR_RelatedIdentificationNumbers();
		//Required fields
		subject.SetIdentificationQualifier = "k";
		//Test Parameters
		if (identificationNumber != "") 
			subject.IdentificationNumber = new C206_IdentificationNumber();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
