using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G50Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G50*3*hoXa52xI*E*z*S*676622*xk";

		var expected = new G50_PurchaseOrderIdentification()
		{
			OrderStatusCode = "3",
			Date = "hoXa52xI",
			PurchaseOrderNumber = "E",
			TaxExemptCode = "z",
			MasterReferenceLinkNumber = "S",
			LinkSequenceNumber = 676622,
			PurchaseOrderTypeCode = "xk",
		};

		var actual = Map.MapObject<G50_PurchaseOrderIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredOrderStatusCode(string orderStatusCode, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.Date = "hoXa52xI";
		subject.PurchaseOrderNumber = "E";
		subject.OrderStatusCode = orderStatusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "S";
			subject.LinkSequenceNumber = 676622;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hoXa52xI", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "3";
		subject.PurchaseOrderNumber = "E";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "S";
			subject.LinkSequenceNumber = 676622;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "3";
		subject.Date = "hoXa52xI";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "S";
			subject.LinkSequenceNumber = 676622;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("S", 676622, true)]
	[InlineData("S", 0, false)]
	[InlineData("", 676622, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "3";
		subject.Date = "hoXa52xI";
		subject.PurchaseOrderNumber = "E";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
