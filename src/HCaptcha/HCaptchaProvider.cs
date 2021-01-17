using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace AJSWebDesign.HCaptcha
{
    /// <summary>
    /// HCaptcha Provider - API communication
    /// </summary>
    public class HCaptchaProvider : IHCaptchaProvider
    {
        private readonly IHCaptchaApi _captchaApi;
        private readonly HCaptchaOptions _captchaOptions;

        public HCaptchaProvider(IHCaptchaApi captchaApi, IOptions<HCaptchaOptions> captchaOptionsAccessor)
        {
            _captchaApi = captchaApi;
            _captchaOptions = captchaOptionsAccessor.Value;
        }

        /// <summary>
        /// Requests the hCaptcha API via the provided <see cref="IHCaptchaApi"/>.
        /// </summary>
        /// <param name="token">The client's token.</param>
        /// <param name="remoteIp">Optional the client's IP address</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="HCaptchaVerifyResponse"/></returns>
        public async Task<HCaptchaVerifyResponse> Verify(string token, string remoteIp = null, CancellationToken cancellationToken = default)
        {
            return await _captchaApi.Verify(_captchaOptions.Secret, token,
                _captchaOptions.VerifyRemoteIp ? remoteIp : null).ConfigureAwait(false);
        }
    }
}