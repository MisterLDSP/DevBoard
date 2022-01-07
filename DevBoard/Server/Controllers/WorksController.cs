using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBoard.Shared;
using Microsoft.EntityFrameworkCore;

namespace DevBoard.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksController : Controller
    {
        private DbModel _dbModel;

        public WorksController(DbModel dbModel)
        {
            _dbModel = dbModel;  
        }

        /// <summary>
        /// Взять работу по идентификатору.
        /// </summary>
        /// <param name="workId">Идентификатор работы.</param>
        /// <returns>Работа.</returns>
        [HttpGet("{workId:int}")]
        public async Task<Work> Get(int workId)
        {
            return await _dbModel.Works
                                    .Where(x => x.Id == workId)      
                                    .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Получить коллекцию всех работ с подгруженными родительскими работами.
        /// </summary>
        /// <returns>Коллекция всех работ.</returns>
        [HttpGet]
        public async Task<IEnumerable<Work>> Get()
        {
            var result = await _dbModel.Works
                                    .Select(x => x)
                                    .ToListAsync();
            // Если пусто, возвращаем пустой список работ.
            if(result == null)
            {
                return new List<Work>();
            }
            return result; // Возвращаем полученный список.
        }

        /// <summary>
        /// Добавить новую работу в базу данных.
        /// </summary>
        /// <param name="work">Работа которую нужно добавить.</param>
        /// <returns>Идентификатор новой работы.</returns>
        [HttpPost]
        public async Task<int> Post(Work work)
        {
            await _dbModel.Works.AddAsync(work);
            await _dbModel.SaveChangesAsync();
            return work.Id;
        }

        /// <summary>
        /// Обновить существующую работу.
        /// </summary>
        /// <param name="work">Новая версия работы.</param>
        /// <returns>Идентификатор работы.</returns>
        [HttpPut]
        public async Task<int> Put(Work work)
        {
            _dbModel.Entry(work).State = EntityState.Modified;
            await _dbModel.SaveChangesAsync();
            return work.Id;
        }

        /// <summary>
        /// Удалить работу по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор работы которую нужно удалить.</param>
        /// <returns>Идентификатор удаленной работы.</returns>
        [HttpDelete]
        public async Task<int> Delete(int id)
        {
            var deletedWork = _dbModel.Works.Where(x => x.Id == id).FirstOrDefault();
            _dbModel.Remove(deletedWork);
            await _dbModel.SaveChangesAsync();
            return id;
        }
    }
}
