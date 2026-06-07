using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data;

	/// <summary>
	/// Represents a CVE identifier attached to an alert.
	/// </summary>
	[DataContract]
	public class CveIdentifier
	{
		/// <summary>
		/// Gets or sets the CVE identifier value.
		/// </summary>
		[DataMember(Name = "cveIdentifier")]
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the status of the CVE entry.
		/// </summary>
		[DataMember(Name = "cveStatus")]
		public string CveStatus { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets a value indicating whether the backing CMS node is a leaf node.
		/// </summary>
		[DataMember(Name = "leaf")]
		public bool Leaf { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the item is a Hippo document bean.
		/// </summary>
		[DataMember(Name = "hippoDocumentBean")]
		public bool HippoDocumentBean { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the item is a Hippo folder bean.
		/// </summary>
		[DataMember(Name = "hippoFolderBean")]
		public bool HippoFolderBean { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the backing CMS node is versioned.
		/// </summary>
		[DataMember(Name = "versionedNode")]
		public bool VersionedNode { get; set; }

		/// <summary>
		/// Gets or sets the descriptive text for the CVE entry.
		/// </summary>
		[DataMember(Name = "cveText")]
		public string CveText { get; set; } = string.Empty;
	}
