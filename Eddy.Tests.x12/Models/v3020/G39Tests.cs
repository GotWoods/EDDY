using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G39Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G39*c2ZEvlCbwYU4*46*a*17*5*i*K*7*Kh*3*sM*3*rS*3*na*286838*6*1*5B*z*3*8*HQ*S";

		var expected = new G39_ItemCharacteristicsVendorsSellingUnit()
		{
			UPCCaseCode = "c2ZEvlCbwYU4",
			ProductServiceIDQualifier = "46",
			ProductServiceID = "a",
			SpecialHandlingCode = "17",
			UnitWeight = 5,
			WeightQualifier = "i",
			WeightUnitQualifier = "K",
			Height = 7,
			UnitOfMeasurementCode = "Kh",
			Width = 3,
			UnitOfMeasurementCode2 = "sM",
			Length = 3,
			UnitOfMeasurementCode3 = "rS",
			Volume = 3,
			UnitOfMeasurementCode4 = "na",
			PalletBlockAndTiers = 286838,
			Pack = 6,
			Size = 1,
			UnitOfMeasurementCode5 = "5B",
			Color = "z",
			EquivalentWeight = 3,
			AlternateTiersPerPallet = "8",
			ProductServiceIDQualifier2 = "HQ",
			ProductServiceID2 = "S",
		};

		var actual = Map.MapObject<G39_ItemCharacteristicsVendorsSellingUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("c2ZEvlCbwYU4", "46", true)]
	[InlineData("c2ZEvlCbwYU4", "", true)]
	[InlineData("", "46", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "46";
			subject.ProductServiceID = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.WeightQualifier = "i";
			subject.WeightUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOfMeasurementCode = "Kh";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOfMeasurementCode2 = "sM";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 3;
			subject.UnitOfMeasurementCode3 = "rS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode4 = "na";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 1;
			subject.UnitOfMeasurementCode5 = "5B";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "HQ";
			subject.ProductServiceID2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("46", "a", true)]
	[InlineData("46", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "c2ZEvlCbwYU4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.WeightQualifier = "i";
			subject.WeightUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOfMeasurementCode = "Kh";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOfMeasurementCode2 = "sM";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 3;
			subject.UnitOfMeasurementCode3 = "rS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode4 = "na";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 1;
			subject.UnitOfMeasurementCode5 = "5B";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "HQ";
			subject.ProductServiceID2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "K", true)]
	[InlineData("i", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, string weightUnitQualifier, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.WeightQualifier = weightQualifier;
		subject.WeightUnitQualifier = weightUnitQualifier;
			subject.UPCCaseCode = "c2ZEvlCbwYU4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "46";
			subject.ProductServiceID = "a";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOfMeasurementCode = "Kh";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOfMeasurementCode2 = "sM";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 3;
			subject.UnitOfMeasurementCode3 = "rS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode4 = "na";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 1;
			subject.UnitOfMeasurementCode5 = "5B";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "HQ";
			subject.ProductServiceID2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "Kh", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "Kh", false)]
	public void Validation_AllAreRequiredHeight(decimal height, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (height > 0)
			subject.Height = height;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
			subject.UPCCaseCode = "c2ZEvlCbwYU4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "46";
			subject.ProductServiceID = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.WeightQualifier = "i";
			subject.WeightUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOfMeasurementCode2 = "sM";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 3;
			subject.UnitOfMeasurementCode3 = "rS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode4 = "na";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 1;
			subject.UnitOfMeasurementCode5 = "5B";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "HQ";
			subject.ProductServiceID2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "sM", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "sM", false)]
	public void Validation_AllAreRequiredWidth(decimal width, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (width > 0)
			subject.Width = width;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
			subject.UPCCaseCode = "c2ZEvlCbwYU4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "46";
			subject.ProductServiceID = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.WeightQualifier = "i";
			subject.WeightUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOfMeasurementCode = "Kh";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 3;
			subject.UnitOfMeasurementCode3 = "rS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode4 = "na";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 1;
			subject.UnitOfMeasurementCode5 = "5B";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "HQ";
			subject.ProductServiceID2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "rS", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "rS", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (length > 0)
			subject.Length = length;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
			subject.UPCCaseCode = "c2ZEvlCbwYU4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "46";
			subject.ProductServiceID = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.WeightQualifier = "i";
			subject.WeightUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOfMeasurementCode = "Kh";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOfMeasurementCode2 = "sM";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode4 = "na";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 1;
			subject.UnitOfMeasurementCode5 = "5B";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "HQ";
			subject.ProductServiceID2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "na", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "na", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode4, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOfMeasurementCode4 = unitOfMeasurementCode4;
			subject.UPCCaseCode = "c2ZEvlCbwYU4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "46";
			subject.ProductServiceID = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.WeightQualifier = "i";
			subject.WeightUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOfMeasurementCode = "Kh";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOfMeasurementCode2 = "sM";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 3;
			subject.UnitOfMeasurementCode3 = "rS";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 1;
			subject.UnitOfMeasurementCode5 = "5B";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "HQ";
			subject.ProductServiceID2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "5B", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "5B", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOfMeasurementCode5, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		if (size > 0)
			subject.Size = size;
		subject.UnitOfMeasurementCode5 = unitOfMeasurementCode5;
			subject.UPCCaseCode = "c2ZEvlCbwYU4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "46";
			subject.ProductServiceID = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.WeightQualifier = "i";
			subject.WeightUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOfMeasurementCode = "Kh";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOfMeasurementCode2 = "sM";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 3;
			subject.UnitOfMeasurementCode3 = "rS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode4 = "na";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "HQ";
			subject.ProductServiceID2 = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HQ", "S", true)]
	[InlineData("HQ", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "c2ZEvlCbwYU4";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "46";
			subject.ProductServiceID = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightUnitQualifier))
		{
			subject.WeightQualifier = "i";
			subject.WeightUnitQualifier = "K";
		}
		//If one is filled, all are required
		if(subject.Height > 0 || subject.Height > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Height = 7;
			subject.UnitOfMeasurementCode = "Kh";
		}
		//If one is filled, all are required
		if(subject.Width > 0 || subject.Width > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Width = 3;
			subject.UnitOfMeasurementCode2 = "sM";
		}
		//If one is filled, all are required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Length = 3;
			subject.UnitOfMeasurementCode3 = "rS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode4))
		{
			subject.Volume = 3;
			subject.UnitOfMeasurementCode4 = "na";
		}
		//If one is filled, all are required
		if(subject.Size > 0 || subject.Size > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode5))
		{
			subject.Size = 1;
			subject.UnitOfMeasurementCode5 = "5B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
