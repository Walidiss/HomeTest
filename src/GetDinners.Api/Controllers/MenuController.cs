﻿using GetDinner.Contracts.Dinners;
using GetDinners.Application.Menus.Commands;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GetDinners.Api.Controllers
{
    [Route("/hosts/{hostId}/menu")]
    public class MenuController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public MenuController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task <IActionResult> CreateMenu(CreateMenuRequest request, Guid hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request,hostId));
            var createMenuResult = await _mediator.Send(command);

            return createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors));

        }
    }
}
