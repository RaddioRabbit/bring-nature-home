# BringNatureHome

BringNatureHome 是一个面向 Meta Quest/Oculus 设备的 Unity VR 室内植物摆放原型。项目通过右手控制器射线在场景表面放置植物模型，并结合可抓取植物、植物信息面板和环境需求图标，探索“把自然带回家”的沉浸式空间布置体验。

<p>
  <img alt="Unity" src="https://img.shields.io/badge/Unity-2021_LTS%2B-000000?logo=unity&logoColor=white">
  <img alt="C Sharp" src="https://img.shields.io/badge/C%23-MonoBehaviour-512BD4?logo=csharp&logoColor=white">
  <img alt="Meta Quest" src="https://img.shields.io/badge/Meta_Quest-VR-0467DF?logo=meta&logoColor=white">
  <img alt="Meta XR" src="https://img.shields.io/badge/Meta_XR-OVRInput-0467DF?logo=meta&logoColor=white">
  <img alt="Interaction SDK" src="https://img.shields.io/badge/Interaction_SDK-Ray_Grab-2E7D32">
  <img alt="License" src="https://img.shields.io/badge/license-MIT-green">
</p>

> English README: [README.en.md](README.en.md)

---

## 目录

- [项目状态](#项目状态)
- [主要功能](#主要功能)
- [技术栈](#技术栈)
- [目录结构](#目录结构)
- [安装与运行](#安装与运行)
- [操作说明](#操作说明)
- [脚本说明](#脚本说明)
- [资源说明](#资源说明)
- [二次开发建议](#二次开发建议)
- [已知注意事项](#已知注意事项)
- [贡献](#贡献)
- [License](#license)

---

## 项目状态

当前仓库主要包含 Unity 的 `Assets` 内容，包括场景、植物预制体、脚本、面板模型和材质。仓库中未包含完整 Unity 工程常见的 `ProjectSettings/`、`Packages/`、`Library/` 等目录，因此首次运行时需要在本地 Unity 工程中导入这些资源，并补齐 Meta XR 相关依赖。

## 主要功能

- VR 场景：`Assets/Scenes/MasterWork1.unity`
- 植物放置：右手控制器发射射线，命中可碰撞表面后生成指定植物
- 植物移除：通过右手控制器按键销毁指定对象
- 可交互植物：植物预制体包含碰撞体、刚体和 Interaction SDK 的 `ISDK_RayGrabInteraction` 配置
- 植物资产：包含龟背竹、白掌、虎尾兰和仙人掌 4 类植物
- 信息 UI：场景中包含植物信息、温度、日照、浇水等面板或图标对象

## 技术栈

> 表中所列为当前仓库资源、脚本和 Unity 场景序列化内容中可确认的技术选型。由于仓库未包含 `ProjectSettings/` 与 `Packages/manifest.json`，依赖版本需要在本地 Unity 工程中重新锁定。

| 分类 | 选型 |
|------|------|
| **运行引擎** | Unity 3D（建议 Unity 2021 LTS 或更新版本；当前仓库未提供可精确确认的 Unity 版本锁定文件） |
| **目标平台** | Meta Quest / Oculus VR 设备，面向 Android 真机构建与头显运行 |
| **输入系统** | Meta XR / Oculus `OVRInput`，右手 Touch 控制器射线、食指扳机键 `PrimaryIndexTrigger`、`Button.One` 按键 |
| **交互框架** | Meta XR Interaction SDK，植物预制体和场景中包含 `ISDK_RayGrabInteraction` 射线抓取交互配置 |
| **业务脚本** | C# `MonoBehaviour`：`SpawnPlant2.cs` 负责射线命中点实例化植物，`DestroyPlant1.cs` 负责按键销毁绑定对象 |
| **场景与资源** | Unity Scene / Prefab / Material / FBX：`MasterWork1.unity`、4 个植物预制体、`Panel2.fbx` 面板模型和 3 个面板材质 |
| **UI 与文本** | Unity UI + TextMeshPro；场景中包含 `PlantInfo`、温度、日照、浇水等信息面板或图标对象 |
| **物理交互** | Unity Physics：植物预制体包含 Collider / Rigidbody，用于射线命中、抓取和基础碰撞 |
| **构建依赖** | Android Build Support、Meta XR SDK/Oculus Integration、Meta XR Interaction SDK、TextMeshPro |
| **仓库形态** | 当前为 Unity `Assets` 资源子集，不是完整 Unity 工程；需要补齐 `ProjectSettings/`、`Packages/` 后再稳定复现 |

## 目录结构

```text
.
├── Assets
│   ├── Material
│   │   ├── BigPanelMat.mat
│   │   ├── HoverPartPanelMat.mat
│   │   └── PartPanelMat.mat
│   ├── Model
│   │   └── Panel2.fbx
│   ├── Prefabs
│   │   ├── Plant_Cactus.prefab
│   │   ├── Plant_Monstera_Deliciosa.prefab
│   │   ├── Plant_Sansevieria.prefab
│   │   └── Plant_Spathiphyllum.prefab
│   ├── Scenes
│   │   └── MasterWork1.unity
│   └── Scripts
│       ├── DestroyPlant1.cs
│       └── SpawnPlant2.cs
├── README.md
└── README.en.md
```

## 安装与运行

### 环境要求

- Unity 2021 LTS 或更新版本
- Meta Quest/Oculus 头显与 Touch 控制器
- Android Build Support（如果需要部署到 Quest 真机）
- Meta XR SDK 或 Oculus Integration
- Meta XR Interaction SDK（场景和预制体中使用了 `ISDK_RayGrabInteraction`）
- TextMeshPro（场景中存在 TMP 文本对象）

由于仓库没有 `Packages/manifest.json`，具体依赖版本需要根据本地 Unity 工程重新安装并解析。

### 导入与部署

1. 新建或打开一个 Unity 3D 工程。
2. 将本仓库的 `Assets/` 目录复制到 Unity 工程根目录，或把仓库作为工程资源目录导入。
3. 通过 Unity Package Manager 或 Asset Store 安装 Meta XR SDK/Oculus Integration 与 Interaction SDK。
4. 打开 `Assets/Scenes/MasterWork1.unity`。
5. 如果 Unity 提示脚本或包缺失，先完成 Meta XR、Interaction SDK 和 TextMeshPro 的导入，再重新打开场景。
6. 在 `Build Settings` 中切换到 Android 平台，并按 Meta Quest 项目要求配置 XR Plug-in、包名、权限和渲染设置。
7. 连接 Quest 设备后，使用 `Build And Run` 部署测试。

## 操作说明

- 使用右手控制器指向目标表面。
- 按右手食指扳机键（`PrimaryIndexTrigger`）在射线命中的位置生成植物。
- 按右手 `Button.One` 按键销毁绑定到脚本的目标对象；在 Quest 右手柄上通常对应 A 键。
- 场景中的植物预制体带有碰撞体和交互组件，可用于射线抓取或进一步扩展手柄交互。

## 脚本说明

### `SpawnPlant2.cs`

`SpawnPlant2` 每帧根据右手控制器的位置和朝向创建射线。如果射线命中物体，并且用户按下右手食指扳机键，就在命中点实例化 `objectToToggle` 指向的植物预制体。

核心逻辑：

```csharp
Ray ray = new Ray(
    OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch),
    OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward
);
```

### `DestroyPlant1.cs`

`DestroyPlant1` 监听右手控制器 `Button.One` 按键，并销毁 `objectToToggle` 引用的对象。适合用于按钮面板、植物对象或测试场景中的快速移除交互。

## 资源说明

| 类型 | 文件 | 说明 |
| --- | --- | --- |
| 场景 | `Assets/Scenes/MasterWork1.unity` | 主 VR 场景，包含控制器、UI 面板和植物交互配置 |
| 植物预制体 | `Assets/Prefabs/Plant_Monstera_Deliciosa.prefab` | 龟背竹 |
| 植物预制体 | `Assets/Prefabs/Plant_Spathiphyllum.prefab` | 白掌 |
| 植物预制体 | `Assets/Prefabs/Plant_Sansevieria.prefab` | 虎尾兰 |
| 植物预制体 | `Assets/Prefabs/Plant_Cactus.prefab` | 仙人掌 |
| 模型 | `Assets/Model/Panel2.fbx` | 信息或选择面板模型 |
| 材质 | `Assets/Material/*.mat` | 面板常规、悬停和背景材质 |

## 二次开发建议

- 为不同植物建立独立的数据配置，例如名称、光照、温度、浇水频率和展示图标。
- 将生成、删除、选择植物的逻辑拆成更明确的控制器输入模块，便于维护多植物选择面板。
- 给生成的植物设置统一父节点，方便批量保存、清空或导出房间布置结果。
- 增加空间检测和碰撞校验，避免植物生成在不可放置区域或相互重叠。
- 补充完整 Unity 工程文件，尤其是 `ProjectSettings/` 与 `Packages/manifest.json`，让新开发者可以直接打开工程。

## 已知注意事项

- 当前仓库不是完整 Unity 工程，只包含资源子集。
- 缺少 `.meta` 文件时，Unity 可能重新生成 GUID，导致场景或预制体中的脚本引用需要手动修复。
- 脚本依赖 `OVRInput`，未安装 Meta XR/Oculus 相关包会导致编译失败。
- 场景中存在 Interaction SDK 和 TextMeshPro 对象，缺少相关包时会出现 Missing Script 或 Missing Component。

## 贡献

1. Fork 本仓库。
2. 基于具体功能创建分支，例如 `feat/plant-selector` 或 `fix/spawn-placement`。
3. 提交前在 Unity 中打开 `MasterWork1.unity`，确认没有 Missing Script、Missing Prefab 或编译错误。
4. 提交 Pull Request，并说明测试设备、Unity 版本和 Meta XR SDK 版本。

## License

本项目代码采用 MIT License，完整许可证文本见 [LICENSE](LICENSE)。

请注意：MIT License 仅适用于本仓库中由项目作者提供的代码与文档。Unity、Meta XR/Oculus SDK、Interaction SDK、TextMeshPro 以及任何第三方模型、素材或商标仍受其各自许可证和使用条款约束。
