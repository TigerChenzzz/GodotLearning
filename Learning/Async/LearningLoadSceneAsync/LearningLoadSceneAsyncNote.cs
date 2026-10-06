using Godot;
using static GodotLearning.Helpers.EasyShowcase;
using GodotArray = Godot.Collections.Array;

namespace GodotLearning.Learning.Async.LearningLoadSceneAsync;

public class LearningLoadSceneAsyncNote {
    public static void Show() {
        {
            GetA(out string path);
            // 需要检查是否存在
            if (!ResourceLoader.Exists(path))
                return;
            #region params
            GetA(out string typeHint); // 默认 ""
            GetA(out bool useSubThreads); // 默认 false, 是否使用更多线程加载, 提高加载速度, 但可能影响主线程
            GetA(out ResourceLoader.CacheMode cacheMode); // 默认 Reuse
            #endregion
            // 请求加载资源
            ResourceLoader.LoadThreadedRequest(path, typeHint, useSubThreads, cacheMode);

            // 在 process 等地方查询进度:
            #region params
            // 通过 progress 数组查询进度数值
            // 默认 null, 表示不接收进度数值
            // 数组中会有一个 [0.0, 1.0] 的元素表示进度
            GetA(out GodotArray progress);
            #endregion
            var loadStatus = ResourceLoader.LoadThreadedGetStatus(path, progress);
            // 在判断成功后获取资源
            if (loadStatus == ResourceLoader.ThreadLoadStatus.Loaded)
            {
                // 若还在加载中, 它会堵塞线程直至加载完成
                Use<Resource>(ResourceLoader.LoadThreadedGet(path));
            }
            // 获取失败要进行错误处理
            else if (loadStatus is ResourceLoader.ThreadLoadStatus.Failed or ResourceLoader.ThreadLoadStatus.InvalidResource)
            {
                // ...
            }
        }
        #region ResourceLoader.CacheMode
        Use(ResourceLoader.CacheMode.Ignore); // 不缓存, 但是外部资源使用 Reuse
        Use(ResourceLoader.CacheMode.Reuse); // 使用缓存
        Use(ResourceLoader.CacheMode.Replace); // 用新加载的数据刷新现有实例, 若现有实例的类型不匹配, 则创建全新对象, 而外部资源使用 Reuse
        Use(ResourceLoader.CacheMode.IgnoreDeep); // 不缓存, 外部资源也不缓存
        Use(ResourceLoader.CacheMode.ReplaceDeep); // Replace, 同时外部资源也使用 Replace
        #endregion
        #region ResourceLoader.ThreadLoadStatus
        Use(ResourceLoader.ThreadLoadStatus.InvalidResource); // 资源非法, 或还没开始加载
        Use(ResourceLoader.ThreadLoadStatus.InProgress); // 正在进行中
        Use(ResourceLoader.ThreadLoadStatus.Failed); // 失败
        Use(ResourceLoader.ThreadLoadStatus.Loaded); // 成功
        #endregion
    }
}
