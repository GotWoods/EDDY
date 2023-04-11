using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("DMI")]
public class DMI_DataMaintenanceInformation : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string DataMaintenanceNumber { get; set; }

	[Position(03)]
	public string Name { get; set; }

	[Position(04)]
	public string AddressInformation { get; set; }

	[Position(05)]
	public string AddressInformation2 { get; set; }

	[Position(06)]
	public string CityName { get; set; }

	[Position(07)]
	public string StateOrProvinceCode { get; set; }

	[Position(08)]
	public string PostalCode { get; set; }

	[Position(09)]
	public string CountryCode { get; set; }

	[Position(10)]
	public string CommunicationNumberQualifier { get; set; }

	[Position(11)]
	public string CommunicationNumber { get; set; }

	[Position(12)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DMI_DataMaintenanceInformation>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.DataMaintenanceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CommunicationNumberQualifier, x=>x.CommunicationNumber);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.DataMaintenanceNumber, 1, 6);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.AddressInformation, 1, 55);
		validator.Length(x => x.AddressInformation2, 1, 55);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.PostalCode, 3, 15);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.CommunicationNumberQualifier, 2);
		validator.Length(x => x.CommunicationNumber, 1, 2048);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
