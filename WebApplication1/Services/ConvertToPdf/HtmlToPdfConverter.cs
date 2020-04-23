namespace BMS.Services
{
    using BMS.Services.Contracts;
    using BMS.Services.ConvertToPdf.Enums;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    public class HtmlToPdfConverter : IHtmlToPdfConverter
    {
        private readonly string _rasterizePath = @"C:\Users\Mitko\source\repos\DMOME\BMS\WebApplication1\wwwroot\js\rasterize.js";

        public byte[] Convert(string basePath, string htmlCode)
        {
            var inputFileName = $"input_{Guid.NewGuid()}.html";
            var outputFileName = $"output_{Guid.NewGuid()}.pdf";
            File.WriteAllText($"{basePath}/{inputFileName}", htmlCode);

            var formatType = FormatType.A4;
            var orientationType = OrientationType.Portrait;

            var startInfo = new ProcessStartInfo("phantomjs.exe")
            {
                WorkingDirectory = basePath,
                Arguments = $"{_rasterizePath} \"{inputFileName}\" \"{outputFileName}\" \"{formatType}\" \"{orientationType.ToString().ToLower()}\"",
                UseShellExecute = false,
            };

            var process = new Process { StartInfo = startInfo };
            process.Start();

            process.WaitForExit();

            var bytes = File.ReadAllBytes($"{basePath}/{outputFileName}");

            File.Delete($"{basePath}/{inputFileName}");
            File.Delete($"{basePath}/{outputFileName}");

            return bytes;
        }
    }
}
