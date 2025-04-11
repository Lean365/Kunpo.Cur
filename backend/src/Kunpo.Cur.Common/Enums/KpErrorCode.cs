// -----------------------------------------------------------------------
// <copyright file="KpDictDataDto.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-04-04</date>
// <summary>错误代码</summary>
// <remarks>处理错误的查询、创建、更新、删除和导出等操作</remarks>
// -----------------------------------------------------------------------

namespace Kunpo.Cur.Common.Enums
{
  /// <summary>
  /// 错误代码
  /// </summary>
  public enum KpErrorCode
  {
    #region HTTP状态码（200-599）
    /// <summary>
    /// 成功
    /// </summary>
    Success = 200,

    /// <summary>
    /// 已创建
    /// </summary>
    Created = 201,

    /// <summary>
    /// 已接受
    /// </summary>
    Accepted = 202,

    /// <summary>
    /// 无内容
    /// </summary>
    NoContent = 204,

    /// <summary>
    /// 部分内容
    /// </summary>
    PartialContent = 206,

    /// <summary>
    /// 永久移动
    /// </summary>
    MovedPermanently = 301,

    /// <summary>
    /// 临时移动
    /// </summary>
    MovedTemporarily = 302,

    /// <summary>
    /// 未修改
    /// </summary>
    NotModified = 304,

    /// <summary>
    /// 临时重定向
    /// </summary>
    TemporaryRedirect = 307,

    /// <summary>
    /// 永久重定向
    /// </summary>
    PermanentRedirect = 308,

    /// <summary>
    /// 错误请求
    /// </summary>
    BadRequest = 400,

    /// <summary>
    /// 未授权
    /// </summary>
    Unauthorized = 401,

    /// <summary>
    /// 禁止访问
    /// </summary>
    Forbidden = 403,

    /// <summary>
    /// 未找到
    /// </summary>
    NotFound = 404,

    /// <summary>
    /// 方法不允许
    /// </summary>
    MethodNotAllowed = 405,

    /// <summary>
    /// 不接受
    /// </summary>
    NotAcceptable = 406,

    /// <summary>
    /// 代理认证
    /// </summary>
    ProxyAuthenticationRequired = 407,

    /// <summary>
    /// 请求超时
    /// </summary>
    RequestTimeout = 408,

    /// <summary>
    /// 冲突
    /// </summary>
    Conflict = 409,

    /// <summary>
    /// 已删除
    /// </summary>
    Gone = 410,

    /// <summary>
    /// 长度必需
    /// </summary>
    LengthRequired = 411,

    /// <summary>
    /// 前提条件失败
    /// </summary>
    PreconditionFailed = 412,

    /// <summary>
    /// 请求实体过大
    /// </summary>
    RequestEntityTooLarge = 413,

    /// <summary>
    /// 请求URI过长
    /// </summary>
    RequestUriTooLong = 414,

    /// <summary>
    /// 不支持的媒体类型
    /// </summary>
    UnsupportedMediaType = 415,

    /// <summary>
    /// 请求范围不满足
    /// </summary>
    RequestedRangeNotSatisfiable = 416,

    /// <summary>
    /// 期望失败
    /// </summary>
    ExpectationFailed = 417,

    /// <summary>
    /// 验证失败
    /// </summary>
    ValidationError = 422,

    /// <summary>
    /// 锁定
    /// </summary>
    Locked = 423,

    /// <summary>
    /// 依赖失败
    /// </summary>
    FailedDependency = 424,

    /// <summary>
    /// 升级必需
    /// </summary>
    UpgradeRequired = 426,

    /// <summary>
    /// 先决条件必需
    /// </summary>
    PreconditionRequired = 428,

    /// <summary>
    /// 请求过多
    /// </summary>
    TooManyRequests = 429,

    /// <summary>
    /// 请求头字段过大
    /// </summary>
    RequestHeaderFieldsTooLarge = 431,

    /// <summary>
    /// 服务器错误
    /// </summary>
    ServerError = 500,

    /// <summary>
    /// 未实现
    /// </summary>
    NotImplemented = 501,

    /// <summary>
    /// 网关错误
    /// </summary>
    BadGateway = 502,

    /// <summary>
    /// 服务不可用
    /// </summary>
    ServiceUnavailable = 503,

    /// <summary>
    /// 网关超时
    /// </summary>
    GatewayTimeout = 504,

    /// <summary>
    /// HTTP版本不支持
    /// </summary>
    HttpVersionNotSupported = 505,

    /// <summary>
    /// 变体协商
    /// </summary>
    VariantAlsoNegotiates = 506,

