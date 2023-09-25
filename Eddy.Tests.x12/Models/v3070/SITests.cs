using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SI*mm*cV*m*Hg*2*bT*P*Rx*Y*um*y*uB*Y*O9*p*KD*g*nH*0*IE*Y";

		var expected = new SI_ServiceCharacteristicIdentification()
		{
			AgencyQualifierCode = "mm",
			ServiceCharacteristicsQualifier = "cV",
			ProductServiceID = "m",
			ServiceCharacteristicsQualifier2 = "Hg",
			ProductServiceID2 = "2",
			ServiceCharacteristicsQualifier3 = "bT",
			ProductServiceID3 = "P",
			ServiceCharacteristicsQualifier4 = "Rx",
			ProductServiceID4 = "Y",
			ServiceCharacteristicsQualifier5 = "um",
			ProductServiceID5 = "y",
			ServiceCharacteristicsQualifier6 = "uB",
			ProductServiceID6 = "Y",
			ServiceCharacteristicsQualifier7 = "O9",
			ProductServiceID7 = "p",
			ServiceCharacteristicsQualifier8 = "KD",
			ProductServiceID8 = "g",
			ServiceCharacteristicsQualifier9 = "nH",
			ProductServiceID9 = "0",
			ServiceCharacteristicsQualifier10 = "IE",
			ProductServiceID10 = "Y",
		};

		var actual = Map.MapObject<SI_ServiceCharacteristicIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mm", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cV", true)]
	public void Validation_RequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hg", "2", true)]
	[InlineData("Hg", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier2(string serviceCharacteristicsQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier2 = serviceCharacteristicsQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bT", "P", true)]
	[InlineData("bT", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier3(string serviceCharacteristicsQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier3 = serviceCharacteristicsQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Rx", "Y", true)]
	[InlineData("Rx", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier4(string serviceCharacteristicsQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier4 = serviceCharacteristicsQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("um", "y", true)]
	[InlineData("um", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier5(string serviceCharacteristicsQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier5 = serviceCharacteristicsQualifier5;
		subject.ProductServiceID5 = productServiceID5;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uB", "Y", true)]
	[InlineData("uB", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier6(string serviceCharacteristicsQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier6 = serviceCharacteristicsQualifier6;
		subject.ProductServiceID6 = productServiceID6;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O9", "p", true)]
	[InlineData("O9", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier7(string serviceCharacteristicsQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier7 = serviceCharacteristicsQualifier7;
		subject.ProductServiceID7 = productServiceID7;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KD", "g", true)]
	[InlineData("KD", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier8(string serviceCharacteristicsQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier8 = serviceCharacteristicsQualifier8;
		subject.ProductServiceID8 = productServiceID8;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nH", "0", true)]
	[InlineData("nH", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier9(string serviceCharacteristicsQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier9 = serviceCharacteristicsQualifier9;
		subject.ProductServiceID9 = productServiceID9;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier10) || !string.IsNullOrEmpty(subject.ProductServiceID10))
		{
			subject.ServiceCharacteristicsQualifier10 = "IE";
			subject.ProductServiceID10 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IE", "Y", true)]
	[InlineData("IE", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier10(string serviceCharacteristicsQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		//Required fields
		subject.AgencyQualifierCode = "mm";
		subject.ServiceCharacteristicsQualifier = "cV";
		subject.ProductServiceID = "m";
		//Test Parameters
		subject.ServiceCharacteristicsQualifier10 = serviceCharacteristicsQualifier10;
		subject.ProductServiceID10 = productServiceID10;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ServiceCharacteristicsQualifier2 = "Hg";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ServiceCharacteristicsQualifier3 = "bT";
			subject.ProductServiceID3 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ServiceCharacteristicsQualifier4 = "Rx";
			subject.ProductServiceID4 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier5) || !string.IsNullOrEmpty(subject.ProductServiceID5))
		{
			subject.ServiceCharacteristicsQualifier5 = "um";
			subject.ProductServiceID5 = "y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier6) || !string.IsNullOrEmpty(subject.ProductServiceID6))
		{
			subject.ServiceCharacteristicsQualifier6 = "uB";
			subject.ProductServiceID6 = "Y";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier7) || !string.IsNullOrEmpty(subject.ProductServiceID7))
		{
			subject.ServiceCharacteristicsQualifier7 = "O9";
			subject.ProductServiceID7 = "p";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier8) || !string.IsNullOrEmpty(subject.ProductServiceID8))
		{
			subject.ServiceCharacteristicsQualifier8 = "KD";
			subject.ProductServiceID8 = "g";
		}
		if(!string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ServiceCharacteristicsQualifier9) || !string.IsNullOrEmpty(subject.ProductServiceID9))
		{
			subject.ServiceCharacteristicsQualifier9 = "nH";
			subject.ProductServiceID9 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
