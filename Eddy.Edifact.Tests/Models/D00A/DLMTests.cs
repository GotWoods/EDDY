using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DLMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DLM+h+++j";

		var expected = new DLM_DeliveryLimitations()
		{
			BackOrderArrangementTypeCode = "h",
			Instruction = null,
			SpecialServicesIdentification = null,
			SubstitutionConditionCode = "j",
		};

		var actual = Map.MapObject<DLM_DeliveryLimitations>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
