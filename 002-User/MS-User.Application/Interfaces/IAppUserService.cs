using MS_User.Application.Dto;

namespace MS_User.Application.Interfaces
{
    public interface IAppUserService
    {
        PositionDTO GetPosition(int userId);
    }
}