namespace GodotLearning.Helpers;

/// <summary>
/// 此方法的类不能作为实际作用, 只为代码演示用法的目的
/// </summary>
public class EasyShowcase {
    /// <summary>
    /// 用于表示从某些地方获取一个类型<typeparamref name="T"/>的实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetA<T>() => default!;
    /// <summary>
    /// 用于表示从某些地方获取一个类型<typeparamref name="T"/>的实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    public static void GetA<T>(out T t) => t = default!;
    /// <summary>
    /// 用于消耗掉一个值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    public static void Use<T>(T t) => _ = t;
}
