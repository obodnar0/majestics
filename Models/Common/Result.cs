using Newtonsoft.Json;
using System.Net;

namespace Majestics.Models.Common
{
    public class ActionResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Result { get; set; }
    }

    public static class Result
    {
        public static ActionResult Blank() { return new ActionResult(); }
        public static ActionResult GetResult(object result) { return new ActionResult { Result = JsonConvert.SerializeObject(result) }; }
        public static ActionResult GetResult(string result) { return new ActionResult { Result = result }; }
        public static ActionResult GetResult(object result, HttpStatusCode code) { return new ActionResult { Result = JsonConvert.SerializeObject(result), StatusCode = code}; }
        public static ActionResult GetResult(string result, HttpStatusCode code) { return new ActionResult { Result = result, StatusCode = code }; }
        public static ActionResult Ok() { return new ActionResult { StatusCode = HttpStatusCode.OK }; }
        public static ActionResult Ok(string result) { return new ActionResult {Result = result, StatusCode = HttpStatusCode.OK}; }
        public static ActionResult Ok(object result) { return new ActionResult { Result = JsonConvert.SerializeObject(result), StatusCode = HttpStatusCode.OK}; }
        public static ActionResult Error(string result) { return new ActionResult { Result = result, StatusCode = HttpStatusCode.InternalServerError }; }
        public static ActionResult Error(object result) { return new ActionResult { Result = JsonConvert.SerializeObject(result), StatusCode = HttpStatusCode.InternalServerError }; }
    }
}
