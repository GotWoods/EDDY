using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class IT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IT1*d*8*fd*3*5O*x0*O*Ah*f*bA*F*Jn*R*oT*I*la*d*pc*j*CL*F*0m*c*mh*2";

		var expected = new IT1_BaselineItemDataInvoice()
		{
			AssignedIdentification = "d",
			QuantityInvoiced = 8,
			UnitOrBasisForMeasurementCode = "fd",
			UnitPrice = 3,
			BasisOfUnitPriceCode = "5O",
			ProductServiceIDQualifier = "x0",
			ProductServiceID = "O",
			ProductServiceIDQualifier2 = "Ah",
			ProductServiceID2 = "f",
			ProductServiceIDQualifier3 = "bA",
			ProductServiceID3 = "F",
			ProductServiceIDQualifier4 = "Jn",
			ProductServiceID4 = "R",
			ProductServiceIDQualifier5 = "oT",
			ProductServiceID5 = "I",
			ProductServiceIDQualifier6 = "la",
			ProductServiceID6 = "d",
			ProductServiceIDQualifier7 = "pc",
			ProductServiceID7 = "j",
			ProductServiceIDQualifier8 = "CL",
			ProductServiceID8 = "F",
			ProductServiceIDQualifier9 = "0m",
			ProductServiceID9 = "c",
			ProductServiceIDQualifier10 = "mh",
			ProductServiceID10 = "2",
		};

		var actual = Map.MapObject<IT1_BaselineItemDataInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x0", "O", true)]
	[InlineData("x0", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ah";
			subject.ProductServiceID2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bA";
			subject.ProductServiceID3 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Jn";
			subject.ProductServiceID4 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "oT";
			subject.ProductServiceID5 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "la";
			subject.ProductServiceID6 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "pc";
			subject.ProductServiceID7 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "CL";
			subject.ProductServiceID8 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "0m";
			subject.ProductServiceID9 = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "mh";
			subject.ProductServiceID10 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ah", "f", true)]
	[InlineData("Ah", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "x0";
			subject.ProductServiceID = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bA";
			subject.ProductServiceID3 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Jn";
			subject.ProductServiceID4 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "oT";
			subject.ProductServiceID5 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "la";
			subject.ProductServiceID6 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "pc";
			subject.ProductServiceID7 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "CL";
			subject.ProductServiceID8 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "0m";
			subject.ProductServiceID9 = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "mh";
			subject.ProductServiceID10 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bA", "F", true)]
	[InlineData("bA", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "x0";
			subject.ProductServiceID = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ah";
			subject.ProductServiceID2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Jn";
			subject.ProductServiceID4 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "oT";
			subject.ProductServiceID5 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "la";
			subject.ProductServiceID6 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "pc";
			subject.ProductServiceID7 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "CL";
			subject.ProductServiceID8 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "0m";
			subject.ProductServiceID9 = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "mh";
			subject.ProductServiceID10 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Jn", "R", true)]
	[InlineData("Jn", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "x0";
			subject.ProductServiceID = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ah";
			subject.ProductServiceID2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bA";
			subject.ProductServiceID3 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "oT";
			subject.ProductServiceID5 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "la";
			subject.ProductServiceID6 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "pc";
			subject.ProductServiceID7 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "CL";
			subject.ProductServiceID8 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "0m";
			subject.ProductServiceID9 = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "mh";
			subject.ProductServiceID10 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oT", "I", true)]
	[InlineData("oT", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "x0";
			subject.ProductServiceID = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ah";
			subject.ProductServiceID2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bA";
			subject.ProductServiceID3 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Jn";
			subject.ProductServiceID4 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "la";
			subject.ProductServiceID6 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "pc";
			subject.ProductServiceID7 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "CL";
			subject.ProductServiceID8 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "0m";
			subject.ProductServiceID9 = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "mh";
			subject.ProductServiceID10 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("la", "d", true)]
	[InlineData("la", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "x0";
			subject.ProductServiceID = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ah";
			subject.ProductServiceID2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bA";
			subject.ProductServiceID3 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Jn";
			subject.ProductServiceID4 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "oT";
			subject.ProductServiceID5 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "pc";
			subject.ProductServiceID7 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "CL";
			subject.ProductServiceID8 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "0m";
			subject.ProductServiceID9 = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "mh";
			subject.ProductServiceID10 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pc", "j", true)]
	[InlineData("pc", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "x0";
			subject.ProductServiceID = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ah";
			subject.ProductServiceID2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bA";
			subject.ProductServiceID3 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Jn";
			subject.ProductServiceID4 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "oT";
			subject.ProductServiceID5 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "la";
			subject.ProductServiceID6 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "CL";
			subject.ProductServiceID8 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "0m";
			subject.ProductServiceID9 = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "mh";
			subject.ProductServiceID10 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CL", "F", true)]
	[InlineData("CL", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "x0";
			subject.ProductServiceID = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ah";
			subject.ProductServiceID2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bA";
			subject.ProductServiceID3 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Jn";
			subject.ProductServiceID4 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "oT";
			subject.ProductServiceID5 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "la";
			subject.ProductServiceID6 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "pc";
			subject.ProductServiceID7 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "0m";
			subject.ProductServiceID9 = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "mh";
			subject.ProductServiceID10 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0m", "c", true)]
	[InlineData("0m", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "x0";
			subject.ProductServiceID = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ah";
			subject.ProductServiceID2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bA";
			subject.ProductServiceID3 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Jn";
			subject.ProductServiceID4 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "oT";
			subject.ProductServiceID5 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "la";
			subject.ProductServiceID6 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "pc";
			subject.ProductServiceID7 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "CL";
			subject.ProductServiceID8 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "mh";
			subject.ProductServiceID10 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mh", "2", true)]
	[InlineData("mh", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new IT1_BaselineItemDataInvoice();
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "x0";
			subject.ProductServiceID = "O";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ah";
			subject.ProductServiceID2 = "f";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "bA";
			subject.ProductServiceID3 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "Jn";
			subject.ProductServiceID4 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "oT";
			subject.ProductServiceID5 = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "la";
			subject.ProductServiceID6 = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "pc";
			subject.ProductServiceID7 = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "CL";
			subject.ProductServiceID8 = "F";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "0m";
			subject.ProductServiceID9 = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
