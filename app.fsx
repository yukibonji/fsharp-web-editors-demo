﻿#r "packages/FSharp.Compiler.Service/lib/net45/FSharp.Compiler.Service.dll"
#r "packages/Suave/lib/net40/Suave.dll"
#r "System.Runtime.Serialization.dll"
#load "paket-files/tpetricek/fsharp-web-editors/server/editor.fs"

open Suave
open Suave.Filters
open Microsoft.FSharp.Compiler.SourceCodeServices
open FsWebTools

let scriptSetup = [ "open System" ]
let scriptName = __SOURCE_DIRECTORY__ + "/test.fsx"

let app = 
  choose [
    Editor.part scriptName scriptSetup (FSharpChecker.Create())
    Files.browse (System.IO.Path.Combine(__SOURCE_DIRECTORY__, "paket-files", "tpetricek", "fsharp-web-editors", "client")) ]

startWebServer defaultConfig app