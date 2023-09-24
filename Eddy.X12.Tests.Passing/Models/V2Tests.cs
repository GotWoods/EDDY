using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class V2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V2*l*x*6*h*9*J*6*B*3*a*4*G*8*3*iZ*4*5";

		var expected = new V2_VesselInformation()
		{
			LocationIdentifier = "l",
			ReferenceIdentification = "x",
			Weight = 6,
			WeightUnitCode = "h",
			Weight2 = 9,
			WeightUnitCode2 = "J",
			Weight3 = 6,
			WeightUnitCode3 = "B",
			Weight4 = 3,
			WeightUnitCode4 = "a",
			Weight5 = 4,
			WeightUnitCode5 = "G",
			Name = "8",
			Length = 3,
			UnitOrBasisForMeasurementCode = "iZ",
			Quantity = 4,
			Quantity2 = 5,
		};

		var actual = Map.MapObject<V2_VesselInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6, "h", true)]
	[InlineData(0, "h", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight > 0)
		subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "J", true)]
	[InlineData(0, "J", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredWeight2(decimal weight2, string weightUnitCode2, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight2 > 0)
		subject.Weight2 = weight2;
		subject.WeightUnitCode2 = weightUnitCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6, "B", true)]
	[InlineData(0, "B", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredWeight3(decimal weight3, string weightUnitCode3, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight3 > 0)
		subject.Weight3 = weight3;
		subject.WeightUnitCode3 = weightUnitCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "a", true)]
	[InlineData(0, "a", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredWeight4(decimal weight4, string weightUnitCode4, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight4 > 0)
		subject.Weight4 = weight4;
		subject.WeightUnitCode4 = weightUnitCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "G", true)]
	[InlineData(0, "G", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredWeight5(decimal weight5, string weightUnitCode5, bool isValidExpected)
	{
		var subject = new V2_VesselInformation();
		if (weight5 > 0)
		subject.Weight5 = weight5;
		subject.WeightUnitCode5 = weightUnitCode5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
