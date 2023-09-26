using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SI*Hl*Nq*i*zQ*I*e1*S*35*n*R3*5*GQ*D*IY*q*DV*r*5g*p*cy*n";

		var expected = new SI_ServiceCharacteristicIdentification()
		{
			AgencyQualifierCode = "Hl",
			ServiceCharacteristicsQualifier = "Nq",
			ProductServiceID = "i",
			ServiceCharacteristicsQualifier2 = "zQ",
			ProductServiceID2 = "I",
			ServiceCharacteristicsQualifier3 = "e1",
			ProductServiceID3 = "S",
			ServiceCharacteristicsQualifier4 = "35",
			ProductServiceID4 = "n",
			ServiceCharacteristicsQualifier5 = "R3",
			ProductServiceID5 = "5",
			ServiceCharacteristicsQualifier6 = "GQ",
			ProductServiceID6 = "D",
			ServiceCharacteristicsQualifier7 = "IY",
			ProductServiceID7 = "q",
			ServiceCharacteristicsQualifier8 = "DV",
			ProductServiceID8 = "r",
			ServiceCharacteristicsQualifier9 = "5g",
			ProductServiceID9 = "p",
			ServiceCharacteristicsQualifier10 = "cy",
			ProductServiceID10 = "n",
		};

		var actual = Map.MapObject<SI_ServiceCharacteristicIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hl", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nq", true)]
	public void Validation_RequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zQ", "I", true)]
	[InlineData("zQ", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier2(string serviceCharacteristicsQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier2 = serviceCharacteristicsQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e1", "S", true)]
	[InlineData("e1", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier3(string serviceCharacteristicsQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier3 = serviceCharacteristicsQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("35", "n", true)]
	[InlineData("35", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier4(string serviceCharacteristicsQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier4 = serviceCharacteristicsQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R3", "5", true)]
	[InlineData("R3", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier5(string serviceCharacteristicsQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier5 = serviceCharacteristicsQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GQ", "D", true)]
	[InlineData("GQ", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier6(string serviceCharacteristicsQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier6 = serviceCharacteristicsQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IY", "q", true)]
	[InlineData("IY", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier7(string serviceCharacteristicsQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier7 = serviceCharacteristicsQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("DV", "r", true)]
	[InlineData("DV", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier8(string serviceCharacteristicsQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier8 = serviceCharacteristicsQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5g", "p", true)]
	[InlineData("5g", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier9(string serviceCharacteristicsQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier9 = serviceCharacteristicsQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "cy";
			subject.ProductServiceID10 = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cy", "n", true)]
	[InlineData("cy", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier10(string serviceCharacteristicsQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "Hl";
		subject.ServiceCharacteristicsQualifier = "Nq";
		subject.ProductServiceID = "i";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier10 = serviceCharacteristicsQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "zQ";
			subject.ProductServiceID2 = "I";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "e1";
			subject.ProductServiceID3 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "35";
			subject.ProductServiceID4 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "R3";
			subject.ProductServiceID5 = "5";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "GQ";
			subject.ProductServiceID6 = "D";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "IY";
			subject.ProductServiceID7 = "q";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "DV";
			subject.ProductServiceID8 = "r";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "5g";
			subject.ProductServiceID9 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
