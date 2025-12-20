using LotusSimulator.Contract.MessageIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public interface IUserInputService
    {
        Task<TResponse> WaitForUserInput<TRequest, TResponse>(string connectionId, TRequest request) where TRequest : IUserInputDto;
        void CompleteWait<T>(T result) where T : IUserInputDto;
    }
}
