using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Services
{
	/// <summary>
	/// Сообщение с проблемой
	/// </summary>
	public class ProblemDetailsResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public ProblemDetailsResponse()
			=> Extensions = new Dictionary<string, object>();

		/// <summary>
		/// ИД исключения для корреляции
		/// </summary>
		public string? ErrorId { get; set; }

		/// <summary>
		///     A URI reference [RFC3986] that identifies the problem type. This specification
		///      encourages that, when dereferenced, it provide human-readable documentation for
		///      the problem type (e.g., using HTML [W3C.REC-html5-20141028]). When this member
		///      is not present, its value is assumed to be "about:blank".
		/// </summary>
		public string? Type { get; set; }

		/// <summary>
		/// A short, human-readable summary of the problem type.It SHOULD NOT change from
		///     occurrence to occurrence of the problem, except for purposes of localization(e.g.,
		///     using proactive content negotiation; see[RFC7231], Section 3.4).
		/// </summary>
		public string? Title { get; set; }

		/// <summary>
		/// The HTTP status code([RFC7231], Section 6) generated by the origin server for
		///     this occurrence of the problem.
		/// </summary>
		public int? Status { get; set; }

		/// <summary>
		/// A human-readable explanation specific to this occurrence of the problem.
		/// </summary>
		public string? Detail { get; set; }

		/// <summary>
		/// A URI reference that identifies the specific occurrence of the problem.It may
		///     or may not yield further information if dereferenced.
		/// </summary>
		public string? Instance { get; set; }

		/// <summary>
		///     Gets the System.Collections.Generic.IDictionary`2 for extension members.
		///     Problem type definitions MAY extend the problem details object with additional
		///     members. Extension members appear in the same namespace as other members of a
		///     problem type.
		/// </summary>
		public IDictionary<string, object> Extensions { get; }
	}
}
