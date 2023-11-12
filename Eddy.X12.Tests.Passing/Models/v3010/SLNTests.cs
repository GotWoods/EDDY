using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SLN*8*f*V*8*MW*5*ss*3*G9*b*JM*S*fM*r*xM*X*xN*d*xF*k*Yu*m*Ia*L*93*N*Gj*M";

		var expected = new SLN_SublineItemDetail()
		{
			AssignedIdentification = "8",
			AssignedIdentification2 = "f",
			ConfigurationCode = "V",
			Quantity = 8,
			UnitOfMeasurementCode = "MW",
			UnitPrice = 5,
			BasisOfUnitPriceCode = "ss",
			SublinePriceChangeCodeID = "3",
			ProductServiceIDQualifier = "G9",
			ProductServiceID = "b",
			ProductServiceIDQualifier2 = "JM",
			ProductServiceID2 = "S",
			ProductServiceIDQualifier3 = "fM",
			ProductServiceID3 = "r",
			ProductServiceIDQualifier4 = "xM",
			ProductServiceID4 = "X",
			ProductServiceIDQualifier5 = "xN",
			ProductServiceID5 = "d",
			ProductServiceIDQualifier6 = "xF",
			ProductServiceID6 = "k",
			ProductServiceIDQualifier7 = "Yu",
			ProductServiceID7 = "m",
			ProductServiceIDQualifier8 = "Ia",
			ProductServiceID8 = "L",
			ProductServiceIDQualifier9 = "93",
			ProductServiceID9 = "N",
			ProductServiceIDQualifier10 = "Gj",
			ProductServiceID10 = "M",
		};

		var actual = Map.MapObject<SLN_SublineItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.ConfigurationCode = "V";
		subject.Quantity = 8;
		subject.UnitOfMeasurementCode = "MW";
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredConfigurationCode(string configurationCode, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "8";
		subject.Quantity = 8;
		subject.UnitOfMeasurementCode = "MW";
		//Test Parameters
		subject.ConfigurationCode = configurationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "8";
		subject.ConfigurationCode = "V";
		subject.UnitOfMeasurementCode = "MW";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MW", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new SLN_SublineItemDetail();
		//Required fields
		subject.AssignedIdentification = "8";
		subject.ConfigurationCode = "V";
		subject.Quantity = 8;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
