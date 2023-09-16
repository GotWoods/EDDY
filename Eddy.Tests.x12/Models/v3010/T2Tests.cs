using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class T2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T2*1*o*4*4*8*gm*8*dt*tF*oA*Is*FM";

		var expected = new T2_TransitInboundLading()
		{
			AssignedNumber = 1,
			LadingDescription = "o",
			TransitPortionWeight = 4,
			WeightQualifier = "4",
			FreightRate = 8,
			RateValueQualifier = "gm",
			FreightRate2 = 8,
			RateValueQualifier2 = "dt",
			CityName = "tF",
			CityName2 = "oA",
			ThroughSurchargePercent = "Is",
			PaidInSurchargePercent = "FM",
		};

		var actual = Map.MapObject<T2_TransitInboundLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T2_TransitInboundLading();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
