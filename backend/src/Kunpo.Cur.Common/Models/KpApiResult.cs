// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>API统一返回结果</summary>
// <remarks>处理API的统一返回结果</remarks>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Kunpo.Cur.Common.Enums;

namespace Kunpo.Cur.Common.Models
{
  /// <summary>
  /// API统一返回结果
  /// </summary>
  public class KpApiResult<T>
  {
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// 状态码
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// 请求ID
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// 成功
    /// </summary>
    public static KpApiResult<T> Ok(T? data = default, string? message = null)
    {
      return new KpApiResult<T>
      {
        Success = true,
        Code = (int)KpBusinessType.Query,
        Message = message ?? "操作成功",
        Data = data,
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 失败
    /// </summary>
    public static KpApiResult<T> Fail(string? message = null, KpErrorCode errorCode = KpErrorCode.ServerError, T? data = default)
    {
      return new KpApiResult<T>
      {
        Success = false,
        Code = (int)errorCode,
        Message = message ?? "操作失败",
        Data = data,
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 未授权
    /// </summary>
    public static KpApiResult<T> Unauthorized(string? message = null)
    {
      return new KpApiResult<T>
      {
        Success = false,
        Code = (int)KpErrorCode.Unauthorized,
        Message = message ?? "未授权",
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 禁止访问
    /// </summary>
    public static KpApiResult<T> Forbidden(string? message = null)
    {
      return new KpApiResult<T>
      {
        Success = false,
        Code = (int)KpErrorCode.Forbidden,
        Message = message ?? "禁止访问",
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 未找到
    /// </summary>
    public static KpApiResult<T> NotFound(string? message = null)
    {
      return new KpApiResult<T>
      {
        Success = false,
        Code = (int)KpErrorCode.NotFound,
        Message = message ?? "未找到",
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 服务器错误
    /// </summary>
    public static KpApiResult<T> ServerError(string? message = null, T? data = default)
    {
      return new KpApiResult<T>
      {
        Success = false,
        Code = (int)KpErrorCode.ServerError,
        Message = message ?? "服务器错误",
        Data = data,
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }
  }

  /// <summary>
  /// API统一返回结果（无数据）
  /// </summary>
  public class KpApiResult : KpApiResult<object>
  {
    /// <summary>
    /// 成功
    /// </summary>
    public static new KpApiResult Ok(object? data = null, string? message = null)
    {
      return new KpApiResult
      {
        Success = true,
        Code = (int)KpBusinessType.Query,
        Message = message ?? "操作成功",
        Data = data,
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 失败
    /// </summary>
    public static new KpApiResult Fail(string? message = null, KpErrorCode errorCode = KpErrorCode.ServerError, object? data = null)
    {
      return new KpApiResult
      {
        Success = false,
        Code = (int)errorCode,
        Message = message ?? "操作失败",
        Data = data,
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 未授权
    /// </summary>
    public static new KpApiResult Unauthorized(string? message = null)
    {
      return new KpApiResult
      {
        Success = false,
        Code = (int)KpErrorCode.Unauthorized,
        Message = message ?? "未授权",
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 禁止访问
    /// </summary>
    public static new KpApiResult Forbidden(string? message = null)
    {
      return new KpApiResult
      {
        Success = false,
        Code = (int)KpErrorCode.Forbidden,
        Message = message ?? "禁止访问",
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 未找到
    /// </summary>
    public static new KpApiResult NotFound(string? message = null)
    {
      return new KpApiResult
      {
        Success = false,
        Code = (int)KpErrorCode.NotFound,
        Message = message ?? "未找到",
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }

    /// <summary>
    /// 服务器错误
    /// </summary>
    public static new KpApiResult ServerError(string? message = null, object? data = null)
    {
      return new KpApiResult
      {
        Success = false,
        Code = (int)KpErrorCode.ServerError,
        Message = message ?? "服务器错误",
        Data = data,
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
      };
    }
  }
}