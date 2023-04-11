using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PO7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO7*bxh**9*aR*8*X5*7*Hr*6*OE*E";

		var expected = new PO7_GiftContainerPhysicalDetails()
		{
			PackagingCode = "bxh",
			CompositeProductWeightBasis = null,
			Length = 9,
			UnitOrBasisForMeasurementCode = "aR",
			Width = 8,
			UnitOrBasisForMeasurementCode2 = "X5",
			Height = 7,
			UnitOrBasisForMeasurementCode3 = "Hr",
			ItemDepth = 6,
			UnitOrBasisForMeasurementCode4 = "OE",
			Description = "E",
		};

		var actual = Map.MapObject<PO7_GiftContainerPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "aR", true)]
	[InlineData(0, "aR", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		if (length > 0)
		subject.Length = length;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(9, 6, false)]
	[InlineData(0, 6, true)]
	[InlineData(9, 0, true)]
	public void Validation_OnlyOneOfLength(decimal length, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		if (length > 0)
		subject.Length = length;
		if (itemDepth > 0)
		subject.ItemDepth = itemDepth;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "X5", true)]
	[InlineData(0, "X5", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		if (width > 0)
		subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "Hr", true)]
	[InlineData(0, "Hr", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		if (height > 0)
		subject.Height = height;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6, "OE", true)]
	[InlineData(0, "OE", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO7_GiftContainerPhysicalDetails();
		if (itemDepth > 0)
		subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
