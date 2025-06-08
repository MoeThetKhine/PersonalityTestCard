namespace DotNet8.PersonalityTestCard.Api.Features.UserCard.Command.CreateUserCard
{
	public class CreateUserCardCommand : IRequest<int>
	{
		public int UserId { get; set; }
		public List<int> CardIds { get; set; }
	}
}
