using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PO4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO4*6*4*Pe*pHQwa*b*5*k9*8*Pp*5*3*2*Bd";

		var expected = new PO4_ItemPhysicalDetails()
		{
			Pack = 6,
			Size = 4,
			UnitOfMeasurementCode = "Pe",
			PackagingCode = "pHQwa",
			WeightQualifier = "b",
			GrossWeightPerPack = 5,
			UnitOfMeasurementCode2 = "k9",
			GrossVolumePerPack = 8,
			UnitOfMeasurementCode3 = "Pp",
			Length = 5,
			Width = 3,
			Height = 2,
			UnitOfMeasurementCode4 = "Bd",
		};

		var actual = Map.MapObject<PO4_ItemPhysicalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Pe", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Pe", true)]
	public void Validation_ARequiresBSize(decimal size, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (size > 0) 
			subject.Size = size;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.WeightQualifier = "b";
			subject.GrossWeightPerPack = 5;
			subject.UnitOfMeasurementCode2 = "k9";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOfMeasurementCode4 = "Bd";
			subject.Length = 5;
			subject.Width = 3;
			subject.Height = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, "", true)]
	[InlineData("b", 5, "k9", true)]
	[InlineData("b", 0, "", false)]
	[InlineData("", 5, "k9", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_WeightQualifier(string weightQualifier, decimal grossWeightPerPack, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (grossWeightPerPack > 0) 
			subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOfMeasurementCode4 = "Bd";
			subject.Length = 5;
			subject.Width = 3;
			subject.Height = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "Pp", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "Pp", true)]
	public void Validation_ARequiresBGrossVolumePerPack(decimal grossVolumePerPack, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		if (grossVolumePerPack > 0) 
			subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.WeightQualifier = "b";
			subject.GrossWeightPerPack = 5;
			subject.UnitOfMeasurementCode2 = "k9";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode4) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4) || subject.Length > 0 || subject.Width > 0 || subject.Height > 0)
		{
			subject.UnitOfMeasurementCode4 = "Bd";
			subject.Length = 5;
			subject.Width = 3;
			subject.Height = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, 0, 0, true)]
	[InlineData("Bd", 5, 3, 2, true)]
	[InlineData("Bd", 0, 0, 0, false)]
	[InlineData("", 5, 3, 2, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOfMeasurementCode4(string unitOfMeasurementCode4, decimal length, decimal width, decimal height, bool isValidExpected)
	{
		var subject = new PO4_ItemPhysicalDetails();
		//Required fields
		//Test Parameters
		subject.UnitOfMeasurementCode4 = unitOfMeasurementCode4;
		if (length > 0) 
			subject.Length = length;
		if (width > 0) 
			subject.Width = width;
		if (height > 0) 
			subject.Height = height;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.GrossWeightPerPack > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.WeightQualifier = "b";
			subject.GrossWeightPerPack = 5;
			subject.UnitOfMeasurementCode2 = "k9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
