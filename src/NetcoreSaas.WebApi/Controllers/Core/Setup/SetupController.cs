using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetcoreSaas.Application.Dtos.Core.Emails;
using NetcoreSaas.Application.Services.Messages;
using NetcoreSaas.Domain.Helpers;
using NetcoreSaas.Domain.Settings;
using PostmarkDotNet;
using PostmarkDotNet.Model;

namespace NetcoreSaas.WebApi.Controllers.Core.Setup
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SetupController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public SetupController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet(ApiCoreRoutes.Setup.GetPostmarkTemplates)]
        public async Task<IActionResult> GetPostmarkTemplates()
        {
            var templates = await _emailService.GetAllTemplates();
            return Ok(templates);
        }
        
        
        [HttpPost(ApiCoreRoutes.Setup.CreatePostmarkTemplates)]
        public async Task<IActionResult> CreatePostmarkTemplates()
        {
            try
            {
                var templates = await _emailService.CreateTemplates();
                return Ok(templates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}