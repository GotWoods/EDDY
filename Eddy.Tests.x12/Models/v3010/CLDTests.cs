using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLD*4*6*P8qKA*5*la";

		var expected = new CLD_LoadDetail()
		{
			NumberOfLoads = 4,
			NumberOfUnitsShipped = 6,
			PackagingCode = "P8qKA",
			Size = 5,
			UnitOfMeasurementCode = "la",
		};

		var actual = Map.MapObject<CLD_LoadDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumberOfLoads(int numberOfLoads, bool isValidExpected)
	{
		var subject = new CLD_LoadDetail();
		subject.NumberOfUnitsShipped = 6;
		if (numberOfLoads > 0)
		subject.NumberOfLoads = numberOfLoads;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new CLD_LoadDetail();
		subject.NumberOfLoads = 4;
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
