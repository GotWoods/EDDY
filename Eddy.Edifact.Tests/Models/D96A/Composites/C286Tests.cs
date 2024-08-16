using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C286Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:d:w:N";

		var expected = new C286_SequenceInformation()
		{
			SequenceNumber = "d",
			SequenceNumberSourceCoded = "d",
			CodeListQualifier = "w",
			CodeListResponsibleAgencyCoded = "N",
		};

		var actual = Map.MapComposite<C286_SequenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredSequenceNumber(string sequenceNumber, bool isValidExpected)
	{
		var subject = new C286_SequenceInformation();
		//Required fields
		//Test Parameters
		subject.SequenceNumber = sequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
