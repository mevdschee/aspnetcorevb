# ASP.Net Core Web Application in Visual Basic

I ported the example "ASP.Net Core Web Application" from C# to VB.net. It is (successfully) using Razor .cshtml files in a VB project. I have ensured it is compatible with ASP.Net Core 2.1.

When you run this code using 'dotnet run' you will encounter:

    fail: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware[1]
        An unhandled exception has occurred while executing the request.
    Microsoft.AspNetCore.Mvc.Razor.Compilation.CompilationFailedException: One or more compilation failures occurred:
    wjrfi1bi.4iy(1,1): error CS8301: Invalid name for a preprocessing symbol; ',NETCOREAPP,NETCOREAPP2_1' is not a valid identifier
    at Microsoft.AspNetCore.Mvc.Razor.Internal.RazorViewCompiler.CompileAndEmit(RazorCodeDocument codeDocument, String generatedCode)
    at Microsoft.AspNetCore.Mvc.Razor.Internal.RazorViewCompiler.CompileAndEmit(String relativePath)
    at Microsoft.AspNetCore.Mvc.Razor.Internal.RazorViewCompiler.OnCacheMiss(String normalizedPath)
    --- End of stack trace from previous location where exception was thrown ---

Due to the file 'bin/Debug/netcoreapp2.1/App.deps.json' having:

    {
        "runtimeTarget": {
            "name": ".NETCoreApp,Version=v2.1",
            "signature": "8d19439ef22c432fe18f0eac697c8789fe30c00a"
        },
        "compilationOptions": {
            "defines": [
            ",NETCOREAPP,NETCOREAPP2_1"

Remove `,NETCOREAPP,` (including the commas) in the last line and run again with 'dotnet run'.

Other than that it seems to work with cshtml, as there seems to be no vbhtml support yet.
