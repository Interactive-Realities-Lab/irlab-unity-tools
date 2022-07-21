# IRLab Unity tools
Repo for a Unity package that contains code that usually end up being written when working on projects.

# Installing with Unity Package Manager

To install this project as a [Git dependency](https://docs.unity3d.com/Manual/upm-git.html) using the Unity Package Manager,
add the following line to your project's `manifest.json`:

```
"com.IRLab.irlab-unity-tools": "https://irlab.uncg.edu:8081/irlab/irlab-unity-tools"
```

You will need to have Git installed and available in your system's PATH.

If you are using [Assembly Definitions](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html) in your project, you will need to add `DapperTools` and/or `DapperToolsEditor` as Assembly Definition References.
