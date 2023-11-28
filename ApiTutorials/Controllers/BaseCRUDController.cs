using ApiTutorials.DataContext;
using ApiTutorials.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTutorials.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseCRUDController<TCreationModel, TUpdateModel, TResult, TModel> : ControllerBase where TModel : BaseEntity where TUpdateModel : Auditable
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BaseCRUDController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async ValueTask<ActionResult<int>> PostAsync(TCreationModel viewModel)
        {
            TModel model = _mapper.Map<TModel>(viewModel);

            await _context.Set<TModel>().AddAsync(model);
            int result = await _context.SaveChangesAsync();

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<ActionResult<IEnumerable<TResult>>> GetAllAsync()
        {
            IEnumerable<TModel> list = await _context.Set<TModel>().ToListAsync();

            IEnumerable<TResult> resultList = _mapper.Map<IEnumerable<TResult>>(list);

            return Ok(resultList);
        }

        [HttpDelete]
        public async ValueTask<ActionResult<int>> DeleteAsync(int Id)
        {
            TModel? model = await _context.Set<TModel>().FindAsync(Id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Set<TModel>().Remove(model);
            int result = await _context.SaveChangesAsync();

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<ActionResult<TResult>> GetByIdAsync(int Id)
        {
            TModel? model = await _context.Set<TModel>().FindAsync(Id);

            if (model == null)
            {
                return NotFound();
            }

            TResult resultModel = _mapper.Map<TResult>(model);

            return Ok(resultModel);
        }

        [HttpPut]
        public async ValueTask<ActionResult<int>> UpdateAsync(TUpdateModel updateModel)
        {
            TModel model = _mapper.Map<TModel>(updateModel);

            TModel? resultModel = await _context.Set<TModel>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == updateModel.Id);

            if (updateModel.Id != model.Id)
            {
                return BadRequest();
            }

            model.ModifiedDate = DateTime.Now;
            model.CreatedDate = resultModel!.CreatedDate;

            _context.Set<TModel>().Update(model);
            int result = await _context.SaveChangesAsync();

            return Ok(result);
        }
    }
}
