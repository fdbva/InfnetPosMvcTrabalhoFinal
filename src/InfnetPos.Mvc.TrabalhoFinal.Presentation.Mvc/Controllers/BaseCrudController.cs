//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using AutoMapper;
//using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces;
//using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
//using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;
//using Microsoft.AspNetCore.Mvc;

//namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.Controllers
//{
//    public class BaseCrudController<TResponse, TViewModel> : Controller
//        where TResponse : BaseResponse
//        where TViewModel : BaseViewModel
//    {
//        private readonly IQuestionClient<TResponse> _questionClient;
//        private readonly IMapper _mapper;

//        public BaseCrudController(IQuestionClient<TResponse> questionClient, IMapper mapper, string apiRoute)
//        {
//            questionClient.SetSubRoute(apiRoute);
//            _questionClient = questionClient;
//            _mapper = mapper;
//        }

//        // GET api/values
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<TViewModel>>> Index()
//        {
//            try
//            {
//                var response = await _questionClient.GetAsync();
//                return _mapper.Map<IEnumerable<TViewModel>>(response).ToList();
//            }
//            catch (HttpRequestException e)
//            {
//                return StatusCode(e.HResult);
//            }
//        }

//        // GET api/values/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<TViewModel>> Details(Guid id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
            
//            try
//            {
//                var response = await _questionClient.GetAsync(id);
//                return Ok(_mapper.Map<TViewModel>(response));
//            }
//            catch (HttpRequestException e)
//            {
//                return StatusCode(e.HResult);
//            }
//        }

//        // POST api/values
//        [HttpPost]
//        public async Task<ActionResult<TViewModel>> Create([FromBody] TViewModel viewModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            try
//            {
//                await _questionClient.PostAsync(_mapper.Map<TResponse>(viewModel));
//            }
//            catch (HttpRequestException e)
//            {
//                return StatusCode(e.HResult);
//            }

//            return Ok();
//            //TODO: Resolve post return
//            //return CreatedAtAction(nameof(Get), new { id = 0 }, viewModel);
//        }

//        // PUT api/values/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Edit(Guid id, [FromBody] TViewModel viewModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != viewModel.Id)
//            {
//                return BadRequest();
//            }

//            await _questionClient.PutAsync(id, _mapper.Map<QuestionResponse>(viewModel));

//            return NoContent();
//        }

//        // DELETE api/values/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(Guid id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            await _questionClient.DeleteAsync(id);

//            return Ok();
//        }
//    }
//}