using ApiTutorials.DataContext;
using ApiTutorials.DTOs;
using ApiTutorials.Entities.Users;
using AutoMapper;

namespace ApiTutorials.Controllers.UsesrControllers
{
    public class UserController : BaseCRUDController<UserCreateDto, UserUpdateDto, UserResultDto, User>
    {
        public UserController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
