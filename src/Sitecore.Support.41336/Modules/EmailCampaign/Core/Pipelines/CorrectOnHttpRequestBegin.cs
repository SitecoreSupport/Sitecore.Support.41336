using Sitecore.Pipelines.HttpRequest;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.Modules.EmailCampaign.Core.Pipelines
{
    public class CorrectOnHttpRequestBegin
    {
        public void Process(HttpRequestArgs args)
        {
            if (MediaManager.IsMediaUrl(args.Context.Request.RawUrl))
            {
                Sitecore.Resources.Media.Media media = MediaManager.GetMedia(MediaManager.ParseMediaRequest(args.Context.Request).MediaUri);
                if ((media != null) && !string.IsNullOrWhiteSpace(media.MimeType))
                {
                    args.Context.Response.ContentType = media.MimeType;
                }
            }
        }
    }
}