// IPersonViewService.cs
//
// © 2021

using Business.JointObjectView;

namespace Business.Services.Abstraction;

public interface IPersonViewService
{
    public Task<CreatePersonView> GetPersonViewDetails(
        string firstName,
        string lastName,
        CancellationToken cancellationToken
    );

    public Task<IEnumerable<CreatePersonView>> GetPersonsView(
        int take,
        int skip,
        CancellationToken cancellationToken
    );

    public Task<IEnumerable<CreatePersonView>> GetFriendPersonsView(
        int take,
        int skip,
        CancellationToken cancellationToken
    );
}
