namespace Hamfer.Kernel.Services;

public abstract class EnvModelBase
{
  public const string ENVIRONMENT_NOTFOUND = "NOT_FOUND";

  public string ENVIRONMENT { get; set; }
  public bool? IS_DEV { get; set; }
  public bool? IS_PROD { get; set; }
  public bool? IS_TEST { get; set; }
  public bool? IS_DEMO { get; set; }
}