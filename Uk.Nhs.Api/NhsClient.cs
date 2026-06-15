using Refit;
using System;
using System.Net.Http;
using Uk.Nhs.Api.Interfaces;

namespace Uk.Nhs.Api;

public class NhsClient : IDisposable
{
	private bool disposedValue;
	private readonly HttpClient _cyberAlertsHttpClient;
	private readonly HttpClient _addressQualityHttpClient;
	private readonly HttpClient _accessControlHttpClient;
	private readonly HttpClient _alertsHl7V3HttpClient;
	private readonly HttpClient _urgentAndEmergencyCareContinuousQualityImprovementApiHttpClient;
	private readonly HttpClient _vaccinationEventsFhirHttpClient;
	private readonly HttpClient _ambulanceDataSubmissionFhirHttpClient;
	private readonly HttpClient _ambulanceMessagingHl7V3HttpClient;
	private readonly HttpClient _assessmentDischargeAndWithdrawalFhirHttpClient;
	private readonly HttpClient _bookingAndReferralFhirHttpClient;
	private readonly HttpClient _bowelCancerScreeningEdifactHttpClient;
	private readonly HttpClient _careConnectFhirStandardsHttpClient;
	private readonly HttpClient _cervicalScreeningEdifactHttpClient;
	private readonly HttpClient _childProtectionInformationSharingHl7V3HttpClient;
	private readonly HttpClient _childProtectionInformationSharingMeshHttpClient;
	private readonly HttpClient _childProtectionInformationSharingSmspStandardsHttpClient;
	private readonly HttpClient _childScreeningHttpClient;
	private readonly HttpClient _cis1AuthenticationSpineSecurityBrokerHttpClient;
	private readonly HttpClient _cis2AuthenticationHttpClient;
	private readonly HttpClient _clinicalDecisionSupportStandardsHttpClient;
	private readonly HttpClient _dataRegistersServiceRestHttpClient;
	private readonly HttpClient _demographicsBatchServiceHttpClient;
	private readonly HttpClient _digitalChildHealthFhirHttpClient;
	private readonly HttpClient _digitalMaternityStandardsHttpClient;
	private readonly HttpClient _digitalMedicineFhirHttpClient;
	private readonly HttpClient _digitalSignatureServiceHttpClient;
	private readonly HttpClient _digitalStaffPassportApiHttpClient;
	private readonly HttpClient _digitalStaffPassportApiStandardHttpClient;
	private readonly HttpClient _dwaMiddleServiceApiHttpClient;
	private readonly HttpClient _electiveWaitingListHttpClient;
	private readonly HttpClient _electronicPrescribingAndMedicinesAdministrationStandardsHttpClient;
	private readonly HttpClient _electronicPrescriptionServiceDirectoryOfServicesHttpClient;
	private readonly HttpClient _electronicPrescriptionServiceHl7V3HttpClient;
	private readonly HttpClient _electronicTransmissionOfPrescriptionsWebServicesRestHttpClient;
	private readonly HttpClient _eReferralServiceFhirHttpClient;
	private readonly HttpClient _eReferralServiceFhirHscnHttpClient;
	private readonly HttpClient _eReferralServiceHl7V3HttpClient;
	private readonly HttpClient _eReferralServicePatientCareFhirHttpClient;
	private readonly HttpClient _femaleGenitalMutilationInformationSharingFhirHttpClient;
	private readonly HttpClient _femaleGenitalMutilationInformationSharingSmspStandardsHttpClient;
	private readonly HttpClient _fhirConverterHttpClient;
	private readonly HttpClient _fhirUkCoreStandardsHttpClient;
	private readonly HttpClient _fhirVitalSignsStandardsHttpClient;
	private readonly HttpClient _gazetteerServiceSoapHttpClient;

