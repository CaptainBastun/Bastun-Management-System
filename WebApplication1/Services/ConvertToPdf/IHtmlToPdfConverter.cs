namespace BMS.Services.Contracts
{
    using BMS.Services.ConvertToPdf.Enums;
    public interface IHtmlToPdfConverter
    {
        byte[] Convert(string basePath, string htmlCode);
    }
}
