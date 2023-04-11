using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SI*UK*E9*z*CU*c*tt*2*SS*e*QJ*0*Z4*p*hH*y*GS*l*9X*i*cK*5";

		var expected = new SI_ServiceCharacteristicIdentification()
		{
			AgencyQualifierCode = "UK",
			ServiceCharacteristicsQualifier = "E9",
			ProductServiceID = "z",
			ServiceCharacteristicsQualifier2 = "CU",
			ProductServiceID2 = "c",
			ServiceCharacteristicsQualifier3 = "tt",
			ProductServiceID3 = "2",
			ServiceCharacteristicsQualifier4 = "SS",
			ProductServiceID4 = "e",
			ServiceCharacteristicsQualifier5 = "QJ",
			ProductServiceID5 = "0",
			ServiceCharacteristicsQualifier6 = "Z4",
			ProductServiceID6 = "p",
			ServiceCharacteristicsQualifier7 = "hH",
			ProductServiceID7 = "y",
			ServiceCharacteristicsQualifier8 = "GS",
			ProductServiceID8 = "l",
			ServiceCharacteristicsQualifier9 = "9X",
			ProductServiceID9 = "i",
			ServiceCharacteristicsQualifier10 = "cK",
			ProductServiceID10 = "5",
		};

		var actual = Map.MapObject<SI_ServiceCharacteristicIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UK", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E9", true)]
	public void Validation_RequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("CU", "c", true)]
	[InlineData("", "c", false)]
	[InlineData("CU", "", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier2(string serviceCharacteristicsQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier2 = serviceCharacteristicsQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("tt", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("tt", "", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier3(string serviceCharacteristicsQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier3 = serviceCharacteristicsQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("SS", "e", true)]
	[InlineData("", "e", false)]
	[InlineData("SS", "", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier4(string serviceCharacteristicsQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier4 = serviceCharacteristicsQualifier4;
		subject.ProductServiceID4 = productServiceID4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("QJ", "0", true)]
	[InlineData("", "0", false)]
	[InlineData("QJ", "", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier5(string serviceCharacteristicsQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier5 = serviceCharacteristicsQualifier5;
		subject.ProductServiceID5 = productServiceID5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Z4", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("Z4", "", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier6(string serviceCharacteristicsQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier6 = serviceCharacteristicsQualifier6;
		subject.ProductServiceID6 = productServiceID6;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("hH", "y", true)]
	[InlineData("", "y", false)]
	[InlineData("hH", "", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier7(string serviceCharacteristicsQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier7 = serviceCharacteristicsQualifier7;
		subject.ProductServiceID7 = productServiceID7;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("GS", "l", true)]
	[InlineData("", "l", false)]
	[InlineData("GS", "", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier8(string serviceCharacteristicsQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier8 = serviceCharacteristicsQualifier8;
		subject.ProductServiceID8 = productServiceID8;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("9X", "i", true)]
	[InlineData("", "i", false)]
	[InlineData("9X", "", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier9(string serviceCharacteristicsQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier9 = serviceCharacteristicsQualifier9;
		subject.ProductServiceID9 = productServiceID9;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("cK", "5", true)]
	[InlineData("", "5", false)]
	[InlineData("cK", "", false)]
	public void Validation_AllAreRequiredServiceCharacteristicsQualifier10(string serviceCharacteristicsQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new SI_ServiceCharacteristicIdentification();
		subject.AgencyQualifierCode = "UK";
		subject.ServiceCharacteristicsQualifier = "E9";
		subject.ProductServiceID = "z";
		subject.ServiceCharacteristicsQualifier10 = serviceCharacteristicsQualifier10;
		subject.ProductServiceID10 = productServiceID10;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
