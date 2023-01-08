using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Markdig;

namespace BlazorWpfSample
{
    public sealed class ApplicationContext
    {
        public static readonly string ConfigurationFileName = "appsettings.json";
        public static readonly string LicenseFileName = "License.md";
        public static readonly string ThirdPartyNoticesFileName = "ThirdPartyNotices.md";

        private string _licenceHtml = "";
        private string _thirdPartyNoticesHtml = "";

        public void OpenConfigurationFile()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                System.Diagnostics.Process.Start("explorer.exe", $"{directory}\\{ConfigurationFileName}");
            }
        }

        public async Task<string> GetLicenseHtmlAsync()
        {
            if (string.IsNullOrEmpty(_licenceHtml))
            {
                var markdownPipeline = new MarkdownPipelineBuilder().UsePipeTables().Build();
                var text = await System.IO.File.ReadAllTextAsync(LicenseFileName);
                _licenceHtml = Markdown.ToHtml(text, markdownPipeline);
            }
            return _licenceHtml;
        }

        public async Task<string> GetThirdPartyNoticesHtmlAsync()
        {
            if (string.IsNullOrEmpty(_thirdPartyNoticesHtml))
            {
                var markdownPipeline = new MarkdownPipelineBuilder().UsePipeTables().Build();
                var text = await System.IO.File.ReadAllTextAsync(ThirdPartyNoticesFileName);
                _thirdPartyNoticesHtml = Markdown.ToHtml(text, markdownPipeline);
            }
            return _thirdPartyNoticesHtml;
        }
    }
}