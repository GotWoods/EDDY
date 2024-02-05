using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3040;

public class Edi815_CryptographicServiceMessage {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public CSM_CryptographicServiceMessageHeader CryptographicServiceMessageHeader { get; set; } = new();
	[SectionPosition(3)] public List<CSB_CryptographicServiceMessageBody> CryptographicServiceMessageBody { get; set; } = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi815_CryptographicServiceMessage>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.CryptographicServiceMessageHeader);
		validator.CollectionSize(x => x.CryptographicServiceMessageBody, 1, 2147483647);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
