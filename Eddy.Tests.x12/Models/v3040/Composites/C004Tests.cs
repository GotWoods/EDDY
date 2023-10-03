using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3040;
using Eddy.x12.Models.v3040.Composites;

namespace Eddy.x12.Tests.Models.v3040.Composites;

public class C004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "1*6*9*5";

		var expected = new C004_CompositeDiagnosisCodePointer()
		{
			DiagnosisCodePointer = 1,
			DiagnosisCodePointer2 = 6,
			DiagnosisCodePointer3 = 9,
			DiagnosisCodePointer4 = 5,
		};

		var actual = Map.MapObject<C004_CompositeDiagnosisCodePointer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredDiagnosisCodePointer(int diagnosisCodePointer, bool isValidExpected)
	{
		var subject = new C004_CompositeDiagnosisCodePointer();
		//Required fields
		//Test Parameters
		if (diagnosisCodePointer > 0) 
			subject.DiagnosisCodePointer = diagnosisCodePointer;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
