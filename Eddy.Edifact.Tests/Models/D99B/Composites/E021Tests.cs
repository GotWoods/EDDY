using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E021Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:y:s:S:l:g";

		var expected = new E021_Service()
		{
			ProductIdentifier = "e",
			CodeListIdentificationCode = "y",
			ProcedureModificationCode = "s",
			ProcedureModificationCode2 = "S",
			ProcedureModificationCode3 = "l",
			ProcedureModificationCode4 = "g",
		};

		var actual = Map.MapComposite<E021_Service>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredProductIdentifier(string productIdentifier, bool isValidExpected)
	{
		var subject = new E021_Service();
		//Required fields
		//Test Parameters
		subject.ProductIdentifier = productIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
