using Base.Core.Paging;
using Base.Core.Results;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Base.Core.Handlers
{
    public class BasePagingHandler<THandler, TDto> : BasePaging<TDto>
        where THandler : class 
        where TDto : class
    {
        private readonly ILogger<THandler> _logger;
        protected ResultPaging<TDto> ActionResult { get; set; }

        public BasePagingHandler(ILogger<THandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            ActionResult = new ResultPaging<TDto>()
            {
                IsValid = false,
                Response = null,
                Errors = new Error()
            };
        }

        protected ResultPaging<TDto> GenerateModelError(ResultPaging<TDto> result, IList<ValidationFailure> errors)
        {
            _logger.LogWarning("Error response, {@result}", result);

            result.IsValid = false;

            foreach (var error in errors)
            {
                result.Errors.Code = error.ErrorCode;
                result.Errors.Message = error.ErrorMessage;
            }
            return result;
        }
    }

}
