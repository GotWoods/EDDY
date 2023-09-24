using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class T6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T6*6*6*am*v4*5*3c*oa";

		var expected = new T6_TransitInboundRates()
		{
			AssignedNumber = 6,
			FreightRate = 6,
			RateValueQualifier = "am",
			CityName = "v4",
			FreightRate2 = 5,
			RateValueQualifier2 = "3c",
			CityName2 = "oa",
		};

		var actual = Map.MapObject<T6_TransitInboundRates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T6_TransitInboundRates();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
