using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G85Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G85*v";

		var expected = new G85_RecordIntegrityCheck()
		{
			IntegrityCheckValue = "v",
		};

		var actual = Map.MapObject<G85_RecordIntegrityCheck>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredIntegrityCheckValue(string integrityCheckValue, bool isValidExpected)
	{
		var subject = new G85_RecordIntegrityCheck();
		subject.IntegrityCheckValue = integrityCheckValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
