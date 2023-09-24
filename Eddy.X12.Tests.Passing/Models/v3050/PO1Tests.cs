using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PO1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PO1*j*7*5b*9*Jd*VD*R*VU*D*F9*P*Qt*1*we*a*3V*Q*sT*h*jJ*j*64*Z*Bb*0";

		var expected = new PO1_BaselineItemData()
		{
			AssignedIdentification = "j",
			QuantityOrdered = 7,
			UnitOrBasisForMeasurementCode = "5b",
			UnitPrice = 9,
			BasisOfUnitPriceCode = "Jd",
			ProductServiceIDQualifier = "VD",
			ProductServiceID = "R",
			ProductServiceIDQualifier2 = "VU",
			ProductServiceID2 = "D",
			ProductServiceIDQualifier3 = "F9",
			ProductServiceID3 = "P",
			ProductServiceIDQualifier4 = "Qt",
			ProductServiceID4 = "1",
			ProductServiceIDQualifier5 = "we",
			ProductServiceID5 = "a",
			ProductServiceIDQualifier6 = "3V",
			ProductServiceID6 = "Q",
			ProductServiceIDQualifier7 = "sT",
			ProductServiceID7 = "h",
			ProductServiceIDQualifier8 = "jJ",
			ProductServiceID8 = "j",
			ProductServiceIDQualifier9 = "64",
			ProductServiceID9 = "Z",
			ProductServiceIDQualifier10 = "Bb",
			ProductServiceID10 = "0",
		};

		var actual = Map.MapObject<PO1_BaselineItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("5b", 7, true)]
	[InlineData("5b", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Jd", 9, true)]
	[InlineData("Jd", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0)
			subject.UnitPrice = unitPrice;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VD", "R", true)]
	[InlineData("VD", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VU", "D", true)]
	[InlineData("VU", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F9", "P", true)]
	[InlineData("F9", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Qt", "1", true)]
	[InlineData("Qt", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("we", "a", true)]
	[InlineData("we", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3V", "Q", true)]
	[InlineData("3V", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sT", "h", true)]
	[InlineData("sT", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jJ", "j", true)]
	[InlineData("jJ", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("64", "Z", true)]
	[InlineData("64", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "Bb";
			subject.ProductServiceID10 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bb", "0", true)]
	[InlineData("Bb", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new PO1_BaselineItemData();
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VD";
			subject.ProductServiceID = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "VU";
			subject.ProductServiceID2 = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "F9";
			subject.ProductServiceID3 = "P";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Qt";
			subject.ProductServiceID4 = "1";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "we";
			subject.ProductServiceID5 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3V";
			subject.ProductServiceID6 = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "sT";
			subject.ProductServiceID7 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "jJ";
			subject.ProductServiceID8 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "64";
			subject.ProductServiceID9 = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
