using Godot;
using System;
using static GodotLearning.Helpers.EasyShowcase;

using GodotArrayOfDictionary = Godot.Collections.Array<Godot.Collections.Dictionary>;

namespace GodotLearning.Learning.Physics.LearningPhysicsServer;

public class LearningPhysicsServerNote {
    public static Type TheType2D { get; } = typeof(PhysicsServer2D);
    public static Type TheType3D { get; } = typeof(PhysicsServer3D);

    public static void SimpleUsage() {
        #region 创建
        var spaceRid = PhysicsServer2D.SpaceCreate(); // 创建一个空间
        var shapeRid = PhysicsServer2D.RectangleShapeCreate(); // 创建一个形状
        var bodyRid = PhysicsServer2D.BodyCreate(); // 创建一个物体
        var areaRid = PhysicsServer2D.AreaCreate(); // 常见一个区域
        #endregion
        #region 初始化
        {
            PhysicsServer2D.BodySetSpace(bodyRid, spaceRid);
            PhysicsServer2D.AreaSetSpace(areaRid, spaceRid);
            PhysicsServer2D.BodyAddShape(bodyRid, shapeRid); // 包括可选的 transform 和 disabled 参数
            PhysicsServer2D.AreaAddShape(areaRid, shapeRid); // 包括可选的 transform 和 disabled 参数
        }
        #endregion
        #region 设置
        {
            #region args
            bool active = true;
            float bodyTimeToSleep = 5;
            GetA(out Transform2D transform);
            GetA(out Vector2 linearVelocity);
            int shapeIndex = 0;
            #endregion
            PhysicsServer2D.SpaceSetActive(spaceRid, active);
            PhysicsServer2D.SpaceSetParam(spaceRid, PhysicsServer2D.SpaceParameter.BodyTimeToSleep, bodyTimeToSleep);

            PhysicsServer2D.ShapeSetData(shapeRid, new Vector2(10, 10));

            PhysicsServer2D.BodySetMode(bodyRid, PhysicsServer2D.BodyMode.Rigid); // rigid, kinematic, static, rigid linear
            PhysicsServer2D.BodySetParam(bodyRid, PhysicsServer2D.BodyParameter.GravityScale, 1f);
            PhysicsServer2D.BodySetState(bodyRid, PhysicsServer2D.BodyState.Transform, transform);
            PhysicsServer2D.BodySetState(bodyRid, PhysicsServer2D.BodyState.LinearVelocity, linearVelocity);
            PhysicsServer2D.BodySetShapeTransform(bodyRid, shapeIndex, transform);
        }
        #endregion
        #region 获取
        {
            float bodyTimeToSleep = PhysicsServer2D.SpaceGetParam(spaceRid, PhysicsServer2D.SpaceParameter.BodyTimeToSleep);
            PhysicsDirectSpaceState2D spaceState = PhysicsServer2D.SpaceGetDirectState(spaceRid);
            #region spaceState.IntersectPoint
            {
                PhysicsPointQueryParameters2D query = new() {
                    Position = new(5, 5),
                    CollideWithAreas = true,
                    CollideWithBodies = true,
                    CollisionMask = ~0u, // 默认即包含所有层
                };
                int maxResults = 32; // default
                GodotArrayOfDictionary result = spaceState.IntersectPoint(query, maxResults);
                foreach (var dictionary in result) {
                    var collider = dictionary["collider"];
                    var colliderId = dictionary["collider_id"];
                    var colliderRid = dictionary["rid"];
                    var colliderShapeIndex = dictionary["shape"]; 
                    Use<object[]>([collider, colliderId, colliderRid, colliderShapeIndex]);
                }
            }
            #endregion
            Use<object[]>([bodyTimeToSleep]);
        }
        #endregion
        #region 释放
        PhysicsServer2D.FreeRid(spaceRid);
        PhysicsServer2D.FreeRid(shapeRid);
        PhysicsServer2D.FreeRid(bodyRid);
        PhysicsServer2D.FreeRid(areaRid);
        #endregion
    }
}