    /// <summary>
    /// 存储不足
    /// </summary>
    InsufficientStorage = 507,

    /// <summary>
    /// 循环检测
    /// </summary>
    LoopDetected = 508,

    /// <summary>
    /// 带宽限制超出
    /// </summary>
    BandwidthLimitExceeded = 509,

    /// <summary>
    /// 未扩展
    /// </summary>
    NotExtended = 510,

    /// <summary>
    /// 网络认证必需
    /// </summary>
    NetworkAuthenticationRequired = 511,
    #endregion

    #region 业务错误码（1000-1999）
    /// <summary>
    /// 参数错误
    /// </summary>
    ParameterError = 1000,

    /// <summary>
    /// 数据已存在
    /// </summary>
    DataExists = 1001,

    /// <summary>
    /// 数据不存在
    /// </summary>
    DataNotExists = 1002,

    /// <summary>
    /// 数据状态错误
    /// </summary>
    DataStatusError = 1003,

    /// <summary>
    /// 操作失败
    /// </summary>
    OperationFailed = 1004,

    /// <summary>
    /// 业务规则错误
    /// </summary>
    BusinessRuleError = 1005,

    /// <summary>
    /// 业务限制错误
    /// </summary>
    BusinessLimitError = 1006,

    /// <summary>
    /// 业务冲突错误
    /// </summary>
    BusinessConflictError = 1007,

    /// <summary>
    /// 业务依赖错误
    /// </summary>
    BusinessDependencyError = 1008,

    /// <summary>
    /// 业务过期错误
    /// </summary>
    BusinessExpiredError = 1009,

    /// <summary>
    /// 业务锁定错误
    /// </summary>
    BusinessLockedError = 1010,

    /// <summary>
    /// 业务权限错误
    /// </summary>
    BusinessPermissionError = 1011,

    /// <summary>
    /// 业务验证错误
    /// </summary>
    BusinessValidationError = 1012,

    /// <summary>
    /// 业务流程错误
    /// </summary>
    BusinessProcessError = 1013,

    /// <summary>
    /// 业务配置错误
    /// </summary>
    BusinessConfigError = 1014,

    /// <summary>
    /// 业务资源错误
    /// </summary>
    BusinessResourceError = 1015,

    /// <summary>
    /// 业务版本错误
    /// </summary>
    BusinessVersionError = 1016,

    /// <summary>
    /// 业务环境错误
    /// </summary>
    BusinessEnvironmentError = 1017,

    /// <summary>
    /// 业务集成错误
    /// </summary>
    BusinessIntegrationError = 1018,

    /// <summary>
    /// 业务安全错误
    /// </summary>
    BusinessSecurityError = 1019,
    #endregion

    #region 文件操作错误码（2000-2999）
    /// <summary>
    /// 文件上传失败
    /// </summary>
    FileUploadFailed = 2000,

    /// <summary>
    /// 文件下载失败
    /// </summary>
    FileDownloadFailed = 2001,

    /// <summary>
    /// 文件不存在
    /// </summary>
    FileNotExists = 2002,

    /// <summary>
    /// 文件格式错误
    /// </summary>
    FileFormatError = 2003,

    /// <summary>
    /// 文件大小超限
    /// </summary>
    FileSizeExceeded = 2004,

    /// <summary>
    /// 文件权限错误
    /// </summary>
    FilePermissionError = 2005,

    /// <summary>
    /// 文件损坏
    /// </summary>
    FileCorrupted = 2006,

    /// <summary>
    /// 文件被占用
    /// </summary>
    FileOccupied = 2007,

    /// <summary>
    /// 文件系统错误
    /// </summary>
    FileSystemError = 2008,

    /// <summary>
    /// 文件存储错误
    /// </summary>
    FileStorageError = 2009,

    /// <summary>
    /// 文件访问错误
    /// </summary>
    FileAccessError = 2010,

    /// <summary>
    /// 文件处理错误
    /// </summary>
    FileProcessError = 2011,

    /// <summary>
    /// 文件转换错误
    /// </summary>
    FileConvertError = 2012,

    /// <summary>
    /// 文件压缩错误
    /// </summary>
    FileCompressError = 2013,

    /// <summary>
    /// 文件解压错误
    /// </summary>
    FileDecompressError = 2014,

    /// <summary>
    /// 文件加密错误
    /// </summary>
    FileEncryptError = 2015,

    /// <summary>
    /// 文件解密错误
    /// </summary>
    FileDecryptError = 2016,

    /// <summary>
    /// 文件校验错误
    /// </summary>
    FileVerifyError = 2017,

    /// <summary>
    /// 文件同步错误
    /// </summary>
    FileSyncError = 2018,

