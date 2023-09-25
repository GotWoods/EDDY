using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class POCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "POC*0*m9*8*9**7*1n*39*B*iM*V*v3*M*wf*k*Ib*k*3c*K*aC*w*Ae*1*dZ*J*sb*e";

		var expected = new POC_LineItemChange()
		{
			AssignedIdentification = "0",
			ChangeOrResponseTypeCode = "m9",
			Quantity = 8,
			QuantityLeftToReceive = 9,
			CompositeUnitOfMeasure = null,
			UnitPrice = 7,
			BasisOfUnitPriceCode = "1n",
			ProductServiceIDQualifier = "39",
			ProductServiceID = "B",
			ProductServiceIDQualifier2 = "iM",
			ProductServiceID2 = "V",
			ProductServiceIDQualifier3 = "v3",
			ProductServiceID3 = "M",
			ProductServiceIDQualifier4 = "wf",
			ProductServiceID4 = "k",
			ProductServiceIDQualifier5 = "Ib",
			ProductServiceID5 = "k",
			ProductServiceIDQualifier6 = "3c",
			ProductServiceID6 = "K",
			ProductServiceIDQualifier7 = "aC",
			ProductServiceID7 = "w",
			ProductServiceIDQualifier8 = "Ae",
			ProductServiceID8 = "1",
			ProductServiceIDQualifier9 = "dZ",
			ProductServiceID9 = "J",
			ProductServiceIDQualifier10 = "sb",
			ProductServiceID10 = "e",
		};

		var actual = Map.MapObject<POC_LineItemChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m9", true)]
	public void Validation_RequiredChangeOrResponseTypeCode(string changeOrResponseTypeCode, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		//Test Parameters
		subject.ChangeOrResponseTypeCode = changeOrResponseTypeCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	


	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1n", 7, true)]
	[InlineData("1n", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBBasisOfUnitPriceCode(string basisOfUnitPriceCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("39", "B", true)]
	[InlineData("39", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iM", "V", true)]
	[InlineData("iM", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v3", "M", true)]
	[InlineData("v3", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wf", "k", true)]
	[InlineData("wf", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ib", "k", true)]
	[InlineData("Ib", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3c", "K", true)]
	[InlineData("3c", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aC", "w", true)]
	[InlineData("aC", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ae", "1", true)]
	[InlineData("Ae", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dZ", "J", true)]
	[InlineData("dZ", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ProductServiceIDQualifier10 = "sb";
			subject.ProductServiceID10 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sb", "e", true)]
	[InlineData("sb", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new POC_LineItemChange();
		//Required fields
		subject.ChangeOrResponseTypeCode = "m9";
		//Test Parameters
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || subject.Quantity != null)
		{
			subject.Quantity = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "39";
			subject.ProductServiceID = "B";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "iM";
			subject.ProductServiceID2 = "V";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "v3";
			subject.ProductServiceID3 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "wf";
			subject.ProductServiceID4 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ProductServiceIDQualifier5 = "Ib";
			subject.ProductServiceID5 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ProductServiceIDQualifier6 = "3c";
			subject.ProductServiceID6 = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ProductServiceIDQualifier7 = "aC";
			subject.ProductServiceID7 = "w";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ProductServiceIDQualifier8 = "Ae";
			subject.ProductServiceID8 = "1";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ProductServiceIDQualifier9 = "dZ";
			subject.ProductServiceID9 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
