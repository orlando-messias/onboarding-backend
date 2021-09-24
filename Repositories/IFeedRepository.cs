using System.Collections.Generic;

namespace Eem.App
{
    public interface IFeedRepository
    {
        List<Feed> GetFeeds();
    }
}