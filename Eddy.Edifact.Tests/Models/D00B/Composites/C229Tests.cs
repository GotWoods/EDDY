using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C229Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:X:a";

		var expected = new C229_ChargeCategory()
		{
			ChargeCategoryCode = "t",
			CodeListIdentificationCode = "X",
			CodeListResponsibleAgencyCode = "a",
		};

		var actual = Map.MapComposite<C229_ChargeCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredChargeCategoryCode(string chargeCategoryCode, bool isValidExpected)
	{
		var subject = new C229_ChargeCategory();
		//Required fields
		//Test Parameters
		subject.ChargeCategoryCode = chargeCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