	public NhsClient(NhsClientOptions options)
	{
		// Create an HttpClientMessageHandler that can be used to add logging or other functionality
		var loggingHttpClientMessageHandler = new LoggingHandler(options.Logger);

		_cyberAlertsHttpClient = new HttpClient(loggingHttpClientMessageHandler)
		{
			BaseAddress = new Uri("https://digital.nhs.uk/restapi/CyberAlert")
		};

		CyberAlerts = RestService.For<ICyberAlerts>(_cyberAlertsHttpClient);

		_addressQualityHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		AddressQualityService = RestService.For<IAddressQualityService>(_addressQualityHttpClient);

		_accessControlHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		AccessControlService = RestService.For<IAccessControlService>(_accessControlHttpClient);

		_alertsHl7V3HttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		AlertsHl7V3 = RestService.For<IAlertsHl7V3>(_alertsHl7V3HttpClient);

		_urgentAndEmergencyCareContinuousQualityImprovementApiHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		UrgentAndEmergencyCareContinuousQualityImprovementApi = RestService.For<IUrgentAndEmergencyCareContinuousQualityImprovementApi>(_urgentAndEmergencyCareContinuousQualityImprovementApiHttpClient);

		_vaccinationEventsFhirHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		VaccinationEventsFhir = RestService.For<IVaccinationEventsFhir>(_vaccinationEventsFhirHttpClient);

		_ambulanceDataSubmissionFhirHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		AmbulanceDataSubmissionFhir = RestService.For<IAmbulanceDataSubmissionFhir>(_ambulanceDataSubmissionFhirHttpClient);

		_ambulanceMessagingHl7V3HttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		AmbulanceMessagingHl7V3 = RestService.For<IAmbulanceMessagingHl7V3>(_ambulanceMessagingHl7V3HttpClient);

		_assessmentDischargeAndWithdrawalFhirHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		AssessmentDischargeAndWithdrawalFhir = RestService.For<IAssessmentDischargeAndWithdrawalFhir>(_assessmentDischargeAndWithdrawalFhirHttpClient);

		_bookingAndReferralFhirHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		BookingAndReferralFhir = RestService.For<IBookingAndReferralFhir>(_bookingAndReferralFhirHttpClient);

		_bowelCancerScreeningEdifactHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		BowelCancerScreeningEdifact = RestService.For<IBowelCancerScreeningEdifact>(_bowelCancerScreeningEdifactHttpClient);

		_careConnectFhirStandardsHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		CareConnectFhirStandards = RestService.For<ICareConnectFhirStandards>(_careConnectFhirStandardsHttpClient);

		_cervicalScreeningEdifactHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		CervicalScreeningEdifact = RestService.For<ICervicalScreeningEdifact>(_cervicalScreeningEdifactHttpClient);

		_childProtectionInformationSharingHl7V3HttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ChildProtectionInformationSharingHl7V3 = RestService.For<IChildProtectionInformationSharingHl7V3>(_childProtectionInformationSharingHl7V3HttpClient);

		_childProtectionInformationSharingMeshHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ChildProtectionInformationSharingMesh = RestService.For<IChildProtectionInformationSharingMesh>(_childProtectionInformationSharingMeshHttpClient);

		_childProtectionInformationSharingSmspStandardsHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ChildProtectionInformationSharingSmspStandards = RestService.For<IChildProtectionInformationSharingSmspStandards>(_childProtectionInformationSharingSmspStandardsHttpClient);

		_childScreeningHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ChildScreening = RestService.For<IChildScreening>(_childScreeningHttpClient);

		_cis1AuthenticationSpineSecurityBrokerHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		Cis1AuthenticationSpineSecurityBroker = RestService.For<ICis1AuthenticationSpineSecurityBroker>(_cis1AuthenticationSpineSecurityBrokerHttpClient);

		_cis2AuthenticationHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		Cis2Authentication = RestService.For<ICis2Authentication>(_cis2AuthenticationHttpClient);

		_clinicalDecisionSupportStandardsHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ClinicalDecisionSupportStandards = RestService.For<IClinicalDecisionSupportStandards>(_clinicalDecisionSupportStandardsHttpClient);

		_dataRegistersServiceRestHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		DataRegistersServiceRest = RestService.For<IDataRegistersServiceRest>(_dataRegistersServiceRestHttpClient);

		_demographicsBatchServiceHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		DemographicsBatchService = RestService.For<IDemographicsBatchService>(_demographicsBatchServiceHttpClient);

		_digitalChildHealthFhirHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		DigitalChildHealthFhir = RestService.For<IDigitalChildHealthFhir>(_digitalChildHealthFhirHttpClient);

		_digitalMaternityStandardsHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		DigitalMaternityStandards = RestService.For<IDigitalMaternityStandards>(_digitalMaternityStandardsHttpClient);

		_digitalMedicineFhirHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		DigitalMedicineFhir = RestService.For<IDigitalMedicineFhir>(_digitalMedicineFhirHttpClient);

		_digitalSignatureServiceHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		DigitalSignatureService = RestService.For<IDigitalSignatureService>(_digitalSignatureServiceHttpClient);

		_digitalStaffPassportApiHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		DigitalStaffPassportApi = RestService.For<IDigitalStaffPassportApi>(_digitalStaffPassportApiHttpClient);

		_digitalStaffPassportApiStandardHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		DigitalStaffPassportApiStandard = RestService.For<IDigitalStaffPassportApiStandard>(_digitalStaffPassportApiStandardHttpClient);

		_dwaMiddleServiceApiHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		DwaMiddleServiceApi = RestService.For<IDwaMiddleServiceApi>(_dwaMiddleServiceApiHttpClient);

		_electiveWaitingListHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ElectiveWaitingList = RestService.For<IElectiveWaitingList>(_electiveWaitingListHttpClient);

		_electronicPrescribingAndMedicinesAdministrationStandardsHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ElectronicPrescribingAndMedicinesAdministrationStandards = RestService.For<IElectronicPrescribingAndMedicinesAdministrationStandards>(_electronicPrescribingAndMedicinesAdministrationStandardsHttpClient);

		_electronicPrescriptionServiceDirectoryOfServicesHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ElectronicPrescriptionServiceDirectoryOfServices = RestService.For<IElectronicPrescriptionServiceDirectoryOfServices>(_electronicPrescriptionServiceDirectoryOfServicesHttpClient);

		_electronicPrescriptionServiceHl7V3HttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ElectronicPrescriptionServiceHl7V3 = RestService.For<IElectronicPrescriptionServiceHl7V3>(_electronicPrescriptionServiceHl7V3HttpClient);

		_electronicTransmissionOfPrescriptionsWebServicesRestHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		ElectronicTransmissionOfPrescriptionsWebServicesRest = RestService.For<IElectronicTransmissionOfPrescriptionsWebServicesRest>(_electronicTransmissionOfPrescriptionsWebServicesRestHttpClient);

		_eReferralServiceFhirHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		EReferralServiceFhir = RestService.For<IEReferralServiceFhir>(_eReferralServiceFhirHttpClient);

		_eReferralServiceFhirHscnHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		EReferralServiceFhirHscn = RestService.For<IEReferralServiceFhirHscn>(_eReferralServiceFhirHscnHttpClient);

		_eReferralServiceHl7V3HttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		EReferralServiceHl7V3 = RestService.For<IEReferralServiceHl7V3>(_eReferralServiceHl7V3HttpClient);

		_eReferralServicePatientCareFhirHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		EReferralServicePatientCareFhir = RestService.For<IEReferralServicePatientCareFhir>(_eReferralServicePatientCareFhirHttpClient);

		_femaleGenitalMutilationInformationSharingFhirHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		FemaleGenitalMutilationInformationSharingFhir = RestService.For<IFemaleGenitalMutilationInformationSharingFhir>(_femaleGenitalMutilationInformationSharingFhirHttpClient);

		_femaleGenitalMutilationInformationSharingSmspStandardsHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		FemaleGenitalMutilationInformationSharingSmspStandards = RestService.For<IFemaleGenitalMutilationInformationSharingSmspStandards>(_femaleGenitalMutilationInformationSharingSmspStandardsHttpClient);

		_fhirConverterHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		FhirConverter = RestService.For<IFhirConverter>(_fhirConverterHttpClient);

		_fhirUkCoreStandardsHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		FhirUkCoreStandards = RestService.For<IFhirUkCoreStandards>(_fhirUkCoreStandardsHttpClient);

		_fhirVitalSignsStandardsHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		FhirVitalSignsStandards = RestService.For<IFhirVitalSignsStandards>(_fhirVitalSignsStandardsHttpClient);

		_gazetteerServiceSoapHttpClient = new HttpClient
		{
			BaseAddress = new Uri("https://placeholder")
		};

		GazetteerServiceSoap = RestService.For<IGazetteerServiceSoap>(_gazetteerServiceSoapHttpClient);
	}

