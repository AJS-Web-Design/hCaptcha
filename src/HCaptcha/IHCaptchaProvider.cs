﻿using System.Threading;
using System.Threading.Tasks;

namespace AJSWebDesign.HCaptcha
{
    public interface IHCaptchaProvider
    {
        /// <summary>
        /// Requests the hCaptcha API. Timeout configuration is provided via <paramref name="cancellationToken"/>
        /// </summary>
        /// <param name="token">The client's token.</param>
        /// <param name="remoteIp">Optional the client's IP address</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="HCaptchaVerifyResponse"/></returns>
        /// <exception cref="HCaptchaApiException">if request failed.</exception>
        Task<HCaptchaVerifyResponse> Verify(string token, string remoteIp = null, CancellationToken cancellationToken = default);
    }
}