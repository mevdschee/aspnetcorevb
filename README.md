# aspnetcore2-vb-template

Example for using ASP.net Core 2.0 in Visual Basic.

When you run this code using 'dotnet run' you will encounter:

    fail: Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware[0]
          An unhandled exception has occurred: One or more compilation failures occurred:
          b5wu0gxr.ehr(1,1): error CS8301: Invalid name for a preprocessing symbol; ',NETCOREAPP2_0' is not a valid identifier
    Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException: One or more compilation failures occurred:
    b5wu0gxr.ehr(1,1): error CS8301: Invalid name for a preprocessing symbol; ',NETCOREAPP2_0' is not a valid identifier
       at Microsoft.AspNetCore.Mvc.Razor.Internal.RazorViewCompiler.CompileAndEmit(RazorCodeDocument codeDocument, String generatedCode)
       at Microsoft.AspNetCore.Mvc.Razor.Internal.RazorViewCompiler.CompileAndEmit(String relativePath)
       at Microsoft.AspNetCore.Mvc.Razor.Internal.RazorViewCompiler.CreateCacheEntry(String normalizedPath)
    --- End of stack trace from previous location where exception was thrown ---

Due to the file 'bin/Debug/netcoreapp2.0/App.deps.json' having:

    {
      "runtimeTarget": {
        "name": ".NETCoreApp,Version=v2.0",
        "signature": "a7aa306d2e264d92ffef06296341a5e29b6e41eb"
      },
      "compilationOptions": {
        "defines": [
          ",NETCOREAPP2_0"

Replace that leading comma in the last line and run again with 'dotnet run'.

Other than that it seems to work with cshtml, as there seems to be no vbhtml support yet.
