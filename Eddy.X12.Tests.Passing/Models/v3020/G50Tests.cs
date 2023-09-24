using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G50Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G50*z*oFJAt0*L*j*2*761553*H1";

		var expected = new G50_PurchaseOrderIdentification()
		{
			OrderStatusCode = "z",
			PurchaseOrderDate = "oFJAt0",
			PurchaseOrderNumber = "L",
			TaxExemptCode = "j",
			MasterReferenceLinkNumber = "2",
			LinkSequenceNumber = 761553,
			PurchaseOrderTypeCode = "H1",
		};

		var actual = Map.MapObject<G50_PurchaseOrderIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredOrderStatusCode(string orderStatusCode, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.PurchaseOrderDate = "oFJAt0";
		subject.PurchaseOrderNumber = "L";
		subject.OrderStatusCode = orderStatusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "2";
			subject.LinkSequenceNumber = 761553;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oFJAt0", true)]
	public void Validation_RequiredPurchaseOrderDate(string purchaseOrderDate, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "z";
		subject.PurchaseOrderNumber = "L";
		subject.PurchaseOrderDate = purchaseOrderDate;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "2";
			subject.LinkSequenceNumber = 761553;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "z";
		subject.PurchaseOrderDate = "oFJAt0";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || !string.IsNullOrEmpty(subject.MasterReferenceLinkNumber) || subject.LinkSequenceNumber > 0)
		{
			subject.MasterReferenceLinkNumber = "2";
			subject.LinkSequenceNumber = 761553;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2", 761553, true)]
	[InlineData("2", 0, false)]
	[InlineData("", 761553, false)]
	public void Validation_AllAreRequiredMasterReferenceLinkNumber(string masterReferenceLinkNumber, int linkSequenceNumber, bool isValidExpected)
	{
		var subject = new G50_PurchaseOrderIdentification();
		subject.OrderStatusCode = "z";
		subject.PurchaseOrderDate = "oFJAt0";
		subject.PurchaseOrderNumber = "L";
		subject.MasterReferenceLinkNumber = masterReferenceLinkNumber;
		if (linkSequenceNumber > 0)
			subject.LinkSequenceNumber = linkSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
