using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PO4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO4*6*8*m9*PgQ*d*7*Ha*8*nr*9*8*4*Bg*2*Ry*7*w*1";

		var expected = new PO4_ItemPhysicalDetails()
		{
			Pack = 6,
			Size = 8,
			UnitOrBasisForMeasurementCode = "m9",
			PackagingCode = "PgQ",
			WeightQualifier = "d",
			GrossWeightPerPack = 7,
			UnitOrBasisForMeasurementCode2 = "Ha",
			GrossVolumePerPack = 8,
			UnitOrBasisForMeasurementCode3 = "nr",
			Length = 9,
			Width = 8,
			Height = 4,
			UnitOrBasisForMeasurementCode4 = "Bg",
			InnerPack = 2,
			SurfaceLayerPositionCode = "Ry",
			AssignedIdentification = "7",
			AssignedIdentification2 = "w",
			Number = 1,
		};

		var actual = Map.MapObject<PO4_ItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "m9", true)]
	[InlineData(0, "m9", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		if (size > 0)
		subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 7, true)]
	[InlineData("d", 0, false)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal grossWeightPerPack, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		subject.WeightQualifier = weightQualifier;
		if (grossWeightPerPack > 0)
		subject.GrossWeightPerPack = grossWeightPerPack;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "Ha", true)]
	[InlineData(0, "Ha", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		if (grossWeightPerPack > 0)
		subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "nr", true)]
	[InlineData(0, "nr", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		if (grossVolumePerPack > 0)
		subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Bg", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBLength(decimal length, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		if (length > 0)
		subject.Length = length;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Bg", true)]
	[InlineData(8, "", false)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		if (width > 0)
		subject.Width = width;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Bg", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		if (height > 0)
		subject.Height = height;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, 0, 0, true)]
	[InlineData("Bg", 9, 0, 0, true)]
	[InlineData("", 9, 0, 0, true)]
	[InlineData("Bg", 0, 0, 0, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode4(string unitOrBasisForMeasurementCode4, decimal length, decimal width, decimal height, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;
		if (length > 0)
		subject.Length = length;
		if (width > 0)
		subject.Width = width;
		if (height > 0)
		subject.Height = height;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "7", true)]
	[InlineData("w", "", false)]
	public void Validation_ARequiresBAssignedIdentification2(string assignedIdentification2, string assignedIdentification, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		subject.AssignedIdentification2 = assignedIdentification2;
		subject.AssignedIdentification = assignedIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "PgQ", true)]
	[InlineData(1, "", false)]
	public void Validation_ARequiresBNumber(int number, string packagingCode, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		if (number > 0)
		subject.Number = number;
		subject.PackagingCode = packagingCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
