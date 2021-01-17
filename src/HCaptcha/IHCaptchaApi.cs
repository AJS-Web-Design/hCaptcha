using System.Threading.Tasks;

namespace AJSWebDesign.HCaptcha
{
    /// <summary>
    /// https://docs.hcaptcha.com/#server
    /// </summary>
    public interface IHCaptchaApi
    {
        /// <summary>
        /// The endpoint expects a POST request with two parameters: your <paramref name="secret"/> API key and the h-captcha-response token (<paramref name="response"/> POSTed from your HTML page. You can optionally include the user's IP address (<paramref name="remoteIp"/>) as an additional security check. Do not send JSON data: the endpoint expects a standard URL-encoded form POST.
        /// </summary>
        Task <HCaptchaVerifyResponse> Verify(string secret, string token, string remoteIp);
    }
}