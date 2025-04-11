// -----------------------------------------------------------------------
// <copyright file="KpBaseException.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>异常类</summary>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Kunpo.Cur.Common.Exceptions
{
    /// <summary>
    /// 基础异常类
    /// </summary>
    public class KpBaseException : Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// 错误详情
        /// </summary>
        public object? Details { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public KpBaseException(string? message, int code = 500, object? details = null)
            : base(message)
        {
            Code = code;
            Details = details;
        }
    }

    /// <summary>
    /// 业务异常类
    /// </summary>
    public class KpBusinessException : KpBaseException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public KpBusinessException(string? message, int code = 400, object? details = null)
            : base(message, code, details)
        {
        }
    }

    /// <summary>
    /// 未授权异常类
    /// </summary>
    public class KpUnauthorizedException : KpBaseException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public KpUnauthorizedException(string? message = "未授权访问", object? details = null)
            : base(message, 401, details)
        {
        }
    }

    /// <summary>
    /// 禁止访问异常类
    /// </summary>
    public class KpForbiddenException : KpBaseException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public KpForbiddenException(string? message = "禁止访问", object? details = null)
            : base(message, 403, details)
        {
        }
    }

    /// <summary>
    /// 未找到异常类
    /// </summary>
    public class KpNotFoundException : KpBaseException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public KpNotFoundException(string? message = "未找到指定资源", object? details = null)
            : base(message, 404, details)
        {
        }
    }

    /// <summary>
    /// 验证异常类
    /// </summary>
    public class KpValidationException : KpBaseException
    {
        /// <summary>
        /// 验证错误列表
        /// </summary>
        public List<ValidationError> Errors { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public KpValidationException(string? message = "数据验证失败", List<ValidationError>? errors = null)
            : base(message, 422, errors)
        {
            Errors = errors ?? new List<ValidationError>();
        }
    }

    /// <summary>
    /// 验证错误
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string? Field { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ValidationError(string? field, string? message)
        {
            Field = field;
            Message = message;
        }
    }
}