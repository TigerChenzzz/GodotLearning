namespace GodotLearning.Helpers;

/// <summary>
/// 此方法的类不能作为实际作用, 只为代码演示用法的目的
/// </summary>
public class EasyShowcase {
    /// <summary>
    /// 用于表示从某些地方获取一个类型 <typeparamref name="T"/> 的实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetA<T>() => default!;
    /// <summary>
    /// 用于表示从某些地方获取一个类型 <typeparamref name="T"/> 的实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    public static void GetA<T>(out T t) => t = default!;
    /// <summary>
    /// 用于表示从某些地方获取一个类型 <typeparamref name="T1"/> 的实例
    /// 和一个类型 <typeparamref name="T2"/> 的实例
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    public static void Gets<T1, T2>(out T1 t1, out T2 t2) => (t1, t2) = (default!, default!);
    /// <summary>
    /// 用于消耗掉一个类型 <typeparamref name="T"/> 的值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    public static void Use<T>(T t) => _ = t;
}
