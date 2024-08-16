using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C831Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "E:J:w:a:o:d";

		var expected = new C831_ResultDetails()
		{
			MeasurementValue = "E",
			MeasurementSignificanceCoded = "J",
			MeasurementAttributeIdentification = "w",
			CodeListQualifier = "a",
			CodeListResponsibleAgencyCoded = "o",
			MeasurementAttribute = "d",
		};

		var actual = Map.MapComposite<C831_ResultDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
