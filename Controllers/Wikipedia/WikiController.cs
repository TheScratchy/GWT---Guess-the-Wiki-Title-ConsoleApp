// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using GWT_ConsoleApp.Services;

// namespace GWT_ConsoleApp.Controllers.Wikipedia
// {
//     [ApiController]
//     [Route("api/wiki")]
//     public class WikiController : ControllerBase
//     {
//         private readonly IWikipediaService _wikiService;

//         public WikiController(IWikipediaService wikiService)
//         {
//             _wikiService = wikiService;
//         }

//         [HttpGet("{title}")]
//         public async Task<IActionResult> Get(string title)
//         {
//             var article = await _wikiService.GetArticleAsync(title);

//             if (article == null)
//                 return NotFound();

//             return Ok(article);
//         }
//     }
// }