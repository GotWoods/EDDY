using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G85Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G85*J";

		var expected = new G85_RecordIntegrityCheck()
		{
			IntegrityCheckValue = "J",
		};

		var actual = Map.MapObject<G85_RecordIntegrityCheck>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredIntegrityCheckValue(string integrityCheckValue, bool isValidExpected)
	{
		var subject = new G85_RecordIntegrityCheck();
		subject.IntegrityCheckValue = integrityCheckValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
