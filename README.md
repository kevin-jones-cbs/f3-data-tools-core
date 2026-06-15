# f3-data-tools-core

Shared .NET library for F3 Data Tools. This project owns the data models, region definitions, shared calculation helpers, and Lambda action registry used by the backend and frontend.

## Lambda Actions

`LambdaActions.cs` is the shared registry for backend action names. Use `LambdaActions.*` constants instead of string literals when setting `FunctionInput.Action` in the backend, frontend, tests, or smoke tools.

Each action has metadata that describes whether it requires a region, whether it writes data, and whether it belongs in smoke tests. Only read-only actions should be marked with `includeInSmokeTests: true`.

After changing this project, build `F3Core.dll` and copy it into both consuming repositories:

```bash
dotnet build f3-data-tools-core/F3Core.csproj -c Debug
cp f3-data-tools-core/bin/Debug/net6.0/F3Core.dll f3-data-tools-backend/F3Lambda/Packages/
cp f3-data-tools-core/bin/Debug/net6.0/F3Core.dll f3-data-tools-frontend/F3Wasm/Packages/
```
