using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Uk.Nhs.Api.CyberAlerts;

[DataContract]
public class Page<T>
{
	[DataMember(Name = "pageSize")]
	public required int PageSize { get; init; }

	[DataMember(Name = "total")]
	public required int Total { get; init; }

	[DataMember(Name = "items")]
	public required IList<T> Items { get; init; }

	[DataMember(Name = "totalPages")]
	public required int TotalPages { get; init; }

	[DataMember(Name = "currentPage")]
	public required int CurrentPage { get; init; }
}