    /// <summary>
    /// 文件备份错误
    /// </summary>
    FileBackupError = 2019,
    #endregion

    #region 网络相关错误码（3000-3999）
    /// <summary>
    /// 网络错误
    /// </summary>
    NetworkError = 3000,

    /// <summary>
    /// 超时
    /// </summary>
    Timeout = 3001,

    /// <summary>
    /// 连接错误
    /// </summary>
    ConnectionError = 3002,

    /// <summary>
    /// 断开连接
    /// </summary>
    Disconnected = 3003,

    /// <summary>
    /// 网络超时
    /// </summary>
    NetworkTimeout = 3004,

    /// <summary>
    /// 网络中断
    /// </summary>
    NetworkInterrupted = 3005,

    /// <summary>
    /// 网络拥塞
    /// </summary>
    NetworkCongested = 3006,

    /// <summary>
    /// 网络不可达
    /// </summary>
    NetworkUnreachable = 3007,

    /// <summary>
    /// 网络拒绝
    /// </summary>
    NetworkRefused = 3008,

    /// <summary>
    /// 网络重置
    /// </summary>
    NetworkReset = 3009,

    /// <summary>
    /// 网络重定向
    /// </summary>
    NetworkRedirect = 3010,

    /// <summary>
    /// 网络代理错误
    /// </summary>
    NetworkProxyError = 3011,

    /// <summary>
    /// 网络认证错误
    /// </summary>
    NetworkAuthError = 3012,

    /// <summary>
    /// 网络SSL错误
    /// </summary>
    NetworkSSLError = 3013,

    /// <summary>
    /// 网络DNS错误
    /// </summary>
    NetworkDNSError = 3014,

    /// <summary>
    /// 网络防火墙错误
    /// </summary>
    NetworkFirewallError = 3015,

    /// <summary>
    /// 网络负载均衡错误
    /// </summary>
    NetworkLoadBalanceError = 3016,

    /// <summary>
    /// 网络CDN错误
    /// </summary>
    NetworkCDNError = 3017,

    /// <summary>
    /// 网络VPN错误
    /// </summary>
    NetworkVPNError = 3018,

    /// <summary>
    /// 网络带宽错误
    /// </summary>
    NetworkBandwidthError = 3019,
    #endregion

    #region 系统服务错误码（4000-4999）
    /// <summary>
    /// 数据库错误
    /// </summary>
    DatabaseError = 4000,

    /// <summary>
    /// 缓存错误
    /// </summary>
    CacheError = 4001,

    /// <summary>
    /// 消息队列错误
    /// </summary>
    MessageQueueError = 4002,

    /// <summary>
    /// 搜索引擎错误
    /// </summary>
    SearchEngineError = 4003,

    /// <summary>
    /// 对象存储错误
    /// </summary>
    ObjectStorageError = 4004,

    /// <summary>
    /// 日志服务错误
    /// </summary>
    LogServiceError = 4005,

    /// <summary>
    /// 监控服务错误
    /// </summary>
    MonitorServiceError = 4006,

    /// <summary>
    /// 认证服务错误
    /// </summary>
    AuthServiceError = 4007,

    /// <summary>
    /// 授权服务错误
    /// </summary>
    AuthorizationServiceError = 4008,

    /// <summary>
    /// 配置服务错误
    /// </summary>
    ConfigServiceError = 4009,

    /// <summary>
    /// 注册中心错误
    /// </summary>
    RegistryServiceError = 4010,

    /// <summary>
    /// 网关服务错误
    /// </summary>
    GatewayServiceError = 4011,

    /// <summary>
    /// 负载均衡错误
    /// </summary>
    LoadBalanceServiceError = 4012,

    /// <summary>
    /// 服务发现错误
    /// </summary>
    ServiceDiscoveryError = 4013,

    /// <summary>
    /// 服务熔断错误
    /// </summary>
    ServiceCircuitBreakerError = 4014,

    /// <summary>
    /// 服务限流错误
    /// </summary>
    ServiceRateLimitError = 4015,

    /// <summary>
    /// 服务降级错误
    /// </summary>
    ServiceDegradationError = 4016,

    /// <summary>
    /// 服务重试错误
    /// </summary>
    ServiceRetryError = 4017,

    /// <summary>
    /// 服务超时错误
    /// </summary>
    ServiceTimeoutError = 4018,

    /// <summary>
    /// 服务熔断恢复错误
    /// </summary>
    ServiceCircuitBreakerRecoveryError = 4019,
    #endregion

    #region 系统状态错误码（5000-5999）
    /// <summary>
    /// 系统配置错误
    /// </summary>
    SystemConfigError = 5000,

