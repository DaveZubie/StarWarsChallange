using System.IO;
using System.Net;

namespace StarWarsChallenge
{
    public class ApiHandler
    {
        public bool Error { get; set; } = false;
        public HttpStatusCode StatusCode { get; set; }
        public int StatusNumber { get; set; }

        /// <summary>
        /// Function to read from the URL specified
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Json response</returns>
        public string APIReader(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                SetStatus(response);

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    string json = reader.ReadToEnd();
                    reader.Dispose();

                    return json;
                }
            }
            catch (WebException ex)
            {
                var errorMessage = ErrorHandler.ReturnErrorDescription(Constants.defaultErrorCode);

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    var test = ex.Response as WebResponse;
                    if (response != null)
                    {
                        SetStatus(response);
                        errorMessage = ErrorHandler.ReturnErrorDescription((int)response.StatusCode);
                    }
                }
                Error = true;
                return errorMessage;
            }
        }

        private void SetStatus(HttpWebResponse response)
        {
            StatusCode = response.StatusCode;
            StatusNumber = (int)response.StatusCode;
        }
    }
}
