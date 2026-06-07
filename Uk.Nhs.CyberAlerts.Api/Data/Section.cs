using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data;

	/// <summary>
	/// Represents a rendered content section from an alert.
	/// </summary>
	[DataContract]
	public class Section
	{
		/// <summary>
		/// Gets or sets the section type.
		/// </summary>
		[DataMember(Name = "sectionType")]
		public string SectionType { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the section content type.
		/// </summary>
		[DataMember(Name = "type")]
		public string Type { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the section title.
		/// </summary>
		[DataMember(Name = "title")]
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets a value indicating whether the section is a numbered list.
		/// </summary>
		[DataMember(Name = "isNumberedList")]
		public bool IsNumberedList { get; set; }

		/// <summary>
		/// Gets or sets the heading level.
		/// </summary>
		[DataMember(Name = "headingLevel")]
		public string HeadingLevel { get; set; } = string.Empty;

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
		/// Gets or sets the rendered HTML content.
		/// </summary>
		[DataMember(Name = "html")]
		public string Html { get; set; } = string.Empty;
	}
