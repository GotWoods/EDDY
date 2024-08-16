using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class MESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MES+";

		var expected = new MES_Measurements()
		{
			MeasurementValueAndDetails = null,
		};

		var actual = Map.MapObject<MES_Measurements>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredMeasurementValueAndDetails(string measurementValueAndDetails, bool isValidExpected)
	{
		var subject = new MES_Measurements();
		//Required fields
		//Test Parameters
		if (measurementValueAndDetails != "") 
			subject.MeasurementValueAndDetails = new E175_MeasurementValueAndDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
