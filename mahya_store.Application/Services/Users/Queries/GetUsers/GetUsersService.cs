using mahya_store.Application.Interfaces.Contexts;
using mahya_store.Common;

namespace mahya_store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUsersDto Execute(RequestGetUsersDto request)
        {
            var users = _context.Users.AsQueryable();
            if(!string.IsNullOrEmpty(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) || p.Email.Contains(request.SearchKey));
            }
            int rowsCount = 0;
            var usersList=  users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
                IsActive = p.IsActive,
            }).ToList();
            return new ResultGetUsersDto
            {
                Users = usersList,
                Rows = rowsCount,
            };
        }
    }
}
