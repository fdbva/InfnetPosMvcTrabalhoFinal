using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.HttpClients.Interfaces;
using InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels;
using InfnetPos.Mvc.TrabalhoFinal.SharedViewModels.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQuestionClient _questionClient;

        public QuestionController(IQuestionClient questionClient, IMapper mapper)
        {
            _questionClient = questionClient;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _questionClient.GetAsync();
                return View(_mapper.Map<IEnumerable<QuestionViewModel>>(response).ToList());
            }
            catch (HttpRequestException e)
            {
                return StatusCode(e.HResult);
            }
        }
        
        public async Task<IActionResult> Details(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _questionClient.GetAsync(id);
                return View(_mapper.Map<QuestionViewModel>(response));
            }
            catch (HttpRequestException e)
            {
                return StatusCode(e.HResult);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST api/values
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            
            await _questionClient.PostAsync(_mapper.Map<QuestionResponse>(viewModel));

            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _questionClient.GetAsync(id);
                return View(_mapper.Map<QuestionViewModel>(response));
            }
            catch (HttpRequestException e)
            {
                return StatusCode(e.HResult);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, QuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (id != viewModel.Id)
            {
                return View(viewModel);
            }

            await _questionClient.PutAsync(id, _mapper.Map<QuestionResponse>(viewModel));

            return RedirectToAction(nameof(Index));
        }
        
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _questionClient.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}