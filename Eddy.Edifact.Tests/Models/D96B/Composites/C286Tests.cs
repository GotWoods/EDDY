using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C286Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "k:6:q:G";

		var expected = new C286_SequenceInformation()
		{
			SequenceNumber = "k",
			SequenceNumberSourceCoded = "6",
			CodeListQualifier = "q",
			CodeListResponsibleAgencyCoded = "G",
		};

		var actual = Map.MapComposite<C286_SequenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredSequenceNumber(string sequenceNumber, bool isValidExpected)
	{
		var subject = new C286_SequenceInformation();
		//Required fields
		//Test Parameters
		subject.SequenceNumber = sequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
