using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C246Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "h:p:A";

		var expected = new C246_CustomsIdentityCodes()
		{
			CustomsCodeIdentification = "h",
			CodeListIdentificationCode = "p",
			CodeListResponsibleAgencyCode = "A",
		};

		var actual = Map.MapComposite<C246_CustomsIdentityCodes>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredCustomsCodeIdentification(string customsCodeIdentification, bool isValidExpected)
	{
		var subject = new C246_CustomsIdentityCodes();
		//Required fields
		//Test Parameters
		subject.CustomsCodeIdentification = customsCodeIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
