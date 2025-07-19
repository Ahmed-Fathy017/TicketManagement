using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Domain.Common.Models
{
    public class DomainResult<T>
    {
        public bool IsSuccess { get; }
        public string? Error { get; }
        public T Value { get; }

        public static DomainResult<T> Success(T value) => new(true, null, value);
        public static DomainResult<T> Failure(string error) => new(false, error, default!);

        private DomainResult(bool isSuccess, string? error, T value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }
    }
}
