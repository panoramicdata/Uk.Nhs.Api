using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data;

	/// <summary>
	/// Describes a platform or version affected by an alert.
	/// </summary>
	[DataContract]
	public class ThreatAffect
	{
		/// <summary>
		/// Gets or sets the affected versions.
		/// </summary>
		[DataMember(Name = "versionsAffected")]
		public IList<string> VersionsAffected { get; set; } = [];

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
		/// Gets or sets the platform description.
		/// </summary>
		[DataMember(Name = "platformText")]
		public string PlatformText { get; set; } = string.Empty;
	}
