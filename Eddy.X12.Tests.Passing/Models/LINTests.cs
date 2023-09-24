using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LIN*w*jX*D*qu*p*x4*f*1C*1*tL*H*dB*B*nA*g*Uo*w*c1*2*f8*x*mx*C*61*u*vT*z*N4*h*la*I";

		var expected = new LIN_ItemIdentification()
		{
			AssignedIdentification = "w",
			ProductServiceIDQualifier = "jX",
			ProductServiceID = "D",
			ProductServiceIDQualifier2 = "qu",
			ProductServiceID2 = "p",
			ProductServiceIDQualifier3 = "x4",
			ProductServiceID3 = "f",
			ProductServiceIDQualifier4 = "1C",
			ProductServiceID4 = "1",
			ProductServiceIDQualifier5 = "tL",
			ProductServiceID5 = "H",
			ProductServiceIDQualifier6 = "dB",
			ProductServiceID6 = "B",
			ProductServiceIDQualifier7 = "nA",
			ProductServiceID7 = "g",
			ProductServiceIDQualifier8 = "Uo",
			ProductServiceID8 = "w",
			ProductServiceIDQualifier9 = "c1",
			ProductServiceID9 = "2",
			ProductServiceIDQualifier10 = "f8",
			ProductServiceID10 = "x",
			ProductServiceIDQualifier11 = "mx",
			ProductServiceID11 = "C",
			ProductServiceIDQualifier12 = "61",
			ProductServiceID12 = "u",
			ProductServiceIDQualifier13 = "vT",
			ProductServiceID13 = "z",
			ProductServiceIDQualifier14 = "N4",
			ProductServiceID14 = "h",
			ProductServiceIDQualifier15 = "la",
			ProductServiceID15 = "I",
		};

		var actual = Map.MapObject<LIN_ItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jX", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("qu", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("qu", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("x4", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("x4", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("1C", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("1C", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("tL", "H", true)]
	[InlineData("", "H", false)]
	[InlineData("tL", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
		subject.ProductServiceID5 = productServiceID5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("dB", "B", true)]
	[InlineData("", "B", false)]
	[InlineData("dB", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
		subject.ProductServiceID6 = productServiceID6;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("nA", "g", true)]
	[InlineData("", "g", false)]
	[InlineData("nA", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
		subject.ProductServiceID7 = productServiceID7;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Uo", "w", true)]
	[InlineData("", "w", false)]
	[InlineData("Uo", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
		subject.ProductServiceID8 = productServiceID8;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("c1", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("c1", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
		subject.ProductServiceID9 = productServiceID9;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("f8", "x", true)]
	[InlineData("", "x", false)]
	[InlineData("f8", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
		subject.ProductServiceID10 = productServiceID10;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("mx", "C", true)]
	[InlineData("", "C", false)]
	[InlineData("mx", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier11(string productServiceIDQualifier11, string productServiceID11, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier11 = productServiceIDQualifier11;
		subject.ProductServiceID11 = productServiceID11;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("61", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("61", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier12(string productServiceIDQualifier12, string productServiceID12, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier12 = productServiceIDQualifier12;
		subject.ProductServiceID12 = productServiceID12;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("vT", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("vT", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier13(string productServiceIDQualifier13, string productServiceID13, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier13 = productServiceIDQualifier13;
		subject.ProductServiceID13 = productServiceID13;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("N4", "h", true)]
	[InlineData("", "h", false)]
	[InlineData("N4", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier14(string productServiceIDQualifier14, string productServiceID14, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier14 = productServiceIDQualifier14;
		subject.ProductServiceID14 = productServiceID14;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("la", "I", true)]
	[InlineData("", "I", false)]
	[InlineData("la", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier15(string productServiceIDQualifier15, string productServiceID15, bool isValidExpected)
	{
		var subject = new LIN_ItemIdentification();
		subject.ProductServiceIDQualifier = "jX";
		subject.ProductServiceID = "D";
		subject.ProductServiceIDQualifier15 = productServiceIDQualifier15;
		subject.ProductServiceID15 = productServiceID15;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
