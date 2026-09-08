using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Uk.Nhs.Api.Interfaces;

namespace Uk.Nhs.Api;

public class NhsClient : IDisposable
{
	private bool disposedValue;
	private readonly List<HttpClient> _httpClients = [];

	public NhsClient(NhsClientOptions options)
	{
		// Create an HttpClientMessageHandler that can be used to add logging or other functionality
		var loggingHttpClientMessageHandler = new LoggingHandler(options.Logger);

		CyberAlerts = RestService.For<ICyberAlerts>(CreateHttpClient("https://digital.nhs.uk/restapi/CyberAlert", loggingHttpClientMessageHandler));
		AddressQualityService = RestService.For<IAddressQualityService>(CreateHttpClient("https://placeholder"));
		AccessControlService = RestService.For<IAccessControlService>(CreateHttpClient("https://placeholder"));
		AlertsHl7V3 = RestService.For<IAlertsHl7V3>(CreateHttpClient("https://placeholder"));
		UrgentAndEmergencyCareContinuousQualityImprovementApi = RestService.For<IUrgentAndEmergencyCareContinuousQualityImprovementApi>(CreateHttpClient("https://placeholder"));
		VaccinationEventsFhir = RestService.For<IVaccinationEventsFhir>(CreateHttpClient("https://placeholder"));
		AmbulanceDataSubmissionFhir = RestService.For<IAmbulanceDataSubmissionFhir>(CreateHttpClient("https://placeholder"));
		AmbulanceMessagingHl7V3 = RestService.For<IAmbulanceMessagingHl7V3>(CreateHttpClient("https://placeholder"));
		AssessmentDischargeAndWithdrawalFhir = RestService.For<IAssessmentDischargeAndWithdrawalFhir>(CreateHttpClient("https://placeholder"));
		BookingAndReferralFhir = RestService.For<IBookingAndReferralFhir>(CreateHttpClient("https://placeholder"));
		BowelCancerScreeningEdifact = RestService.For<IBowelCancerScreeningEdifact>(CreateHttpClient("https://placeholder"));
		CareConnectFhirStandards = RestService.For<ICareConnectFhirStandards>(CreateHttpClient("https://placeholder"));
		CervicalScreeningEdifact = RestService.For<ICervicalScreeningEdifact>(CreateHttpClient("https://placeholder"));
		ChildProtectionInformationSharingHl7V3 = RestService.For<IChildProtectionInformationSharingHl7V3>(CreateHttpClient("https://placeholder"));
		ChildProtectionInformationSharingMesh = RestService.For<IChildProtectionInformationSharingMesh>(CreateHttpClient("https://placeholder"));
		ChildProtectionInformationSharingSmspStandards = RestService.For<IChildProtectionInformationSharingSmspStandards>(CreateHttpClient("https://placeholder"));
		ChildScreening = RestService.For<IChildScreening>(CreateHttpClient("https://placeholder"));
		Cis1AuthenticationSpineSecurityBroker = RestService.For<ICis1AuthenticationSpineSecurityBroker>(CreateHttpClient("https://placeholder"));
		Cis2Authentication = RestService.For<ICis2Authentication>(CreateHttpClient("https://placeholder"));
		ClinicalDecisionSupportStandards = RestService.For<IClinicalDecisionSupportStandards>(CreateHttpClient("https://placeholder"));
		DataRegistersServiceRest = RestService.For<IDataRegistersServiceRest>(CreateHttpClient("https://placeholder"));
		DemographicsBatchService = RestService.For<IDemographicsBatchService>(CreateHttpClient("https://placeholder"));
		DigitalChildHealthFhir = RestService.For<IDigitalChildHealthFhir>(CreateHttpClient("https://placeholder"));
		DigitalMaternityStandards = RestService.For<IDigitalMaternityStandards>(CreateHttpClient("https://placeholder"));
		DigitalMedicineFhir = RestService.For<IDigitalMedicineFhir>(CreateHttpClient("https://placeholder"));
		DigitalSignatureService = RestService.For<IDigitalSignatureService>(CreateHttpClient("https://placeholder"));
		DigitalStaffPassportApi = RestService.For<IDigitalStaffPassportApi>(CreateHttpClient("https://placeholder"));
		DigitalStaffPassportApiStandard = RestService.For<IDigitalStaffPassportApiStandard>(CreateHttpClient("https://placeholder"));
		DwaMiddleServiceApi = RestService.For<IDwaMiddleServiceApi>(CreateHttpClient("https://placeholder"));
		ElectiveWaitingList = RestService.For<IElectiveWaitingList>(CreateHttpClient("https://placeholder"));
		ElectronicPrescribingAndMedicinesAdministrationStandards = RestService.For<IElectronicPrescribingAndMedicinesAdministrationStandards>(CreateHttpClient("https://placeholder"));
		ElectronicPrescriptionServiceDirectoryOfServices = RestService.For<IElectronicPrescriptionServiceDirectoryOfServices>(CreateHttpClient("https://placeholder"));
		ElectronicPrescriptionServiceHl7V3 = RestService.For<IElectronicPrescriptionServiceHl7V3>(CreateHttpClient("https://placeholder"));
		ElectronicTransmissionOfPrescriptionsWebServicesRest = RestService.For<IElectronicTransmissionOfPrescriptionsWebServicesRest>(CreateHttpClient("https://placeholder"));
		EReferralServiceFhir = RestService.For<IEReferralServiceFhir>(CreateHttpClient("https://placeholder"));
		EReferralServiceFhirHscn = RestService.For<IEReferralServiceFhirHscn>(CreateHttpClient("https://placeholder"));
		EReferralServiceHl7V3 = RestService.For<IEReferralServiceHl7V3>(CreateHttpClient("https://placeholder"));
		EReferralServicePatientCareFhir = RestService.For<IEReferralServicePatientCareFhir>(CreateHttpClient("https://placeholder"));
		FemaleGenitalMutilationInformationSharingFhir = RestService.For<IFemaleGenitalMutilationInformationSharingFhir>(CreateHttpClient("https://placeholder"));
		FemaleGenitalMutilationInformationSharingSmspStandards = RestService.For<IFemaleGenitalMutilationInformationSharingSmspStandards>(CreateHttpClient("https://placeholder"));
		FhirConverter = RestService.For<IFhirConverter>(CreateHttpClient("https://placeholder"));
		FhirUkCoreStandards = RestService.For<IFhirUkCoreStandards>(CreateHttpClient("https://placeholder"));
		FhirVitalSignsStandards = RestService.For<IFhirVitalSignsStandards>(CreateHttpClient("https://placeholder"));
		GazetteerServiceSoap = RestService.For<IGazetteerServiceSoap>(CreateHttpClient("https://placeholder"));
	}

