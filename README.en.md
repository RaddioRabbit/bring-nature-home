# BringNatureHome

BringNatureHome is a Unity VR prototype for arranging indoor plants in a Meta Quest/Oculus environment. The experience uses a right-hand controller ray to place plant models onto scene surfaces, combines grabbable plant prefabs with plant information panels, and explores an immersive "bring nature home" interior placement workflow.

<p>
  <img alt="Unity" src="https://img.shields.io/badge/Unity-2021_LTS%2B-000000?logo=unity&logoColor=white">
  <img alt="C Sharp" src="https://img.shields.io/badge/C%23-MonoBehaviour-512BD4?logo=csharp&logoColor=white">
  <img alt="Meta Quest" src="https://img.shields.io/badge/Meta_Quest-VR-0467DF?logo=meta&logoColor=white">
  <img alt="Meta XR" src="https://img.shields.io/badge/Meta_XR-OVRInput-0467DF?logo=meta&logoColor=white">
  <img alt="Interaction SDK" src="https://img.shields.io/badge/Interaction_SDK-Ray_Grab-2E7D32">
  <img alt="License" src="https://img.shields.io/badge/license-MIT-green">
</p>

> Chinese README: [README.md](README.md)

---

## Table of Contents

- [Project Status](#project-status)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Setup and Run](#setup-and-run)
- [Controls](#controls)
- [Scripts](#scripts)
- [Assets](#assets)
- [Development Notes](#development-notes)
- [Known Notes](#known-notes)
- [Contributing](#contributing)
- [License](#license)

---

## Project Status

This repository mainly contains Unity `Assets`: one scene, plant prefabs, C# scripts, panel models, and materials. It does not include the common full Unity project folders such as `ProjectSettings/`, `Packages/`, or `Library/`. To run it reliably, import these assets into a local Unity project and install the required Meta XR dependencies.

## Features

- VR scene: `Assets/Scenes/MasterWork1.unity`
- Plant placement: cast a ray from the right controller and instantiate a selected plant at the hit point
- Plant removal: destroy a bound target object through a right-controller button press
- Grabbable plants: plant prefabs include colliders, rigidbodies, and Interaction SDK `ISDK_RayGrabInteraction` configuration
- Plant assets: includes Monstera Deliciosa, Spathiphyllum, Sansevieria, and Cactus prefabs
- Information UI: the scene contains plant information, temperature, sunlight, and watering-related panel or icon objects

## Tech Stack

> The entries below are based on what can be confirmed from the current assets, scripts, and serialized Unity scene files. Because this repository does not include `ProjectSettings/` or `Packages/manifest.json`, exact dependency versions need to be locked again in the local Unity project.

| Category | Choice |
|----------|--------|
| **Runtime Engine** | Unity 3D, recommended Unity 2021 LTS or newer. The repository does not include a version lock file that can confirm the exact Unity editor version. |
| **Target Platform** | Meta Quest / Oculus VR devices, with Android build and headset deployment in mind. |
| **Input System** | Meta XR / Oculus `OVRInput`: right Touch controller ray, `PrimaryIndexTrigger`, and `Button.One`. |
| **Interaction Framework** | Meta XR Interaction SDK. Plant prefabs and the scene include `ISDK_RayGrabInteraction` ray-grab configuration. |
| **Gameplay Scripts** | C# `MonoBehaviour`: `SpawnPlant2.cs` instantiates plants at raycast hit points, and `DestroyPlant1.cs` destroys a bound target object. |
| **Scene and Assets** | Unity Scene / Prefab / Material / FBX: `MasterWork1.unity`, 4 plant prefabs, `Panel2.fbx`, and 3 panel materials. |
| **UI and Text** | Unity UI + TextMeshPro. The scene contains `PlantInfo`, temperature, sunlight, watering, and related panel/icon objects. |
| **Physics** | Unity Physics. Plant prefabs include Collider / Rigidbody components for ray hits, grabbing, and basic collisions. |
| **Build Dependencies** | Android Build Support, Meta XR SDK/Oculus Integration, Meta XR Interaction SDK, and TextMeshPro. |
| **Repository Shape** | Unity `Assets` subset only, not a complete Unity project. Add `ProjectSettings/` and `Packages/` for stable reproduction. |

## Project Structure

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

## Setup and Run

### Requirements

- Unity 2021 LTS or newer
- Meta Quest/Oculus headset and Touch controllers
- Android Build Support, if deploying to a Quest device
- Meta XR SDK or Oculus Integration
- Meta XR Interaction SDK, because the scene and prefabs use `ISDK_RayGrabInteraction`
- TextMeshPro, because the scene contains TMP text objects

Because this repository has no `Packages/manifest.json`, dependency versions must be installed and resolved in the local Unity project.

### Import and Deploy

1. Create or open a Unity 3D project.
2. Copy this repository's `Assets/` directory into the Unity project root, or import the repository as the project's asset folder.
3. Install Meta XR SDK/Oculus Integration and Interaction SDK through Unity Package Manager or Asset Store.
4. Open `Assets/Scenes/MasterWork1.unity`.
5. If Unity reports missing scripts or packages, finish importing Meta XR, Interaction SDK, and TextMeshPro, then reopen the scene.
6. Switch `Build Settings` to Android and configure XR Plug-in, package name, permissions, and rendering settings for Meta Quest.
7. Connect a Quest device and use `Build And Run` for device testing.

## Controls

- Aim the right controller at a target surface.
- Press the right index trigger (`PrimaryIndexTrigger`) to spawn a plant at the raycast hit point.
- Press right-controller `Button.One` to destroy the object bound to the script. On Quest right Touch controllers, this is usually the A button.
- Plant prefabs include colliders and interaction components, so they can be used for ray grabbing or extended controller interactions.

## Scripts

### `SpawnPlant2.cs`

`SpawnPlant2` creates a ray each frame from the right controller position and rotation. When the ray hits an object and the user presses the right index trigger, it instantiates the plant prefab assigned to `objectToToggle` at the hit point.

Core logic:

```csharp
Ray ray = new Ray(
    OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch),
    OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward
);
```

### `DestroyPlant1.cs`

`DestroyPlant1` listens for right-controller `Button.One` and destroys the object referenced by `objectToToggle`. It can be used for panel buttons, plant objects, or quick removal interactions in test scenes.

## Assets

| Type | File | Description |
|------|------|-------------|
| Scene | `Assets/Scenes/MasterWork1.unity` | Main VR scene with controllers, UI panels, and plant interaction setup. |
| Plant Prefab | `Assets/Prefabs/Plant_Monstera_Deliciosa.prefab` | Monstera Deliciosa. |
| Plant Prefab | `Assets/Prefabs/Plant_Spathiphyllum.prefab` | Spathiphyllum. |
| Plant Prefab | `Assets/Prefabs/Plant_Sansevieria.prefab` | Sansevieria. |
| Plant Prefab | `Assets/Prefabs/Plant_Cactus.prefab` | Cactus. |
| Model | `Assets/Model/Panel2.fbx` | Information or selection panel model. |
| Materials | `Assets/Material/*.mat` | Standard, hover, and background panel materials. |

## Development Notes

- Create a data configuration for each plant, such as name, light requirement, temperature, watering frequency, and display icons.
- Split plant spawning, removal, and selection into clearer controller input modules to make the plant selection panel easier to maintain.
- Put generated plants under a shared parent object so layouts can be saved, cleared, or exported more easily.
- Add placement validation and collision checks to prevent plants from spawning in invalid areas or overlapping each other.
- Add full Unity project files, especially `ProjectSettings/` and `Packages/manifest.json`, so new developers can open the project directly.

## Known Notes

- This repository is not a complete Unity project; it currently contains only an asset subset.
- If `.meta` files are missing, Unity may regenerate GUIDs and break script references in scenes or prefabs.
- The scripts depend on `OVRInput`, so compilation will fail until the Meta XR/Oculus package is installed.
- The scene contains Interaction SDK and TextMeshPro objects. Missing packages may appear as Missing Script or Missing Component in Unity.

## Contributing

1. Fork this repository.
2. Create a feature branch, such as `feat/plant-selector` or `fix/spawn-placement`.
3. Before submitting, open `MasterWork1.unity` in Unity and confirm there are no Missing Script, Missing Prefab, or compilation errors.
4. Open a Pull Request and include the tested device, Unity version, and Meta XR SDK version.

## License

This project is licensed under the MIT License. Before public release or external collaboration, also add a `LICENSE` file and clarify the licensing scope for third-party assets, models, and SDKs.
