using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.User.Command
{
    internal class UpdateUserDetailsCommandHandler (ILogger<UpdateUserDetailsCommandHandler> logger,
        IUserContext userContext,IUserStore<Domain.Entities.User> userStore)     
        : IRequestHandler<UpdateUserDetailsCommand>
    {
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            logger.LogInformation("Updating User: With UserID{UserId}", user);
            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);
            if (dbUser == null)
            {
                throw new NotFiniteNumberException(nameof(User));
            }

            dbUser.Nationaltity=request.Nationaltity;
            dbUser.DOB= request.DOB;
            await userStore.UpdateAsync(dbUser, cancellationToken);


        }
    }
}
