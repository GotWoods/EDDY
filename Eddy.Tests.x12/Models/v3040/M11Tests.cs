using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class M11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M11*C*q*9*l*2*u*3*a*qD*l*E*Su*tO*9A*9R*h";

		var expected = new M11_ManifestBillOfLadingDetails()
		{
			BillOfLadingWaybillNumber = "C",
			LocationIdentifier = "q",
			Quantity = 9,
			ManifestUnitCode = "l",
			Weight = 2,
			WeightUnitCode = "u",
			Volume = 3,
			VolumeUnitQualifier = "a",
			BillOfLadingTypeCode = "qD",
			PlaceOfReceiptByPreCarrier = "l",
			BillOfLadingWaybillNumber2 = "E",
			StandardCarrierAlphaCode = "Su",
			StandardCarrierAlphaCode2 = "tO",
			StandardCarrierAlphaCode3 = "9A",
			StandardCarrierAlphaCode4 = "9R",
			ShippersExportDeclarationRequirements = "h",
		};

		var actual = Map.MapObject<M11_ManifestBillOfLadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.LocationIdentifier = "q";
		subject.Quantity = 9;
		subject.ManifestUnitCode = "l";
		subject.Weight = 2;
		subject.WeightUnitCode = "u";
		subject.StandardCarrierAlphaCode = "Su";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "a";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "E";
			subject.StandardCarrierAlphaCode2 = "tO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "C";
		subject.Quantity = 9;
		subject.ManifestUnitCode = "l";
		subject.Weight = 2;
		subject.WeightUnitCode = "u";
		subject.StandardCarrierAlphaCode = "Su";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "a";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "E";
			subject.StandardCarrierAlphaCode2 = "tO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "C";
		subject.LocationIdentifier = "q";
		subject.ManifestUnitCode = "l";
		subject.Weight = 2;
		subject.WeightUnitCode = "u";
		subject.StandardCarrierAlphaCode = "Su";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "a";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "E";
			subject.StandardCarrierAlphaCode2 = "tO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredManifestUnitCode(string manifestUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "C";
		subject.LocationIdentifier = "q";
		subject.Quantity = 9;
		subject.Weight = 2;
		subject.WeightUnitCode = "u";
		subject.StandardCarrierAlphaCode = "Su";
		//Test Parameters
		subject.ManifestUnitCode = manifestUnitCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "a";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "E";
			subject.StandardCarrierAlphaCode2 = "tO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "C";
		subject.LocationIdentifier = "q";
		subject.Quantity = 9;
		subject.ManifestUnitCode = "l";
		subject.WeightUnitCode = "u";
		subject.StandardCarrierAlphaCode = "Su";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "a";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "E";
			subject.StandardCarrierAlphaCode2 = "tO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "C";
		subject.LocationIdentifier = "q";
		subject.Quantity = 9;
		subject.ManifestUnitCode = "l";
		subject.Weight = 2;
		subject.StandardCarrierAlphaCode = "Su";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "a";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "E";
			subject.StandardCarrierAlphaCode2 = "tO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "a", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "a", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "C";
		subject.LocationIdentifier = "q";
		subject.Quantity = 9;
		subject.ManifestUnitCode = "l";
		subject.Weight = 2;
		subject.WeightUnitCode = "u";
		subject.StandardCarrierAlphaCode = "Su";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "E";
			subject.StandardCarrierAlphaCode2 = "tO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "tO", true)]
	[InlineData("E", "", false)]
	[InlineData("", "tO", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "C";
		subject.LocationIdentifier = "q";
		subject.Quantity = 9;
		subject.ManifestUnitCode = "l";
		subject.Weight = 2;
		subject.WeightUnitCode = "u";
		subject.StandardCarrierAlphaCode = "Su";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Su", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "C";
		subject.LocationIdentifier = "q";
		subject.Quantity = 9;
		subject.ManifestUnitCode = "l";
		subject.Weight = 2;
		subject.WeightUnitCode = "u";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "a";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "E";
			subject.StandardCarrierAlphaCode2 = "tO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