	public ICyberAlerts CyberAlerts { get; }
	public IAccessControlService AccessControlService { get; }
	public IAddressQualityService AddressQualityService { get; }
	public IAlertsHl7V3 AlertsHl7V3 { get; }
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
	public IUrgentAndEmergencyCareContinuousQualityImprovementApi UrgentAndEmergencyCareContinuousQualityImprovementApi { get; }
	public IVaccinationEventsFhir VaccinationEventsFhir { get; }

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				_cyberAlertsHttpClient.Dispose();
				_addressQualityHttpClient.Dispose();
				_accessControlHttpClient.Dispose();
				_alertsHl7V3HttpClient.Dispose();
				_urgentAndEmergencyCareContinuousQualityImprovementApiHttpClient.Dispose();
				_vaccinationEventsFhirHttpClient.Dispose();
				_ambulanceDataSubmissionFhirHttpClient.Dispose();
				_ambulanceMessagingHl7V3HttpClient.Dispose();
				_assessmentDischargeAndWithdrawalFhirHttpClient.Dispose();
				_bookingAndReferralFhirHttpClient.Dispose();
				_bowelCancerScreeningEdifactHttpClient.Dispose();
				_careConnectFhirStandardsHttpClient.Dispose();
				_cervicalScreeningEdifactHttpClient.Dispose();
				_childProtectionInformationSharingHl7V3HttpClient.Dispose();
				_childProtectionInformationSharingMeshHttpClient.Dispose();
				_childProtectionInformationSharingSmspStandardsHttpClient.Dispose();
				_childScreeningHttpClient.Dispose();
				_cis1AuthenticationSpineSecurityBrokerHttpClient.Dispose();
				_cis2AuthenticationHttpClient.Dispose();
				_clinicalDecisionSupportStandardsHttpClient.Dispose();
				_dataRegistersServiceRestHttpClient.Dispose();
				_demographicsBatchServiceHttpClient.Dispose();
				_digitalChildHealthFhirHttpClient.Dispose();
				_digitalMaternityStandardsHttpClient.Dispose();
				_digitalMedicineFhirHttpClient.Dispose();
				_digitalSignatureServiceHttpClient.Dispose();
				_digitalStaffPassportApiHttpClient.Dispose();
				_digitalStaffPassportApiStandardHttpClient.Dispose();
				_dwaMiddleServiceApiHttpClient.Dispose();
				_electiveWaitingListHttpClient.Dispose();
				_electronicPrescribingAndMedicinesAdministrationStandardsHttpClient.Dispose();
				_electronicPrescriptionServiceDirectoryOfServicesHttpClient.Dispose();
				_electronicPrescriptionServiceHl7V3HttpClient.Dispose();
				_electronicTransmissionOfPrescriptionsWebServicesRestHttpClient.Dispose();
				_eReferralServiceFhirHttpClient.Dispose();
				_eReferralServiceFhirHscnHttpClient.Dispose();
				_eReferralServiceHl7V3HttpClient.Dispose();
				_eReferralServicePatientCareFhirHttpClient.Dispose();
				_femaleGenitalMutilationInformationSharingFhirHttpClient.Dispose();
				_femaleGenitalMutilationInformationSharingSmspStandardsHttpClient.Dispose();
				_fhirConverterHttpClient.Dispose();
				_fhirUkCoreStandardsHttpClient.Dispose();
				_fhirVitalSignsStandardsHttpClient.Dispose();
				_gazetteerServiceSoapHttpClient.Dispose();
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
