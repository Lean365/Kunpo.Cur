// -----------------------------------------------------------------------
// <copyright file="KpSerializerHelper.cs" company="昆珀科技">
// Copyright (c) 昆珀科技. All rights reserved.
// </copyright>
// <author>昆珀科技</author>
// <date>2024-03-21</date>
// <summary>通用序列化工具类</summary>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Kunpo.Cur.Common.Utils
{
  /// <summary>
  /// 通用序列化工具类
  /// </summary>
  public static class KpSerializerHelper
  {
    #region 默认配置

    private static readonly JsonSerializerSettings DefaultSettings = new JsonSerializerSettings
    {
      Formatting = Formatting.Indented,
      NullValueHandling = NullValueHandling.Ignore,
      ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
      DateFormatString = "yyyy-MM-dd HH:mm:ss",
      FloatParseHandling = FloatParseHandling.Decimal,
      FloatFormatHandling = FloatFormatHandling.String,
      Converters = new List<JsonConverter>
            {
                new StringEnumConverter(),
                new IsoDateTimeConverter(),
                new DecimalConverter(),
                new SnowflakeIdConverter()
            }
    };

    private static readonly Newtonsoft.Json.JsonSerializer DefaultSerializer = Newtonsoft.Json.JsonSerializer.Create(DefaultSettings);

    #endregion 默认配置

    #region 序列化

    /// <summary>
    /// 序列化为JSON字符串
    /// </summary>
    public static string? Serialize<T>(T? value, JsonSerializerSettings? settings = null)
    {
      if (value == null) return null;
      settings ??= DefaultSettings;
      return JsonConvert.SerializeObject(value, settings);
    }

    /// <summary>
    /// 序列化为JSON字符串（使用自定义格式化）
    /// </summary>
    public static string? Serialize<T>(T? value, bool indented = true, bool ignoreNull = true)
    {
      if (value == null) return null;
      var settings = new JsonSerializerSettings
      {
        Formatting = indented ? Formatting.Indented : Formatting.None,
        NullValueHandling = ignoreNull ? NullValueHandling.Ignore : NullValueHandling.Include,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        DateFormatString = "yyyy-MM-dd HH:mm:ss",
        FloatParseHandling = FloatParseHandling.Decimal,
        FloatFormatHandling = FloatFormatHandling.String,
        Converters = new List<JsonConverter>
                {
                    new StringEnumConverter(),
                    new IsoDateTimeConverter(),
                    new DecimalConverter()
                }
      };
      return JsonConvert.SerializeObject(value, settings);
    }

    /// <summary>
    /// 序列化为JSON字符串（使用自定义格式化选项）
    /// </summary>
    public static string? Serialize<T>(T? value, Action<JsonSerializerSettings>? configure = null)
    {
      if (value == null) return null;
      var settings = new JsonSerializerSettings
      {
        FloatParseHandling = FloatParseHandling.Decimal,
        FloatFormatHandling = FloatFormatHandling.String,
        Converters = new List<JsonConverter>
                {
                    new StringEnumConverter(),
                    new IsoDateTimeConverter(),
                    new DecimalConverter()
                }
      };
      configure?.Invoke(settings);
      return JsonConvert.SerializeObject(value, settings);
    }

    /// <summary>
    /// 序列化到文件
    /// </summary>
    public static void SerializeToFile<T>(T? value, string filePath, JsonSerializerSettings? settings = null)
    {
      if (value == null) throw new ArgumentNullException(nameof(value));
      if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("文件路径不能为空", nameof(filePath));

      settings ??= DefaultSettings;
      var json = JsonConvert.SerializeObject(value, settings);
      File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// 序列化到流
    /// </summary>
    public static void SerializeToStream<T>(T? value, Stream stream, JsonSerializerSettings? settings = null)
    {
      if (value == null) throw new ArgumentNullException(nameof(value));
      if (stream == null) throw new ArgumentNullException(nameof(stream));

      settings ??= DefaultSettings;
      using var writer = new JsonTextWriter(new StreamWriter(stream));
      DefaultSerializer.Serialize(writer, value);
    }

    /// <summary>
    /// 序列化为JSON字符串
    /// </summary>
    public static string? SerializeToJson<T>(T? data)
    {
      if (data == null) return null;
      return JsonConvert.SerializeObject(data, DefaultSettings);
    }

    #endregion 序列化

    #region 反序列化

    /// <summary>
    /// 反序列化
    /// </summary>
    public static T? Deserialize<T>(string? json, JsonSerializerSettings? settings = null)
    {
      if (string.IsNullOrEmpty(json)) return default;
      settings ??= DefaultSettings;
      return JsonConvert.DeserializeObject<T>(json, settings);
    }

    /// <summary>
    /// 反序列化（使用自定义格式化）
    /// </summary>
    public static T? Deserialize<T>(string? json, bool ignoreNull = true)
    {
      if (string.IsNullOrEmpty(json)) return default;
      var settings = new JsonSerializerSettings
      {
        NullValueHandling = ignoreNull ? NullValueHandling.Ignore : NullValueHandling.Include,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        DateFormatString = "yyyy-MM-dd HH:mm:ss",
        FloatParseHandling = FloatParseHandling.Decimal,
        FloatFormatHandling = FloatFormatHandling.String,
        Converters = new List<JsonConverter>
                {
                    new StringEnumConverter(),
                    new IsoDateTimeConverter(),
                    new DecimalConverter()
                }
      };
      return JsonConvert.DeserializeObject<T>(json, settings);
    }

    /// <summary>
    /// 反序列化（使用自定义格式化选项）
    /// </summary>
    public static T? Deserialize<T>(string? json, Action<JsonSerializerSettings>? configure = null)
    {
      if (string.IsNullOrEmpty(json)) return default;
      var settings = new JsonSerializerSettings
      {
        FloatParseHandling = FloatParseHandling.Decimal,
        FloatFormatHandling = FloatFormatHandling.String,
        Converters = new List<JsonConverter>
                {
                    new StringEnumConverter(),
                    new IsoDateTimeConverter(),
                    new DecimalConverter()
                }
      };
      configure?.Invoke(settings);
      return JsonConvert.DeserializeObject<T>(json, settings);
    }

    /// <summary>
    /// 从文件反序列化
    /// </summary>
    public static T? DeserializeFromFile<T>(string filePath, JsonSerializerSettings? settings = null)
    {
      if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("文件路径不能为空", nameof(filePath));
      if (!File.Exists(filePath)) throw new FileNotFoundException("找不到文件", filePath);

      settings ??= DefaultSettings;
      var json = File.ReadAllText(filePath);
      return JsonConvert.DeserializeObject<T>(json, settings);
    }

    /// <summary>
    /// 从流反序列化
    /// </summary>
    public static T? DeserializeFromStream<T>(Stream stream, JsonSerializerSettings? settings = null)
    {
      if (stream == null) throw new ArgumentNullException(nameof(stream));

      settings ??= DefaultSettings;
      using var reader = new JsonTextReader(new StreamReader(stream));
      return DefaultSerializer.Deserialize<T>(reader);
    }

    /// <summary>
    /// 从JSON字符串反序列化
    /// </summary>
    public static T? DeserializeFromJson<T>(string? json)
    {
      if (string.IsNullOrEmpty(json)) return default;
      return JsonConvert.DeserializeObject<T>(json, DefaultSettings);
    }

    #endregion 反序列化

    #region JSON操作

    /// <summary>
    /// 获取JSON值
    /// </summary>
    public static T? GetValue<T>(string? json, string? path, T? defaultValue = default)
    {
      if (string.IsNullOrEmpty(json)) return defaultValue;
      if (string.IsNullOrEmpty(path)) return defaultValue;

      try
      {
        var token = JToken.Parse(json);
        var value = token.SelectToken(path);
        if (value == null) return defaultValue;

        return value.ToObject<T>();
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// 设置JSON值
    /// </summary>
    public static string? SetValue<T>(string? json, string? path, T? value)
    {
      if (string.IsNullOrEmpty(json)) return null;
      if (string.IsNullOrEmpty(path)) return json;

      try
      {
        var token = JToken.Parse(json);
        var target = token.SelectToken(path);
        if (target == null) return json;

        var newToken = JToken.FromObject(value ?? default(T)!);
        target.Replace(newToken);
        return token.ToString();
      }
      catch
      {
        return json;
      }
    }

    /// <summary>
    /// 合并JSON
    /// </summary>
    public static string? Merge(string? json1, string? json2)
    {
      if (string.IsNullOrEmpty(json1)) return json2;
      if (string.IsNullOrEmpty(json2)) return json1;

      try
      {
        var token1 = JToken.Parse(json1);
        var token2 = JToken.Parse(json2);

        if (token1 is JObject obj1 && token2 is JObject obj2)
        {
          obj1.Merge(obj2);
          return obj1.ToString();
        }
        return json1;
      }
      catch
      {
        return json1;
      }
    }

    /// <summary>
    /// 验证JSON是否有效
    /// </summary>
    public static bool IsValidJson(string? json)
    {
      if (string.IsNullOrEmpty(json)) return false;

      try
      {
        JToken.Parse(json);
        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// 格式化JSON
    /// </summary>
    public static string? Format(string? json)
    {
      if (string.IsNullOrEmpty(json)) return null;

      try
      {
        var token = JToken.Parse(json);
        return token.ToString(Formatting.Indented);
      }
      catch
      {
        return json;
      }
    }

    /// <summary>
    /// 压缩JSON
    /// </summary>
    public static string? Compress(string? json)
    {
      if (string.IsNullOrEmpty(json)) return null;

      try
      {
        var token = JToken.Parse(json);
        return token.ToString(Formatting.None);
      }
      catch
      {
        return json;
      }
    }

    #endregion JSON操作

    #region 雪花ID操作

    /// <summary>
    /// 序列化雪花ID
    /// </summary>
    public static string? SerializeSnowflakeId(long id)
    {
      return id.ToString();
    }

    /// <summary>
    /// 反序列化雪花ID
    /// </summary>
    public static long DeserializeSnowflakeId(string? id)
    {
      if (string.IsNullOrEmpty(id)) return 0;
      return long.TryParse(id, out var result) ? result : 0;
    }

    /// <summary>
    /// 验证雪花ID是否有效
    /// </summary>
    public static bool IsValidSnowflakeId(long id)
    {
      return id > 0;
    }

    /// <summary>
    /// 验证雪花ID是否有效
    /// </summary>
    public static bool IsValidSnowflakeId(string? id)
    {
      if (string.IsNullOrEmpty(id)) return false;
      return long.TryParse(id, out var result) && result > 0;
    }

    #endregion 雪花ID操作

    public class ValueToStringConverter : JsonConverter
    {
      public override bool CanConvert(Type objectType)
      {
        return true;
      }

      public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
      {
        if (reader.TokenType == JsonToken.Null) return null;
        return reader.Value?.ToString();
      }

      public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
      {
        if (value == null)
        {
          writer.WriteNull();
        }
        else
        {
          writer.WriteValue(value.ToString());
        }
      }
    }
  }

  /// <summary>
  /// 高精度数值转换器
  /// </summary>
  public class DecimalConverter : JsonConverter<decimal>
  {
    public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null) return 0;
      if (reader.TokenType == JsonToken.String)
      {
        var str = reader.Value?.ToString();
        if (string.IsNullOrEmpty(str)) return 0;
        return decimal.TryParse(str, out var result) ? result : 0;
      }
      return Convert.ToDecimal(reader.Value);
    }

    public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
    {
      writer.WriteValue(value.ToString("0.00"));
    }
  }

  /// <summary>
  /// 雪花ID转换器
  /// </summary>
  public class SnowflakeIdConverter : JsonConverter<long>
  {
    public override long ReadJson(JsonReader reader, Type objectType, long existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null) return 0;
      if (reader.TokenType == JsonToken.String)
      {
        var str = reader.Value?.ToString();
        if (string.IsNullOrEmpty(str)) return 0;
        return long.TryParse(str, out var result) ? result : 0;
      }
      return Convert.ToInt64(reader.Value);
    }

    public override void WriteJson(JsonWriter writer, long value, JsonSerializer serializer)
    {
      writer.WriteValue(value.ToString());
    }
  }
}