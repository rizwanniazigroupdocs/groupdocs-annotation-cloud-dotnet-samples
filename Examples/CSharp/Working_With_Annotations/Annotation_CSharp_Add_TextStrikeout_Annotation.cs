using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GroupDocs.Annotation.Cloud.Sdk.Api;
using GroupDocs.Annotation.Cloud.Sdk.Client;
using GroupDocs.Annotation.Cloud.Sdk.Model;
using GroupDocs.Annotation.Cloud.Sdk.Model.Requests;

namespace GroupDocs.Annotation.Cloud.Examples.CSharp
{
	// Post/Add Text Strikeout annotations
	class Add_TextStrikeout_Annotation
	{
		public static void Run()
		{
			var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
			var apiInstance = new AnnotateApi(configuration);

			try
			{
				// Set request.
				var request = new PostAnnotationsRequest();
				request.filePath = "Annotationdocs\\ten-pages.pdf";
				AnnotationInfo[] annotations =
				{
					new AnnotationInfo
					{
						AnnotationPosition = new Point { X = 1, Y = 1 },
						FontColor = 65535,
						PageNumber = 1,
						Type = AnnotationInfo.TypeEnum.TextStrikeout,
						Text = "This is text strikeout annotation",
						CreatorName = "Anonym A.",
						CreatedOn = DateTime.Now,
						Replies = new List<AnnotationReplyInfo>
						{
							new AnnotationReplyInfo
							{
								Message = "First comment",
								RepliedOn = DateTime.Now
							},
							new AnnotationReplyInfo
							{
								Message = "Second comment",
								RepliedOn = DateTime.Now
							}
						}
					},
				};
				request.annotations = annotations.ToList();
				apiInstance.PostAnnotations(request);
				Console.WriteLine("Expected response type is void: Text Strikeout Annotation added.");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception while calling Annotation AnnotateApi: " + e.Message);
			}
		}
	}
}