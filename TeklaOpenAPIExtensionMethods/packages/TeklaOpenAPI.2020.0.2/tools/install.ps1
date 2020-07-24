param($installPath, $toolsPath, $package, $project)

$asms = $package.AssemblyReferences | %{$_.Name}
$test = "*Test"
$gacRefences = @("Akit5.dll","Tekla.Logging.dll","Tekla.Application.Library.dll","Tekla.Technology.Scripting.dll", "Tekla.Technology.Rkit.dll", "Tekla.Technology.Msglib.dll","Tekla.Technology.Serialization.dll","tekla.Structures.dll","Tekla.Structures.Datatype.dll","Tekla.Structures.Dialog.dll","Tekla.Structures.Drawing.dll","Tekla.Structures.Model.dll","Tekla.Structures.Plugins.dll","Tekla.Structures.Analysis.dll","Tekla.Structures.Catalogs.dll","Tekla.Common.Geometry.Primitives.dll","Tekla.Common.Geometry.dll","Tekla.Common.Geometry.Shapes.dll")

ForEach ($item in $project.Object) { Write-Host $item.Name } 
Write-Host "AssemblyName:" $project.Name
Write-Host "References in Package:" $asms
Write-Host "Gac in Package:" $gacRefences

if (($project.Name -NotLike "*Test") -and ($project.Name -NotLike "*Tests"))
{
    $outputFolder = $project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value
    Write-Host "Current Output:" $outputFolder
        
    if (($outputFolder -like "*Applications*") -or ($outputFolder -like "*IntegrationTests*"))
    {
        Write-Host "Application Output Project:" $project.Properties.Item("FullPath").Value
        
        foreach ($reference in $project.Object.References)
        {        
            if ($asms -contains $reference.Name + ".dll")
            {      
                if ($gacRefences -contains $reference.Name + ".dll")
                { 
                    $reference.CopyLocal = $false;
                    Write-Host "Disable Copy Local for GAC Reference: " $reference.Name
                }
                else
                {
                    $reference.CopyLocal = $true;
                    Write-Host "Enable Copy Local for Non GAC Reference: "  $reference.Name
                }
                
                $reference.SpecificVersion = $true;
                if ($reference.Name -eq "Akit5")
                {
                    Write-Host "Disable InteropTypes for Akit5"
                    $reference.EmbedInteropTypes = $false;           
                }            
            }
        }         
    }
    else
    {
        foreach ($reference in $project.Object.References)
        {
            Write-Host "ReferenceName:" $reference.Name
            
            if ($asms -contains $reference.Name + ".dll")
            {            
                Write-Host "Ensure TeklaStructures references are using correct properties:" $reference.Name
                Write-Host "Disable Copy Local and Set SpecificVersion to true"
                $reference.CopyLocal = $false;
                $reference.SpecificVersion = $true;
                              
                if ($reference.Name -eq "Akit5")
                {
                    Write-Host "Disable InteropTypes for Akit5"
                    $reference.EmbedInteropTypes = $false;           
                }
            }        
        }    
    }
}