	public ICyberAlerts CyberAlerts { get; }
	public IAddressQualityService AddressQualityService { get; }
	public IAccessControlService AccessControlService { get; }
	public IAlertsHl7V3 AlertsHl7V3 { get; }
	public IUrgentAndEmergencyCareContinuousQualityImprovementApi UrgentAndEmergencyCareContinuousQualityImprovementApi { get; }
	public IVaccinationEventsFhir VaccinationEventsFhir { get; }
	public IAmbulanceDataSubmissionFhir AmbulanceDataSubmissionFhir { get; }
	public IAmbulanceMessagingHl7V3 AmbulanceMessagingHl7V3 { get; }
	public IAssessmentDischargeAndWithdrawalFhir AssessmentDischargeAndWithdrawalFhir { get; }
	public IBookingAndReferralFhir BookingAndReferralFhir { get; }
	public IBowelCancerScreeningEdifact BowelCancerScreeningEdifact { get; }
	public ICareConnectFhirStandards CareConnectFhirStandards { get; }
	public ICervicalScreeningEdifact CervicalScreeningEdifact { get; }
	public IChildProtectionInformationSharingHl7V3 ChildProtectionInformationSharingHl7V3 { get; }
	public IChildProtectionInformationSharingMesh ChildProtectionInformationSharingMesh { get; }
	public IChildProtectionInformationSharingSmspStandards ChildProtectionInformationSharingSmspStandards { get; }
	public IChildScreening ChildScreening { get; }
	public ICis1AuthenticationSpineSecurityBroker Cis1AuthenticationSpineSecurityBroker { get; }
	public ICis2Authentication Cis2Authentication { get; }
	public IClinicalDecisionSupportStandards ClinicalDecisionSupportStandards { get; }
	public IDataRegistersServiceRest DataRegistersServiceRest { get; }
	public IDemographicsBatchService DemographicsBatchService { get; }
	public IDigitalChildHealthFhir DigitalChildHealthFhir { get; }
	public IDigitalMaternityStandards DigitalMaternityStandards { get; }
	public IDigitalMedicineFhir DigitalMedicineFhir { get; }
	public IDigitalSignatureService DigitalSignatureService { get; }
	public IDigitalStaffPassportApi DigitalStaffPassportApi { get; }
	public IDigitalStaffPassportApiStandard DigitalStaffPassportApiStandard { get; }
	public IDwaMiddleServiceApi DwaMiddleServiceApi { get; }
	public IElectiveWaitingList ElectiveWaitingList { get; }
	public IElectronicPrescribingAndMedicinesAdministrationStandards ElectronicPrescribingAndMedicinesAdministrationStandards { get; }
	public IElectronicPrescriptionServiceDirectoryOfServices ElectronicPrescriptionServiceDirectoryOfServices { get; }
	public IElectronicPrescriptionServiceHl7V3 ElectronicPrescriptionServiceHl7V3 { get; }
	public IElectronicTransmissionOfPrescriptionsWebServicesRest ElectronicTransmissionOfPrescriptionsWebServicesRest { get; }
	public IEReferralServiceFhir EReferralServiceFhir { get; }
	public IEReferralServiceFhirHscn EReferralServiceFhirHscn { get; }
	public IEReferralServiceHl7V3 EReferralServiceHl7V3 { get; }
	public IEReferralServicePatientCareFhir EReferralServicePatientCareFhir { get; }
	public IFemaleGenitalMutilationInformationSharingFhir FemaleGenitalMutilationInformationSharingFhir { get; }
	public IFemaleGenitalMutilationInformationSharingSmspStandards FemaleGenitalMutilationInformationSharingSmspStandards { get; }
	public IFhirConverter FhirConverter { get; }
	public IFhirUkCoreStandards FhirUkCoreStandards { get; }
	public IFhirVitalSignsStandards FhirVitalSignsStandards { get; }
	public IGazetteerServiceSoap GazetteerServiceSoap { get; }

	private HttpClient CreateHttpClient(string baseAddress, HttpMessageHandler? handler = null)
	{
		var httpClient = handler is null ? new HttpClient() : new HttpClient(handler);
		httpClient.BaseAddress = new Uri(baseAddress);
		_httpClients.Add(httpClient);
		return httpClient;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				foreach (var httpClient in _httpClients)
				{
					httpClient.Dispose();
				}
			}

			disposedValue = true;
		}
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
