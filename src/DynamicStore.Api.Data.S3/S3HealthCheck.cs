using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DynamicStore.Api.Data.S3
{
	/// <summary>
	/// Проверка работоспособности S3-хранилища
	/// </summary>
	public class S3HealthCheck : IHealthCheck
	{
		private readonly IS3Service _awsS3Service;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="awsS3Service">Сервис S3</param>
		public S3HealthCheck(IS3Service awsS3Service)
			=> _awsS3Service = awsS3Service;

		/// <inheritdoc/>
		public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			try
			{
				var buckets = await _awsS3Service.GetBucketsAsync(cancellationToken);
				var bucketsText = buckets == null ? string.Empty : string.Join(", ", buckets);

				return buckets?.Any() == true
					? HealthCheckResult.Healthy(
						$"S3-storage has buckets available: {bucketsText}",
						new Dictionary<string, object> { ["Buckets"] = bucketsText })
					: HealthCheckResult.Unhealthy("S3-storage has no any bucket available");
			}
			catch (Exception ex)
			{
				return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
			}
		}
	}
}
