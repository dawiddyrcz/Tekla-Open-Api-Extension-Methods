## Tekla-Open-Api-Extension-Methods
Nuget package with extension methods to the Tekla Structures Open Api assemblies i.e methods ModelObjectEnumerator.ToList()

Package install itself as source codes so there are no problem with cross dependencies. 

## Download
https://www.nuget.org/packages/TeklaOpenApiExtensionMethods/

`PM> Install-Package TeklaOpenApiExtensionMethods`

## Examples:
### Get all model objects: ###

```csharp

 var model = new Tekla.Structures.Model.Model();
 var allObjects = model.GetModelObjectSelector().GetAllObjects().ToList();
 
```

### Get all beams from model: ###

```csharp

 var model = new Tekla.Structures.Model.Model();
 var beams = model.GetModelObjectSelector().GetAllObjects().ToList<Tekla.Structures.Model.Beam>();
 
```

### Get selected model object: ###

```csharp

var selector = new Tekla.Structures.Model.UI.ModelObjectSelector();
var selectedObjects = selector.GetSelectedObjects().ToList<>();

```

### Get selected assemblies: ###

```csharp

var selector = new Tekla.Structures.Model.UI.ModelObjectSelector();
var selectedAssemblies = selector.GetSelectedObjects().ToList<TSM.Assembly>();

```

### Get all views from drawing: ###

```csharp

var dh = new Tekla.Structures.Drawing.DrawingHandler();
var currentDrawing = dh.GetActiveDrawing();
var views =  currentDrawing.GetSheet().GetViews().ToList<Tekla.Structures.Drawing.View>();

```

### Get section mark from a view: ###

```csharp
Tekla.Structures.Drawing.View view;

(...)

var sectionMarks = view.GetObjects<TSD.SectionMark>();

```

## How to contribute: ##

1. Fork this repository

2. Create new branch

3. Add your code

4. Make pull request to the branch "master"
