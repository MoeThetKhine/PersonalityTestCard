using DotNet8.PersonalityTestCard.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.PersonalityTestCard.Models
{
	public class Result<T>
	{
		public T Data { get; set; }
		public string Message { get; set; }
		public bool IsSuccess { get; set; }
		public EnumStatusCode StatusCode { get; set; }

		public static Result<T> Success(string message = "Success.",EnumStatusCode statusCode = EnumStatusCode.Success) =>
		new()
		{
			Message = message,
			StatusCode = statusCode,
			IsSuccess = true
		};

		public static Result<T> Success(T data,string message = "Success.",EnumStatusCode statusCode = EnumStatusCode.Success) =>
	   new()
	   {
		   Data = data,
		   Message = message,
		   StatusCode = statusCode,
		   IsSuccess = true
	   };

		public static Result<T> SaveSuccess(string message = "Saving Successful.",EnumStatusCode statusCode = EnumStatusCode.Success)
			=> Result<T>.Success(message, statusCode);

		public static Result<T> UpdateSuccess(string message = "Updating Successful.",EnumStatusCode statusCode = EnumStatusCode.Success) 
			=> Result<T>.Success(message, statusCode);

		public static Result<T> DeleteSuccess(string message = "Deleting Successful.",EnumStatusCode statusCode = EnumStatusCode.Success) 
			=> Result<T>.Success(message, statusCode);

	}
}