    /// <summary>
    /// 系统维护中
    /// </summary>
    SystemMaintenance = 5001,

    /// <summary>
    /// 系统升级中
    /// </summary>
    SystemUpgrading = 5002,

    /// <summary>
    /// 系统过载
    /// </summary>
    SystemOverload = 5003,

    /// <summary>
    /// 系统资源不足
    /// </summary>
    SystemResourceInsufficient = 5004,

    /// <summary>
    /// 系统性能问题
    /// </summary>
    SystemPerformanceIssue = 5005,

    /// <summary>
    /// 系统安全警告
    /// </summary>
    SystemSecurityWarning = 5006,

    /// <summary>
    /// 系统异常
    /// </summary>
    SystemException = 5007,

    /// <summary>
    /// 系统崩溃
    /// </summary>
    SystemCrash = 5008,

    /// <summary>
    /// 系统恢复中
    /// </summary>
    SystemRecovering = 5009,

    /// <summary>
    /// 系统备份中
    /// </summary>
    SystemBackingUp = 5010,

    /// <summary>
    /// 系统还原中
    /// </summary>
    SystemRestoring = 5011,

    /// <summary>
    /// 系统清理中
    /// </summary>
    SystemCleaning = 5012,

    /// <summary>
    /// 系统优化中
    /// </summary>
    SystemOptimizing = 5013,

    /// <summary>
    /// 系统检查中
    /// </summary>
    SystemChecking = 5014,

    /// <summary>
    /// 系统修复中
    /// </summary>
    SystemRepairing = 5015,

    /// <summary>
    /// 系统重启中
    /// </summary>
    SystemRebooting = 5016,

    /// <summary>
    /// 系统关闭中
    /// </summary>
    SystemShuttingDown = 5017,

    /// <summary>
    /// 系统启动中
    /// </summary>
    SystemStartingUp = 5018,

    /// <summary>
    /// 系统初始化中
    /// </summary>
    SystemInitializing = 5019,
    #endregion

    #region 第三方服务错误码（6000-6999）
    /// <summary>
    /// 第三方服务错误
    /// </summary>
    ThirdPartyServiceError = 6000,

    /// <summary>
    /// 第三方服务超时
    /// </summary>
    ThirdPartyServiceTimeout = 6001,

    /// <summary>
    /// 第三方服务不可用
    /// </summary>
    ThirdPartyServiceUnavailable = 6002,

    /// <summary>
    /// 第三方服务限流
    /// </summary>
    ThirdPartyServiceRateLimit = 6003,

    /// <summary>
    /// 第三方服务配额超限
    /// </summary>
    ThirdPartyServiceQuotaExceeded = 6004,

    /// <summary>
    /// 第三方服务认证失败
    /// </summary>
    ThirdPartyServiceAuthFailed = 6005,

    /// <summary>
    /// 第三方服务授权失败
    /// </summary>
    ThirdPartyServiceAuthzFailed = 6006,

    /// <summary>
    /// 第三方服务参数错误
    /// </summary>
    ThirdPartyServiceParamError = 6007,

    /// <summary>
    /// 第三方服务响应错误
    /// </summary>
    ThirdPartyServiceResponseError = 6008,

    /// <summary>
    /// 第三方服务数据错误
    /// </summary>
    ThirdPartyServiceDataError = 6009,

    /// <summary>
    /// 第三方服务格式错误
    /// </summary>
    ThirdPartyServiceFormatError = 6010,

    /// <summary>
    /// 第三方服务版本不兼容
    /// </summary>
    ThirdPartyServiceVersionIncompatible = 6011,

    /// <summary>
    /// 第三方服务协议错误
    /// </summary>
    ThirdPartyServiceProtocolError = 6012,

    /// <summary>
    /// 第三方服务网络错误
    /// </summary>
    ThirdPartyServiceNetworkError = 6013,

    /// <summary>
    /// 第三方服务重试失败
    /// </summary>
    ThirdPartyServiceRetryFailed = 6014,

    /// <summary>
    /// 第三方服务熔断
    /// </summary>
    ThirdPartyServiceCircuitBreaker = 6015,

    /// <summary>
    /// 第三方服务降级
    /// </summary>
    ThirdPartyServiceDegradation = 6016,

    /// <summary>
    /// 第三方服务异常
    /// </summary>
    ThirdPartyServiceException = 6017,

    /// <summary>
    /// 第三方服务维护中
    /// </summary>
    ThirdPartyServiceMaintenance = 6018,

    /// <summary>
    /// 第三方服务升级中
    /// </summary>
    ThirdPartyServiceUpgrading = 6019,
    #endregion
  }
}