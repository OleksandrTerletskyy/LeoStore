using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Store.Data.Repositories.Abstract;
using Store.Entities.Concrete;

namespace Store.Infrastructure.Core
{
	public class ApiControllerBase : ApiController
	{
		protected readonly IEntityBaseRepository<Error> _errorsRepository;

		protected ApiControllerBase(IEntityBaseRepository<Error> errorsRepository)
		{
			_errorsRepository = errorsRepository;
		}

		protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
		{
			HttpResponseMessage response = null;

			try
			{
				response = function.Invoke();
			}
			catch (DbUpdateException ex)
			{
				LogError(ex);
				response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
			}
			catch (Exception ex)
			{
				LogError(ex);
				response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return response;
		}

		private void LogError(Exception ex)
		{
			try
			{
				Error error = new Error()
				{
					Message = ex.Message,
					StackTrace = ex.StackTrace,
					DateOccured = DateTime.Now
				};

				_errorsRepository.Add(error);
			}
			catch { }
		}
	}
}