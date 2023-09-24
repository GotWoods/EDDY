using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLD*4*1*fy6Nk*5*Jw";

		var expected = new CLD_LoadDetail()
		{
			NumberOfLoads = 4,
			NumberOfUnitsShipped = 1,
			PackagingCode = "fy6Nk",
			Size = 5,
			UnitOrBasisForMeasurementCode = "Jw",
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
		subject.NumberOfUnitsShipped = 1;
		if (numberOfLoads > 0)
			subject.NumberOfLoads = numberOfLoads;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new CLD_LoadDetail();
		subject.NumberOfLoads = 4;
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
