using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class X3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X3*qnR0yr*jduNEF*uDT4nF*Dof8eX";

		var expected = new X3_ImportDates()
		{
			ExportationDate = "qnR0yr",
			ArrivalDate = "jduNEF",
			CarrierCertificatedReleaseDate = "uDT4nF",
			StandardCustomsInvoiceDate = "Dof8eX",
		};

		var actual = Map.MapObject<X3_ImportDates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qnR0yr", true)]
	public void Validation_RequiredExportationDate(string exportationDate, bool isValidExpected)
	{
		var subject = new X3_ImportDates();
		//Required fields
		subject.ArrivalDate = "jduNEF";
		subject.CarrierCertificatedReleaseDate = "uDT4nF";
		subject.StandardCustomsInvoiceDate = "Dof8eX";
		//Test Parameters
		subject.ExportationDate = exportationDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jduNEF", true)]
	public void Validation_RequiredArrivalDate(string arrivalDate, bool isValidExpected)
	{
		var subject = new X3_ImportDates();
		//Required fields
		subject.ExportationDate = "qnR0yr";
		subject.CarrierCertificatedReleaseDate = "uDT4nF";
		subject.StandardCustomsInvoiceDate = "Dof8eX";
		//Test Parameters
		subject.ArrivalDate = arrivalDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uDT4nF", true)]
	public void Validation_RequiredCarrierCertificatedReleaseDate(string carrierCertificatedReleaseDate, bool isValidExpected)
	{
		var subject = new X3_ImportDates();
		//Required fields
		subject.ExportationDate = "qnR0yr";
		subject.ArrivalDate = "jduNEF";
		subject.StandardCustomsInvoiceDate = "Dof8eX";
		//Test Parameters
		subject.CarrierCertificatedReleaseDate = carrierCertificatedReleaseDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dof8eX", true)]
	public void Validation_RequiredStandardCustomsInvoiceDate(string standardCustomsInvoiceDate, bool isValidExpected)
	{
		var subject = new X3_ImportDates();
		//Required fields
		subject.ExportationDate = "qnR0yr";
		subject.ArrivalDate = "jduNEF";
		subject.CarrierCertificatedReleaseDate = "uDT4nF";
		//Test Parameters
		subject.StandardCustomsInvoiceDate = standardCustomsInvoiceDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
