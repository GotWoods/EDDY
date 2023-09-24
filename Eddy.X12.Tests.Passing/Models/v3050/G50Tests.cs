using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G50Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G50*S*wcPBoj*V*d*q*994839*Hm";

		var expected = new G50_PurchaseOrderIdentification()
		{
			OrderStatusCode = "S",
			Date = "wcPBoj",
			PurchaseOrderNumber = "V",
			TaxExemptCode = "d",
			MasterReferenceLinkNumber = "q",
			LinkSequenceNumber = 994839,
			PurchaseOrderTypeCode = "Hm",
		};

		var actual = Map.MapObject<G50_PurchaseOrderIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredOrderStatusCode(string orderStatusCode, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.Date = "wcPBoj";
		subject.PurchaseOrderNumber = "V";
		subject.OrderStatusCode = orderStatusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "q";
			subject.LinkSequenceNumber = 994839;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wcPBoj", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "S";
		subject.PurchaseOrderNumber = "V";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "q";
			subject.LinkSequenceNumber = 994839;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "S";
		subject.Date = "wcPBoj";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "q";
			subject.LinkSequenceNumber = 994839;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("q", 994839, true)]
	[InlineData("q", 0, false)]
	[InlineData("", 994839, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "S";
		subject.Date = "wcPBoj";
		subject.PurchaseOrderNumber = "V";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
