using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SI*fz*te*Z*2V*u*pl*H*Cf*X*gW*y*If*P*UJ*i*hB*R*Xx*c*m8*f";

		var expected = new SI_ServiceCharacteristicIdentification()
		{
			AgencyQualifierCode = "fz",
			ServiceCharacteristicsQualifier = "te",
			ProductServiceID = "Z",
			ServiceCharacteristicsQualifier2 = "2V",
			ProductServiceID2 = "u",
			ServiceCharacteristicsQualifier3 = "pl",
			ProductServiceID3 = "H",
			ServiceCharacteristicsQualifier4 = "Cf",
			ProductServiceID4 = "X",
			ServiceCharacteristicsQualifier5 = "gW",
			ProductServiceID5 = "y",
			ServiceCharacteristicsQualifier6 = "If",
			ProductServiceID6 = "P",
			ServiceCharacteristicsQualifier7 = "UJ",
			ProductServiceID7 = "i",
			ServiceCharacteristicsQualifier8 = "hB",
			ProductServiceID8 = "R",
			ServiceCharacteristicsQualifier9 = "Xx",
			ProductServiceID9 = "c",
			ServiceCharacteristicsQualifier10 = "m8",
			ProductServiceID10 = "f",
		};

		var actual = Map.MapObject<SI_ServiceCharacteristicIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fz", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("te", true)]
	public void Validation_RequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2V", "u", true)]
	[InlineData("2V", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier2(string serviceCharacteristicsQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier2 = serviceCharacteristicsQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pl", "H", true)]
	[InlineData("pl", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier3(string serviceCharacteristicsQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier3 = serviceCharacteristicsQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Cf", "X", true)]
	[InlineData("Cf", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier4(string serviceCharacteristicsQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier4 = serviceCharacteristicsQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gW", "y", true)]
	[InlineData("gW", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier5(string serviceCharacteristicsQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier5 = serviceCharacteristicsQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("If", "P", true)]
	[InlineData("If", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier6(string serviceCharacteristicsQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier6 = serviceCharacteristicsQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UJ", "i", true)]
	[InlineData("UJ", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier7(string serviceCharacteristicsQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier7 = serviceCharacteristicsQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hB", "R", true)]
	[InlineData("hB", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier8(string serviceCharacteristicsQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier8 = serviceCharacteristicsQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xx", "c", true)]
	[InlineData("Xx", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier9(string serviceCharacteristicsQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier9 = serviceCharacteristicsQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "m8";
			subject.ProductServiceID10 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m8", "f", true)]
	[InlineData("m8", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier10(string serviceCharacteristicsQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "fz";
		subject.ServiceCharacteristicsQualifier = "te";
		subject.ProductServiceID = "Z";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier10 = serviceCharacteristicsQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "2V";
			subject.ProductServiceID2 = "u";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "pl";
			subject.ProductServiceID3 = "H";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Cf";
			subject.ProductServiceID4 = "X";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "gW";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "If";
			subject.ProductServiceID6 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "UJ";
			subject.ProductServiceID7 = "i";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "hB";
			subject.ProductServiceID8 = "R";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "Xx";
			subject.ProductServiceID9 = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
