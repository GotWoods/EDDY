using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S301Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "b:l:F";

		var expected = new S301_StatusOfTransferInteractive()
		{
			SenderSequenceNumber = "b",
			TransferPositionCoded = "l",
			DuplicateIndicator = "F",
		};

		var actual = Map.MapComposite<S301_StatusOfTransferInteractive>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
