using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV*KP*D*3*Q";

		var expected = new SV_ServiceDescription()
		{
			UnitOfTimePeriodCode = "KP",
			ServiceStandard = "D",
			ServiceStandard2 = "3",
			TypeOfServiceOfferedCode = "Q",
		};

		var actual = Map.MapObject<SV_ServiceDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
