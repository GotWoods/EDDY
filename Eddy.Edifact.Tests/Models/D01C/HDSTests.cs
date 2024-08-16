using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class HDSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HDS+++";

		var expected = new HDS_HealthDiagnosisServiceAndDelivery()
		{
			Diagnosis = null,
			Service = null,
			DeliveryPattern = null,
		};

		var actual = Map.MapObject<HDS_HealthDiagnosisServiceAndDelivery>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
