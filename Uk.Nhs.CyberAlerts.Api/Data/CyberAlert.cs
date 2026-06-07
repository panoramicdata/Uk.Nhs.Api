using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data;

	/// <summary>
	/// Represents a cyber alert returned by the NHS Cyber Alerts API.
	/// </summary>
	[DataContract]
	public class CyberAlert
	{
		/// <summary>
		/// Gets or sets the alert threat identifier.
		/// </summary>
		[DataMember(Name = "threatId")]
		public string ThreatId { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the published date as a Unix timestamp.
		/// </summary>
		[DataMember(Name = "publishedDate")]
		public long PublishedDate { get; set; }

		/// <summary>
		/// Gets or sets the sources used for threat updates.
		/// </summary>
		[DataMember(Name = "sourceOfThreatUpdates")]
		public IList<string> SourceOfThreatUpdates { get; set; } = [];

		/// <summary>
		/// Gets or sets acknowledgement entries associated with the alert.
		/// </summary>
		[DataMember(Name = "cyberAcknowledgements")]
		public IList<object> CyberAcknowledgements { get; set; } = [];

		/// <summary>
		/// Gets or sets the threat type.
		/// </summary>
		[DataMember(Name = "threatType")]
		public string ThreatType { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the threat vector entries.
		/// </summary>
		[DataMember(Name = "threatvector")]
		public IList<object> Threatvector { get; set; } = [];

		/// <summary>
		/// Gets or sets the affected platforms and versions.
		/// </summary>
		[DataMember(Name = "threatAffects")]
		public IList<ThreatAffect> ThreatAffects { get; set; } = [];

		/// <summary>
		/// Gets or sets the taxonomy values associated with the alert.
		/// </summary>
		[DataMember(Name = "fullTaxonomyList")]
		public IList<object> FullTaxonomyList { get; set; } = [];

		/// <summary>
		/// Gets or sets the main content sections of the alert.
		/// </summary>
		[DataMember(Name = "sections")]
		public IList<Section> Sections { get; set; } = [];

		/// <summary>
		/// Gets or sets the SEO summary payload.
		/// </summary>
		[DataMember(Name = "seosummaryJson")]
		public string SeosummaryJson { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the short summary text.
		/// </summary>
		[DataMember(Name = "shortsummary")]
		public string Shortsummary { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the alert severity.
		/// </summary>
		[DataMember(Name = "severity")]
		public string Severity { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the alert categories.
		/// </summary>
		[DataMember(Name = "category")]
		public IList<string> Category { get; set; } = [];

		/// <summary>
		/// Gets or sets the base content path for the alert.
		/// </summary>
		[DataMember(Name = "basePath")]
		public string BasePath { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets threat update entries.
		/// </summary>
		[DataMember(Name = "threatUpdates")]
		public IList<object> ThreatUpdates { get; set; } = [];

		/// <summary>
		/// Gets or sets the remediation steps.
		/// </summary>
		[DataMember(Name = "remediationSteps")]
		public IList<RemediationStep> RemediationSteps { get; set; } = [];

		/// <summary>
		/// Gets or sets the indicators of compromise.
		/// </summary>
		[DataMember(Name = "indicatorsCompromise")]
		public IList<IndicatorsCompromise> IndicatorsCompromise { get; set; } = [];

		/// <summary>
		/// Gets or sets the related NCSC link.
		/// </summary>
		[DataMember(Name = "ncscLink")]
		public string NcscLink { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the CVE identifiers referenced by the alert.
		/// </summary>
		[DataMember(Name = "cveIdentifiers")]
		public IList<CveIdentifier> CveIdentifiers { get; set; } = [];

		/// <summary>
		/// Gets or sets the alert title.
		/// </summary>
		[DataMember(Name = "title")]
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets a value indicating whether the backing CMS node is versioned.
		/// </summary>
		[DataMember(Name = "versionedNode")]
		public bool VersionedNode { get; set; }

		/// <summary>
		/// Gets or sets the remediation introduction text.
		/// </summary>
		[DataMember(Name = "remediationIntro")]
		public string RemediationIntro { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the full summary text.
		/// </summary>
		[DataMember(Name = "summary")]
		public string Summary { get; set; } = string.Empty;
	}
