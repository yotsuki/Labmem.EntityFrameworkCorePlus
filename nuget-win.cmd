cd src\Labmem.EntityFrameworkCorePlus
dotnet pack -c release --version-suffix "rc3" -o ..\..\nuget\
#copy /y bin\release\*.nupkg ..\..\nuget\

cd ..\Labmem.EntityFrameworkCorePlus.Attributes
dotnet pack -c release --version-suffix "rc3" -o ..\..\nuget\
#copy /y bin\release\*.nupkg ..\..\nuget\

cd ..\Labmem.EntityFrameworkCorePlus.Sqlite
dotnet pack -c release --version-suffix "rc3" -o ..\..\nuget\
#copy /y bin\release\*.nupkg ..\..\nuget\

cd ..\Labmem.EntityFrameworkCorePlus.SqlServer
dotnet pack -c release --version-suffix "rc3" -o ..\..\nuget\
#copy /y bin\release\*.nupkg ..\..\nuget\



cd ..\..\