using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data;

	/// <summary>
	/// Represents a remediation step for an alert.
	/// </summary>
	[DataContract]
	public class RemediationStep
	{
		/// <summary>
		/// Gets or sets the remediation step type.
		/// </summary>
		[DataMember(Name = "type")]
		public string Type { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets a related remediation link.
		/// </summary>
		[DataMember(Name = "link")]
		public string Link { get; set; } = string.Empty;

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
		/// Gets or sets the remediation instruction.
		/// </summary>
		[DataMember(Name = "step")]
		public string Step { get; set; } = string.Empty;
	}
