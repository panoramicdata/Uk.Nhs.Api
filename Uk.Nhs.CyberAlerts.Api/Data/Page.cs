using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.CyberAlerts.Api.Data;

	/// <summary>
	/// Represents a paged API response.
	/// </summary>
	/// <typeparam name="T">The item type contained in the page.</typeparam>
	[DataContract]
	public class Page<T>
	{
		/// <summary>
		/// Gets or sets the number of items returned per page.
		/// </summary>
		[DataMember(Name = "pageSize")]
		public int PageSize { get; set; }

		/// <summary>
		/// Gets or sets the total number of items available.
		/// </summary>
		[DataMember(Name = "total")]
		public int Total { get; set; }

		/// <summary>
		/// Gets or sets the items in the current page.
		/// </summary>
		[DataMember(Name = "items")]
		public IList<T> Items { get; set; } = [];

		/// <summary>
		/// Gets or sets the total number of pages available.
		/// </summary>
		[DataMember(Name = "totalPages")]
		public int TotalPages { get; set; }

		/// <summary>
		/// Gets or sets the current page number.
		/// </summary>
		[DataMember(Name = "currentPage")]
		public int CurrentPage { get; set; }
	}
