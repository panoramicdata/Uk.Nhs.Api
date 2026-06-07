using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data;

	/// <summary>
	/// Represents an indicator of compromise section from an alert.
	/// </summary>
	[DataContract]
	public class IndicatorsCompromise
	{
		/// <summary>
		/// Gets or sets the section type.
		/// </summary>
		[DataMember(Name = "sectionType")]
		public string SectionType { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the section heading.
		/// </summary>
		[DataMember(Name = "heading")]
		public string Heading { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the intended audience.
		/// </summary>
		[DataMember(Name = "audience")]
		public string Audience { get; set; } = string.Empty;

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
		/// Gets or sets the content body.
		/// </summary>
		[DataMember(Name = "content")]
		public string Content { get; set; } = string.Empty;
	}
