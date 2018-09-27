﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Entities;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.Services;
using InfnetPos.Mvc.TrabalhoFinal.Domain.Model.Interfaces.UnitOfWork;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfnetPos.Mvc.TrabalhoFinal.Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCrudController<TIService, TEntity, TEntityViewModel>
        : ControllerBase
        where TEntity : BaseEntity
        where TEntityViewModel : BaseResponse
        where TIService : IBaseService<TEntity>
    {
        protected TIService BaseService { get; }
        protected IUnitOfWork Uow { get; }
        protected IMapper Mapper1 { get; }

        public BaseCrudController(TIService baseService, IUnitOfWork uow, IMapper autoMapper)
        {
            BaseService = baseService;
            Uow = uow;
            Mapper1 = autoMapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntityViewModel>>> Get()
        {
            return Mapper1
                .Map<IEnumerable<TEntityViewModel>>(
                    await BaseService.GetAllAsNoTrackingAsync())
                .ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntityViewModel>> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityViewModel = await BaseService.FindAsync(id);

            if (entityViewModel == null)
            {
                return NotFound();
            }

            return Ok(Mapper1.Map<TEntityViewModel>(entityViewModel));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<TEntityViewModel>> Post([FromBody] TEntityViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ret = BaseService.AddAsync(Mapper1.Map<TEntity>(viewModel));
            await Uow.CommitAsync();

            var retViewModel = Mapper1.Map<TEntityViewModel>(ret);

            return CreatedAtAction(nameof(Get), new {id = retViewModel.Id}, retViewModel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TEntityViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            try
            {
                Uow.BeginTransaction();
                BaseService.Update(Mapper1.Map<TEntity>(viewModel));
                Uow.Commit();
            }
            catch (DbUpdateException)
            {
                if ((await BaseService.FindAsync(id)) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityViewModel = await BaseService.FindAsync(id);
            if (entityViewModel == null)
            {
                return NotFound();
            }

            Uow.BeginTransaction();
            var entity = Mapper1.Map<TEntity>(entityViewModel);
            BaseService.Remove(entity);
            await Uow.CommitAsync();

            return Ok(entityViewModel);
        }
    }
}