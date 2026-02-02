using System.Reflection;
using Hamfer.Kernel.Utils;

namespace Hamfer.Kernel.Services;

/// <summary>
/// The Env file loader and deserializer
/// </summary>
public class EnvLoader
{
  private const char ENV_FILE_NEW_LINE_CHAR = '\n';
  private const char ENV_FILE_QUTATION_CHAR = '\'';
  private const char ENV_FILE_DOUBLE_QUTATION_CHAR = '"';
  private const char ENV_FILE_COMMENT_CHAR = '#';
  private const char ENV_FILE_EQUAL_CHAR = '=';

  public const string ENVIRONMENT = nameof(EnvModelBase.ENVIRONMENT);
  public const string IS_DEV_KEY = nameof(EnvModelBase.IS_DEV);
  public const string IS_PROD_KEY = nameof(EnvModelBase.IS_PROD);
  public const string IS_TEST_KEY = nameof(EnvModelBase.IS_TEST);
  public const string IS_DEMO_KEY = nameof(EnvModelBase.IS_DEMO);

  string? file;
  string? rawContent;
  readonly List<(string key, string value)> keyValueContent;

  /// <summary>
  /// Create a new `.env` file loader
  /// </summary>
  public EnvLoader()
  {
    keyValueContent = [];
  }

  /// <summary>
  /// Load a `.env` file
  /// </summary>
  /// <param name="fileName">The name of file</param>
  /// <returns>Updated current `EnvLoader` after loading raw-content</returns>
  /// <exception cref="Exception">FileNotFoundException</exception>
  public async Task<EnvLoader> load(string fileName = ".env")
  {
    if (File.Exists(fileName))
    {
      this.file = fileName;
      string envExt = Path.GetExtension(fileName).ToLowerInvariant().TrimStart(".").ToString();
      if (Enum.TryParse(envExt, true, out EnvironmentEnum envEnum))
      {
        keyValueContent.Add((ENVIRONMENT, envExt));
        keyValueContent.Add((IS_DEV_KEY, envEnum == EnvironmentEnum.Dev || envEnum == EnvironmentEnum.Development ? "true" : "false"));
        keyValueContent.Add((IS_PROD_KEY, envEnum == EnvironmentEnum.Prod || envEnum == EnvironmentEnum.Production ? "true" : "false"));
        keyValueContent.Add((IS_TEST_KEY, envEnum == EnvironmentEnum.Test ? "true" : "false"));
        keyValueContent.Add((IS_DEMO_KEY, envEnum == EnvironmentEnum.Demo ? "true" : "false"));
      } else
      {
        keyValueContent.Add((ENVIRONMENT, EnvModelBase.ENVIRONMENT_NOTFOUND));
      }
    } else {
      this.file = Path.Join(IOHelper.Cwd(), fileName);
      if (File.Exists(this.file) == false)
      {
        throw new Exception($"File ({this.file}) not foune!");
      }
    }

    using FileStream fileStream = File.OpenRead(file);
    using StreamReader streamReader = new(fileStream, true);
    this.rawContent = await streamReader.ReadToEndAsync();

    return this;
  }

  /// <summary>
  /// Extract data from raw-Content
  /// </summary>
  /// <param name="removeQutations">removing Qutataions in values</param>
  /// <returns>Updated current `EnvLoader` after loading keyValueContent</returns>
  /// <exception cref="Exception"></exception>
  public EnvLoader extract(bool removeQutations = true)
  {
    if (this.rawContent == null)
    {
      throw new Exception("Unable to extract info from null content, please check that you already call `load` function.");
    }

    string currentKey = string.Empty;
    string currentValue = string.Empty;
    bool isComment = false;
    bool isValue = false;
    for (int i = 0; i <= this.rawContent.Length; i++)
    {
      char c = i == this.rawContent.Length ? ENV_FILE_NEW_LINE_CHAR : this.rawContent[i];
      switch (c)
      {
        case ENV_FILE_NEW_LINE_CHAR: // New Line
          {
            var key = currentKey.Trim();
            if (key.Length > 0)
            {
              string value = currentValue.Trim();
              if (removeQutations)
              {
                value = value.Trim(ENV_FILE_QUTATION_CHAR).Trim(ENV_FILE_DOUBLE_QUTATION_CHAR);
              }

              keyValueContent.Add((key, value));
            }

            currentKey = string.Empty;
            currentValue = string.Empty;
            isComment = false;
            isValue = false;
            break;
          }
        case ENV_FILE_COMMENT_CHAR: // Comment
          {
            isComment = true;
            break;
          }
        case ENV_FILE_EQUAL_CHAR: // Equal means *End of key*
          {
            isValue = true;
            break;
          }
        default:
          {
            if (isComment == false)
            {
              if (isValue)
              {
                currentValue+= c;
              } else
              {
                currentKey += c;
              }
            }
            break;
          }
      }
    }

    return this;
  }

  /// <summary>
  /// Map `keyValueContent` to a custom object
  /// </summary>
  /// <typeparam name="T">Type of custom object</typeparam>
  /// <param name="returnObject">The custom Object to return result based on it</param>
  /// <returns>Updated `returnObject` with matched to `keyValueContent`</returns>
  /// <exception cref="NotImplementedException">For some types we need implementations</exception>
  public T mapTo<T>(T returnObject)
  {
    if (this.keyValueContent == null)
    {
      this.extract();
    }

    object? prepareValue(string name, Type type) {
      var first = keyValueContent?.FirstOrDefault(w=> w.key.Equals(name, StringComparison.InvariantCultureIgnoreCase));
      if(first != null && first != default) {
      string? value = first?.value == string.Empty ? null : first?.value;
        if (value != null && type.Name != typeof(string).Name) {
          if (type.Name == typeof(int?).Name)
          {
            return Convert.ChangeType(value, type.GetGenericArguments()[0]);
          } else
          {
            throw new NotImplementedException();
          }
        } else
        {
          return value;
        }
      }
      return null;
    }

    if (returnObject != null) {
      FieldInfo[] fields = typeof(T).GetFields();
      PropertyInfo[] props = typeof(T).GetProperties();

      foreach (FieldInfo fi in fields)
      {
        fi.SetValue(returnObject, prepareValue(fi.Name, fi.FieldType));
      }

      foreach (PropertyInfo pi in props)
      {
        if (pi.CanWrite)
        {
          pi.SetValue(returnObject, prepareValue(pi.Name, pi.PropertyType));
        }
      }
    }

    return returnObject;
  }
}