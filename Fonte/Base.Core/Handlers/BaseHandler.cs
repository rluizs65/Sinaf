using Base.Core.Results;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace Base.Core.Handlers
{
    #region Object Result
    public class BaseHandler<THandler, TDto> where THandler : class where TDto : class
    {
        private readonly ILogger<THandler> _logger;
        protected Result<TDto> ActionResult { get; set; }

        public BaseHandler(ILogger<THandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            ActionResult = new Result<TDto>()
            {
                IsValid = false,
                Response = null,
                Errors = new Error()
            };
        }

        protected Result<TDto> GenerateModelError(Result<TDto> result, IList<ValidationFailure> errors)
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
    #endregion

    #region Typed Result
    public class BaseHandler<THandler> where THandler : class
    {
        private readonly ILogger<THandler> _logger;
        protected Result ActionResult { get; set; }

        public BaseHandler(ILogger<THandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            ActionResult = new Result()
            {
                IsValid = false,
                Errors = new Error()
            };
        }

        protected Result GenerateModelError(Result result, IList<ValidationFailure> errors)
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
    #endregion

    
}
