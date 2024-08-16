using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C229Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Y:H:e";

		var expected = new C229_ChargeCategory()
		{
			ChargeCategoryCoded = "Y",
			CodeListQualifier = "H",
			CodeListResponsibleAgencyCoded = "e",
		};

		var actual = Map.MapComposite<C229_ChargeCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredChargeCategoryCoded(string chargeCategoryCoded, bool isValidExpected)
	{
		var subject = new C229_ChargeCategory();
		//Required fields
		//Test Parameters
		subject.ChargeCategoryCoded = chargeCategoryCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
