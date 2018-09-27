using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.Controllers
{
    public class BaseCrudController<TResponse, TViewModel> : Controller
        where TResponse : BaseResponse
        where TViewModel : BaseViewModel
    {
        private readonly IBaseClient<TResponse, TViewModel> _baseClient;

        public BaseCrudController(IBaseClient<TResponse, TViewModel> baseClient)
        {
            _baseClient = baseClient;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TViewModel>>> Index()
        {
            return (await _baseClient.GetAsync()).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TViewModel>> Details(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var viewModel = await _baseClient.GetAsync(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return Ok(viewModel);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<TViewModel>> Create([FromBody] TViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _baseClient.PostAsync(viewModel);
            }
            catch (HttpRequestException e)
            {
                return StatusCode(e.HResult);
            }

            return Ok();
            //TODO: Resolve post return
            //return CreatedAtAction(nameof(Get), new { id = 0 }, viewModel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] TViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            await _baseClient.PutAsync(id, viewModel);

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

            await _baseClient.DeleteAsync(id);

            return Ok();
        }
    }
}