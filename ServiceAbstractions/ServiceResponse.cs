using System.Collections.Generic;

namespace ServiceAbstractions
{
    public class ServiceResponse
    {
        public ServiceResponse(string defaultMessage)
        {
            Success = true;
            Message = defaultMessage;
        }

        public bool Success { get; set; }
        public string Message { get; set; }

        public ServiceResponse SetError(string msg)
        {
            Success = false;
            Message = msg;
            return this;
        }
    }

    public class ServiceResponseScalar<T> : ServiceResponse
    {
        public ServiceResponseScalar(string defaultMessage) : base(defaultMessage) { }

        public T Scalar { get; set; }

        public new ServiceResponseScalar<T> SetError(string msg)
        {
            base.SetError(msg);
            return this;
        }
    }

    public class ServiceResponseCollection<T> : ServiceResponse
    {
        public ServiceResponseCollection(string defaultMessage) : base(defaultMessage) { }

        public ICollection<T> Collection { get; set; }

        public new ServiceResponseCollection<T> SetError(string msg)
        {
            base.SetError(msg);
            return this;
        }
    }
}