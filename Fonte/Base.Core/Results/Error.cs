using System.Runtime.Serialization;

namespace Base.Core.Results
{
    [DataContract]
    public class Error
    {
        [DataMember(Name = "retcode")]
        public string Code { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
