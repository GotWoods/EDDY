using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S502Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:p:4:h:D:a:X";

		var expected = new S502_SecurityAlgorithm()
		{
			UseOfAlgorithmCoded = "F",
			CryptographicModeOfOperationCoded = "p",
			ModeOfOperationCodeListIdentifier = "4",
			AlgorithmCoded = "h",
			AlgorithmCodeListIdentifier = "D",
			PaddingMechanismCoded = "a",
			PaddingMechanismCodeListIdentifier = "X",
		};

		var actual = Map.MapComposite<S502_SecurityAlgorithm>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredUseOfAlgorithmCoded(string useOfAlgorithmCoded, bool isValidExpected)
	{
		var subject = new S502_SecurityAlgorithm();
		//Required fields
		//Test Parameters
		subject.UseOfAlgorithmCoded = useOfAlgorithmCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
