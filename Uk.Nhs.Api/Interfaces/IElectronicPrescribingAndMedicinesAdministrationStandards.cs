using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Uk.Nhs.Api.Interfaces;

public interface IElectronicPrescribingAndMedicinesAdministrationStandards
{
	/// <summary>
	/// Placeholder method for electronic-prescribing-and-medicines-administration-standards
	/// </summary>
	[Get("/placeholder")]
	Task<string?> GetDataAsync(CancellationToken cancellationToken = default);
}
