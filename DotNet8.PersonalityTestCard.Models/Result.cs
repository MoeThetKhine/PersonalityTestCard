namespace DotNet8.PersonalityTestCard.Models;

public class Result<T>
{
	public T Data { get; set; }
	public string Message { get; set; }
	public bool IsSuccess { get; set; }
	public EnumStatusCode StatusCode { get; set; }

	#region Success

	public static Result<T> Success(string message = "Success.",EnumStatusCode statusCode = EnumStatusCode.Success) =>
	new()
	{
		Message = message,
		StatusCode = statusCode,
		IsSuccess = true
	};

	#endregion

	#region Success

	public static Result<T> Success(T data,string message = "Success.",EnumStatusCode statusCode = EnumStatusCode.Success) =>
   new()
   {
	   Data = data,
	   Message = message,
	   StatusCode = statusCode,
	   IsSuccess = true
   };

	#endregion

	#region SaveSuccess

	public static Result<T> SaveSuccess(string message = "Saving Successful.",EnumStatusCode statusCode = EnumStatusCode.Success)
		=> Result<T>.Success(message, statusCode);

	#endregion

	#region UpdateSuccess

	public static Result<T> UpdateSuccess(string message = "Updating Successful.",EnumStatusCode statusCode = EnumStatusCode.Success) 
		=> Result<T>.Success(message, statusCode);

	#endregion

	#region DeleteSuccess

	public static Result<T> DeleteSuccess(string message = "Deleting Successful.",EnumStatusCode statusCode = EnumStatusCode.Success) 
		=> Result<T>.Success(message, statusCode);

	#endregion

	#region Failure

	public static Result<T> Failure(string message = "Fail.",EnumStatusCode statusCode = EnumStatusCode.BadRequest) =>
	new()
	{
		Message = message,
		StatusCode = statusCode,
		IsSuccess = false
	};

	#endregion

	#region Failure

	public static Result<T> Failure(Exception ex) =>
  Result<T>.Failure(ex.ToString(), EnumStatusCode.InternalServerError);

	#endregion

	#region NotFound

	public static Result<T> NotFound(string message = "No Data Found.") =>
  Result<T>.Failure(message, EnumStatusCode.NotFound);

	#endregion
}
