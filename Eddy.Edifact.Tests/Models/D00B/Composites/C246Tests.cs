using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C246Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "E:S:j";

		var expected = new C246_CustomsIdentityCodes()
		{
			CustomsGoodsIdentifier = "E",
			CodeListIdentificationCode = "S",
			CodeListResponsibleAgencyCode = "j",
		};

		var actual = Map.MapComposite<C246_CustomsIdentityCodes>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredCustomsGoodsIdentifier(string customsGoodsIdentifier, bool isValidExpected)
	{
		var subject = new C246_CustomsIdentityCodes();
		//Required fields
		//Test Parameters
		subject.CustomsGoodsIdentifier = customsGoodsIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
