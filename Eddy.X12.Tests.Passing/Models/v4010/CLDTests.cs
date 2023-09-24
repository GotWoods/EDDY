using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLD*6*3*a5b*6*EY";

		var expected = new CLD_LoadDetail()
		{
			NumberOfLoads = 6,
			NumberOfUnitsShipped = 3,
			PackagingCode = "a5b",
			Size = 6,
			UnitOrBasisForMeasurementCode = "EY",
		};

		var actual = Map.MapObject<CLD_LoadDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumberOfLoads(int numberOfLoads, bool isValidExpected)
	{
		var subject = new CLD_LoadDetail();
		subject.NumberOfUnitsShipped = 3;
		if (numberOfLoads > 0)
			subject.NumberOfLoads = numberOfLoads;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, bool isValidExpected)
	{
		var subject = new CLD_LoadDetail();
		subject.NumberOfLoads = 6;
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("EY", 6, true)]
	[InlineData("EY", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal size, bool isValidExpected)
	{
		var subject = new CLD_LoadDetail();
		subject.NumberOfLoads = 6;
		subject.NumberOfUnitsShipped = 3;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (size > 0)
			subject.Size = size;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
