using game_center_backend_cs.Domain.DTOs.Requests;
using game_center_backend_cs.Domain.DTOs.Responses;
using game_center_backend_cs.Domain.Mappers;
using game_center_backend_cs.Domain.Models.FillWord;
using game_center_backend_cs.Domain.Services.FillWord;
using game_center_backend_cs.Presentation.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace game_center_backend_cs.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[SimpleAuthentication]
public class FillWordController : ControllerBase
{
    private readonly FillWordCreateService _fillWordCreateService;
    private readonly FillWordGetService _fillWordGetService;
    private readonly FillWordUpdateService _fillWordUpdateService;

    public FillWordController(
        FillWordCreateService createService,
        FillWordUpdateService updateService,
        FillWordGetService getService
    )
    {
        _fillWordCreateService = createService;
        _fillWordUpdateService = updateService;
        _fillWordGetService = getService;
    }

    [HttpPut]
    public ActionResult<FillWordModel> Create([FromBody] FillWordCreateRequest request)
    {
        var model = _fillWordCreateService.Create(request.Size);
        return StatusCode(201, model);
    }

    [HttpPost]
    public ActionResult<FillWordAttemptResponse> Attempt([FromBody] FillWordAttemptRequest request)
    {
        var status = _fillWordUpdateService.Attempt(request.Id, request.AnswerIds);
        return Ok(FillWordMapper.ToAttemptResponse(status));
    }

    [HttpGet("{id}")]
    public ActionResult<FillWordDetailResponse> FindById(string id)
    {
        var response = _fillWordGetService.FindById(id);
        return Ok(response);
    }

    [HttpGet]
    public ActionResult<List<FillWordDetailResponse>> List()
    {
        var response = _fillWordGetService.List();
        return Ok(response);
    }
}