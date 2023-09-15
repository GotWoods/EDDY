using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ID1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID1*94lTv4xPxo8T*vp*Z*2*8*RQ*4*2*3*Kb*4*wA*P*e*3*RN*3*3*Pm*XywQhK*x*6*Bm*I*tk*W*9*3*J*8*4*r*2*5";

		var expected = new ID1_ItemDetailDimensions()
		{
			UPCConsumerPackageCode = "94lTv4xPxo8T",
			ProductServiceIDQualifier = "vp",
			ProductServiceID = "Z",
			FreeFormDescription = "2",
			Size = 8,
			UnitOfMeasurementCode = "RQ",
			Height = 4,
			Width = 2,
			ItemDepth = 3,
			UnitOfMeasurementCode2 = "Kb",
			Weight = 4,
			UnitOfMeasurementCode3 = "wA",
			CategoryReferenceCode = "P",
			Category = "e",
			Subcategory = "3",
			UnitOfMeasurementCode4 = "RN",
			Pack = 3,
			InnerPack = 3,
			DateQualifier = "Pm",
			Date = "XywQhK",
			NestingCode = "x",
			Nesting = 6,
			UnitOfMeasurementCode5 = "Bm",
			PegCode = "I",
			UnitOfMeasurementCode6 = "tk",
			ReferenceNumber = "W",
			XPeg = 9,
			YPeg = 3,
			ReferenceNumber2 = "J",
			XPeg2 = 8,
			YPeg2 = 4,
			ReferenceNumber3 = "r",
			XPeg3 = 2,
			YPeg3 = 5,
		};

		var actual = Map.MapObject<ID1_ItemDetailDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.Size = 8;
		subject.UnitOfMeasurementCode = "RQ";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 3;
		subject.UnitOfMeasurementCode2 = "Kb";
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredSize(decimal size, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "2";
		subject.UnitOfMeasurementCode = "RQ";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 3;
		subject.UnitOfMeasurementCode2 = "Kb";
		if (size > 0)
			subject.Size = size;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RQ", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "2";
		subject.Size = 8;
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 3;
		subject.UnitOfMeasurementCode2 = "Kb";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "2";
		subject.Size = 8;
		subject.UnitOfMeasurementCode = "RQ";
		subject.Width = 2;
		subject.ItemDepth = 3;
		subject.UnitOfMeasurementCode2 = "Kb";
		if (height > 0)
			subject.Height = height;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "2";
		subject.Size = 8;
		subject.UnitOfMeasurementCode = "RQ";
		subject.Height = 4;
		subject.ItemDepth = 3;
		subject.UnitOfMeasurementCode2 = "Kb";
		if (width > 0)
			subject.Width = width;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredItemDepth(decimal itemDepth, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "2";
		subject.Size = 8;
		subject.UnitOfMeasurementCode = "RQ";
		subject.Height = 4;
		subject.Width = 2;
		subject.UnitOfMeasurementCode2 = "Kb";
		if (itemDepth > 0)
			subject.ItemDepth = itemDepth;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kb", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new ID1_ItemDetailDimensions();
		subject.FreeFormDescription = "2";
		subject.Size = 8;
		subject.UnitOfMeasurementCode = "RQ";
		subject.Height = 4;
		subject.Width = 2;
		subject.ItemDepth = 3;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
