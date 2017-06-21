﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;

namespace dentist
{

    public class ApplicationAuthenticationHandler : DelegatingHandler
    {
        // Http Response Messages
        private const string InvalidToken = "Invalid Authorization-Token";
        private const string MissingToken = "Missing Authorization-Token";

        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Write your Authentication code here
            IEnumerable<string> monsterApiKeyHeaderValues = null;

            // Checking the Header values
            if (request.Headers.TryGetValues("X-wsApiKey", out monsterApiKeyHeaderValues))
            {
                string[] apiKeyHeaderValue = monsterApiKeyHeaderValues.First().Split(':');

                // Validating header value must have both APP ID & APP key
                if (apiKeyHeaderValue.Length == 2)
                {
                    // Code logic after authenciate the application.
                    var appID = apiKeyHeaderValue[0];
                    var AppKey = apiKeyHeaderValue[1];
                    if (appID.Equals(ConfigurationManager.AppSettings["appID"]) && AppKey.Equals(ConfigurationManager.AppSettings["AppKey"]))
                    {
                        var userNameClaim = new Claim(ClaimTypes.Name, appID);
                        var identity = new ClaimsIdentity(new[] { userNameClaim }, "wsApiKeyApiKey");
                        var principal = new ClaimsPrincipal(identity);
                        Thread.CurrentPrincipal = principal;

                        if (System.Web.HttpContext.Current != null)
                        {
                            System.Web.HttpContext.Current.User = principal;
                        }
                    }
                    else
                    {
                        // Web request cancel reason APP key is NULL
                        return requestCancel(request, cancellationToken, InvalidToken);
                    }
                }
                else
                {
                    // Web request cancel reason missing APP key or APP ID
                    return requestCancel(request, cancellationToken, MissingToken);
                }
            }
            else
            {
                // Web request cancel reason APP key missing all parameters
                return requestCancel(request, cancellationToken, MissingToken);
            }

            return base.SendAsync(request, cancellationToken);
        }

        private System.Threading.Tasks.Task<HttpResponseMessage> requestCancel(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken, string message)
        {
            CancellationTokenSource _tokenSource = new CancellationTokenSource();
            cancellationToken = _tokenSource.Token;
            _tokenSource.Cancel();
            HttpResponseMessage response = new HttpResponseMessage();

            response = request.CreateResponse(HttpStatusCode.BadRequest);
            response.Content = new StringContent(message);
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                return response;
            });
        }
    }

    //http://www.c-sharpcorner.com/UploadFile/013102/mvc-web-api-authorization-authentication/

}