using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C246Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Z:c:C";

		var expected = new C246_CustomsIdentityCodes()
		{
			CustomsCodeIdentification = "Z",
			CodeListQualifier = "c",
			CodeListResponsibleAgencyCoded = "C",
		};

		var actual = Map.MapComposite<C246_CustomsIdentityCodes>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredCustomsCodeIdentification(string customsCodeIdentification, bool isValidExpected)
	{
		var subject = new C246_CustomsIdentityCodes();
		//Required fields
		//Test Parameters
		subject.CustomsCodeIdentification = customsCodeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
