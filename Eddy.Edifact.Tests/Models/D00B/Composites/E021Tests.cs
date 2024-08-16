using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E021Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Z:B:1:5:Z:n";

		var expected = new E021_Service()
		{
			ProductIdentifier = "Z",
			CodeListIdentificationCode = "B",
			ProcedureModificationCode = "1",
			ProcedureModificationCode2 = "5",
			ProcedureModificationCode3 = "Z",
			ProcedureModificationCode4 = "n",
		};

		var actual = Map.MapComposite<E021_Service>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredProductIdentifier(string productIdentifier, bool isValidExpected)
	{
		var subject = new E021_Service();
		//Required fields
		//Test Parameters
		subject.ProductIdentifier = productIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
