using System;
using System.Collections.Generic;
using Eem.App;
using Microsoft.AspNetCore.Mvc;

namespace madura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly IFeedRepository _feedRepository;

        public FeedController(IFeedRepository feedRepository)
        {
            _feedRepository = feedRepository;

        }

        [HttpGet]
        [Route("/api/feeds")]
        public List<Feed> Feeds()
        {
            List<Feed> t = _feedRepository.GetFeeds();
            return t;
        }
    }
}
