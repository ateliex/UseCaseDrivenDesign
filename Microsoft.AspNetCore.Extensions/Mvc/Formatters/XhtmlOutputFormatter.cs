using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Microsoft.AspNetCore.Mvc.Formatters
{
    public class XhtmlOutputFormatter : XmlSerializerOutputFormatter
    {
        public XhtmlOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/html"));

            SupportedEncodings.Add(Encoding.UTF8);

            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            return
                type.BaseType == typeof(LinkedResource) ||
                type.BaseType.GetGenericTypeDefinition() == typeof(LinkedResourceCollection<>);
        }

        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            try
            {
                var enconding = base.SelectCharacterEncoding(context);

                var settings = new XmlWriterSettings();

                settings.Encoding = enconding;

                settings.Async = true;

                var response = context.HttpContext.Response;

                var xmlWriter = CreateXmlWriter(context, new StreamWriter(response.Body), settings);

                var resource = context.Object as LinkedResource;

                //

                var html = new TagBuilder("html");

                html.Attributes.Add("lang", "pt-br");

                //

                var head = new TagBuilder("head");

                html.InnerHtml.AppendHtml(head);

                //

                var meta1 = new TagBuilder("meta");

                head.InnerHtml.AppendHtml(meta1);

                meta1.Attributes.Add("charset", "utf-8");

                //

                var meta2 = new TagBuilder("meta");

                head.InnerHtml.AppendHtml(meta2);

                meta2.Attributes.Add("name", "viewport");
                
                meta2.Attributes.Add("content", "width=device-width, initial-scale=1.0");

                //

                var title = new TagBuilder("title");

                head.InnerHtml.AppendHtml(title);

                title.InnerHtml.Append(resource.Title);

                //

                var link1 = new TagBuilder("link");

                head.InnerHtml.AppendHtml(link1);

                link1.Attributes.Add("rel", "stylesheet");
                
                link1.Attributes.Add("href", "https://cdnjs.cloudflare.com/ajax/libs/semantic-ui/2.4.1/semantic.min.css");

                //

                var link2 = new TagBuilder("link");

                head.InnerHtml.AppendHtml(link2);

                link2.Attributes.Add("rel", "stylesheet");

                link2.Attributes.Add("href", "/css/api.css");

                //

                var body = new TagBuilder("body");

                html.InnerHtml.AppendHtml(body);

                body.AddCssClass("ui basic segment");

                if (resource is IEnumerable)
                {
                    var ul = new TagBuilder("ul");

                    body.InnerHtml.AppendHtml(ul);

                    ul.AddCssClass("ui menu");

                    ul.Attributes.Add("href", resource.HRef);

                    foreach (LinkedResource innerResource in resource as IEnumerable)
                    {
                        var li = new TagBuilder("li");

                        ul.InnerHtml.AppendHtml(li);

                        //li.AddCssClass("item");

                        SerializeInnerResource(li, innerResource);
                    }
                }
                //else if (resource.GetType().BaseType.GetGenericTypeDefinition() == typeof(LinkedResourceForm<>))
                //{
                //    var formResource = resource as LinkedResourceForm<string>;

                //    var form = new TagBuilder("form");

                //    body.InnerHtml.AppendHtml(form);

                //    form.AddCssClass("ui form");

                //    form.Attributes.Add("action", formResource.Method);

                //    //

                //    var button = new TagBuilder("button");

                //    form.InnerHtml.AppendHtml(button);

                //    button.AddCssClass("ui button");
                //}
                else
                {
                    var div = new TagBuilder("div");

                    body.InnerHtml.AppendHtml(div);

                    div.AddCssClass("ui menu");

                    //div.Attributes.Add("href", resource.HRef);

                    SerializeInnerResource(div, resource);
                }

                //

                var stringWriter = new StringWriter();

                html.WriteTo(stringWriter, HtmlEncoder.Default);

                await xmlWriter.WriteRawAsync(stringWriter.ToString());

                //

                await xmlWriter.FlushAsync();

                xmlWriter.Close();
            }
            catch (Exception ex)
            {
                var _ = ex.Message;

                throw;
            }
        }

        private void SerializeInnerResource(TagBuilder content, LinkedResource resource)
        {
            content.Attributes.Add("href", resource.HRef);

            foreach (var link in resource.Links)
            {
                var item = new TagBuilder("a");

                content.InnerHtml.AppendHtml(item);

                item.AddCssClass("item");

                item.Attributes.Add("rel", link.Rel);

                item.Attributes.Add("href", link.HRef);

                item.Attributes.Add("type", "text/xhtml");

                item.InnerHtml.Append(link.Text);
            }
        }
    }
}
