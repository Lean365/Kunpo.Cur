// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>岗位控制器</summary>
// <remarks>处理岗位的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kunpo.Cur.Application.Dtos.Identity;
using Kunpo.Cur.Application.Services.Identity;
using Kunpo.Cur.Common.Models;
using Kunpo.Cur.Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Kunpo.Cur.Domain.Interfaces;
using Kunpo.Cur.Common.Interfaces;

namespace Kunpo.Cur.WebApi.Controllers.Identity
{
  /// <summary>
  /// 岗位控制器
  /// </summary>
  [ApiController]
  [Route("api/identity/post")]
  [ApiExplorerSettings(GroupName = "identity")]
  public class KpPostController : KpBaseController
  {
    private readonly IKpPostService _postService;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="localizationService">本地化服务</param>
    /// <param name="securityContext">安全上下文</param>
    /// <param name="postService">岗位服务</param>
    public KpPostController(
      Serilog.ILogger logger,
      IKpLocalizationService localizationService,
      IKpSecurityContext securityContext,
      IKpPostService postService) : base(logger, localizationService, securityContext)
    {
      _postService = postService;
    }

    /// <summary>
    /// 获取岗位列表
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>岗位列表</returns>
    [HttpGet("list")]
    [KpPermission("identity:post:list", "查询岗位")]
    [ProducesResponseType(typeof(KpApiResult<KpPageResult<KpPostDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPageResult<KpPostDto>>>> GetListAsync([FromQuery] KpPostQueryDto query)
    {
      try
      {
        var result = await _postService.GetListAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPageResult<KpPostDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取岗位详情
    /// </summary>
    /// <param name="id">岗位ID</param>
    /// <returns>岗位详情</returns>
    [HttpGet("{id}")]
    [KpPermission("identity:post:detail", "查看岗位")]
    [ProducesResponseType(typeof(KpApiResult<KpPostDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPostDto>>> GetByIdAsync(long id)
    {
      try
      {
        var result = await _postService.GetByIdAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPostDto>(ex.Message);
      }
    }

    /// <summary>
    /// 创建岗位
    /// </summary>
    /// <param name="input">岗位信息</param>
    /// <returns>岗位ID</returns>
    [HttpPost]
    [KpPermission("identity:post:create", "创建岗位")]
    [ProducesResponseType(typeof(KpApiResult<long>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<long>>> CreateAsync([FromBody] KpPostCreateDto input)
    {
      try
      {
        var result = await _postService.CreateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<long>(ex.Message);
      }
    }

    /// <summary>
    /// 更新岗位
    /// </summary>
    /// <param name="input">岗位信息</param>
    /// <returns>是否成功</returns>
    [HttpPut]
    [KpPermission("identity:post:update", "更新岗位")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> UpdateAsync([FromBody] KpPostUpdateDto input)
    {
      try
      {
        var result = await _postService.UpdateAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 删除岗位
    /// </summary>
    /// <param name="id">岗位ID</param>
    /// <returns>是否成功</returns>
    [HttpDelete("{id}")]
    [KpPermission("identity:post:delete", "删除岗位")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> DeleteAsync(long id)
    {
      try
      {
        var result = await _postService.DeleteAsync(id);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 修改岗位状态
    /// </summary>
    /// <param name="input">状态信息</param>
    /// <returns>是否成功</returns>
    [HttpPut("status")]
    [KpPermission("identity:post:status", "修改岗位状态")]
    [ProducesResponseType(typeof(KpApiResult<bool>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<bool>>> ChangeStatusAsync([FromBody] KpPostChangeStatusDto input)
    {
      try
      {
        var result = await _postService.ChangeStatusAsync(input);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<bool>(ex.Message);
      }
    }

    /// <summary>
    /// 导入岗位
    /// </summary>
    /// <param name="posts">岗位导入数据</param>
    /// <returns>导入结果</returns>
    [HttpPost("import")]
    [KpPermission("identity:post:import", "导入岗位")]
    [ProducesResponseType(typeof(KpApiResult<KpImportResult>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpImportResult>>> ImportAsync([FromBody] List<KpPostImportDto> posts)
    {
      try
      {
        var result = await _postService.ImportAsync(posts);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpImportResult>(ex.Message);
      }
    }

    /// <summary>
    /// 导出岗位
    /// </summary>
    /// <param name="query">查询条件</param>
    /// <returns>岗位导出数据</returns>
    [HttpGet("export")]
    [KpPermission("identity:post:export", "导出岗位")]
    [ProducesResponseType(typeof(KpApiResult<List<KpPostExportDto>>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<List<KpPostExportDto>>>> ExportAsync([FromQuery] KpPostQueryDto query)
    {
      try
      {
        var result = await _postService.ExportAsync(query);
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<List<KpPostExportDto>>(ex.Message);
      }
    }

    /// <summary>
    /// 获取岗位导入模板
    /// </summary>
    /// <returns>岗位导入模板</returns>
    [HttpGet("template")]
    [KpPermission("identity:post:template", "获取岗位导入模板")]
    [ProducesResponseType(typeof(KpApiResult<KpPostTemplateDto>), 200)]
    [ProducesResponseType(typeof(KpApiResult), 400)]
    public async Task<ActionResult<KpApiResult<KpPostTemplateDto>>> GetImportTemplateAsync()
    {
      try
      {
        var result = await _postService.GetImportTemplateAsync();
        return Success(result);
      }
      catch (Exception ex)
      {
        return Error<KpPostTemplateDto>(ex.Message);
      }
    }
  }
}