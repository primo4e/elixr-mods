@echo off
::Set Path and Directory
set path=%cd%\bin\9.6
set dir=%cd%

::Output Destination
set dest=%dir%\bin\Mods\Elixr Mods

:: Make our destination directories
mkdir "%dest%\Features Pack"
mkdir "%dest%\Features Pack\Assets"
mkdir "%dest%\Artistry"
mkdir "%dest%\Artistry\Assets"
mkdir "%dest%\EM Energy"
mkdir "%dest%\EM Energy\Assets"
mkdir "%dest%\EM Machines"
mkdir "%dest%\EM Machines\Assets"
mkdir "%dest%\EM SciFi"
mkdir "%dest%\EM SciFi\Assets"
mkdir "%dest%\EM Storage"
mkdir "%dest%\EM Storage\Assets"
mkdir "%dest%\EM Building"
mkdir "%dest%\EM Building\Assets"
mkdir "%dest%\EM Clothing"
mkdir "%dest%\EM Clothing\Assets"
mkdir "%dest%\EM Food"
mkdir "%dest%\EM Food\Assets"
mkdir "%dest%\EM Games"
mkdir "%dest%\EM Games\Assets"
mkdir "%dest%\EM Housing"
mkdir "%dest%\EM Housing\Assets"
mkdir "%dest%\Translations"
mkdir "%dest%\EM Flags"
mkdir "%dest%\EM Flags\Assets"

::Core File Locations
set base=%dir%\EM Framework\Eco.EM.Framework.dll

:: Features Pack
set admin=%path%\Features Pack\net7.0\Eco.EM.Admin.dll
set commands=%path%\Features Pack\net7.0\Eco.EM.Commands.dll
set autodoor=%path%\Features Pack\net7.0\Eco.EM.AutomaticDoors.dll
set daily=%path%\Features Pack\net7.0\Eco.EM.Daily.dll
set home=%path%\Features Pack\net7.0\Eco.EM.Homes.dll
set informatics=%path%\Features Pack\net7.0\Eco.EM.Informatics.dll
set motd=%path%\Features Pack\net7.0\Eco.EM.MOTD.dll
set tp=%path%\Features Pack\net7.0\Eco.EM.TP.dll
set warp=%path%\Features Pack\net7.0\Eco.EM.Warp.dll

:: EM Building
set arches=%path%\EM Building\net7.0\Eco.EM.Building.Arches.dll
set bricks=%path%\EM Building\net7.0\Eco.EM.Building.Bricks.dll
set concrete=%path%\EM Building\net7.0\Eco.EM.Building.Concrete.dll
set greenhouse=%path%\EM Building\net7.0\Eco.EM.Building.Greenhousing.dll
set roadworking=%path%\EM Building\net7.0\Eco.EM.Building.Roadworking.dll
set shelf=%path%\EM Building\net7.0\Eco.EM.Building.Shelving.dll
set tools=%path%\EM Building\net7.0\Eco.EM.Building.Tools.dll
set windows=%path%\EM Building\net7.0\Eco.EM.Building.Windows.dll
set blocks=%path%\EM Building\net7.0\Eco.EM.Building.Blocks.dll
set brickArch=%path%\EM Building\net7.0\Eco.EM.Bricks.Arches.dll
set brick45=%path%\EM Building\net7.0\Eco.EM.Building.Bricks.Corners.dll
set concrete45=%path%\EM Building\net7.0\Eco.EM.Building.Concrete.Corners.dll
set windows45=%path%\EM Building\net7.0\Eco.EM.Building.Windows.Corners.dll

:: EM Food
set farming=%path%\EM Food\net7.0\Eco.EM.Food.Farming.dll
set foodsmoking=%path%\EM Food\net7.0\Eco.EM.Food.FoodSmoking.dll
set hunting=%path%\EM Food\net7.0\Eco.EM.Food.Hunting.dll
set zymol=%path%\EM Food\net7.0\Eco.EM.Food.Zymology.dll
set cafe=%path%\EM Food\net7.0\Eco.EM.Food.Cafe.dll
set cuisine=%path%\EM Food\net7.0\Eco.EM.Food.Cuisine.dll

:: EM Games
set bgames=%path%\EM Games\net7.0\Eco.EM.Games.BoardGames.dll
set btools=%path%\EM Games\net7.0\Eco.EM.Games.BoardTools.dll

:: EM Housing
set furn=%path%\EM Housing\net7.0\Eco.EM.Housing.Furniture.dll
set doors=%path%\EM Housing\net7.0\Eco.EM.Housing.Doors.dll
set paint=%path%\EM Housing\net7.0\Eco.EM.Housing.Paintings.dll

:: EM Clothes
set cloth=%path%\\EM Clothing\net7.0\Eco.EM.Clothes.dll

:: EM Storage
set shipping=%path%\EM Storage\net7.0\Eco.EM.Storage.Shipping.dll
set stock=%path%\EM Storage\net7.0\Eco.EM.Storage.Stockpiling.dll
set wareh=%path%\EM Storage\net7.0\Eco.EM.Storage.Warehousing.dll

:: EM Energy
set electro=%path%\EM Energy\net7.0\Eco.EM.Energy.Electronics.dll
set fuel=%path%\EM Energy\net7.0\Eco.EM.Energy.Fuel.dll
set green=%path%\EM Energy\net7.0\Eco.EM.Energy.GreenEnergy.dll
set nuclear=%path%\EM Energy\net7.0\Eco.EM.Energy.NuclearEnergy.dll
set sensor=%path%\EM Energy\net7.0\Eco.EM.Energy.Sensors.dll

:: EM SciFi
set scifi=%path%\EM SciFi\net7.0\Eco.EM.SciFi.dll

:: EM Machines
set convey=%path%\EM Machines\net7.0\Eco.EM.Machines.Conveyors.dll
set automa=%path%\EM Machines\net7.0\Eco.EM.Machines.Automation.dll
set production=%path%\EM Machines\net7.0\Eco.EM.Machines.Production.dll
set trucks=%path%\EM Machines\net7.0\Eco.EM.Machines.Trucking.dll
set cars=%path%\EM Machines\net7.0\Eco.EM.Machines.Vehicles.dll

:: EM Artistry
set arts=%path%\Artistry\net7.0\Eco.EM.Artistry.dll

set changelog=%dir%\ChangeLog.txt

:: EM Flags
set flags=%path%\Flags\net7.0\Eco.EM.Flags.dll

::Assets File Transfer for Release\Testing Builds
set featassets=%dir%\Built Unity Assets\9.6\Features Pack\Assets

set convenassets=%dir%\Built Unity Assets\9.6\EM Energy\Assets
set convmachassets=%dir%\Built Unity Assets\9.6\EM Machines\Assets
set convsciassets=%dir%\Built Unity Assets\9.6\EM SciFi\Assets
set convstoreassets=%dir%\Built Unity Assets\9.6\EM Storage\Assets

set decobuildassets=%dir%\Built Unity Assets\9.6\EM Building\Assets
set decoclothassets=%dir%\Built Unity Assets\9.6\EM Clothing\Assets
set decofoodassets=%dir%\Built Unity Assets\9.6\EM Food\Assets
set decogameassets=%dir%\Built Unity Assets\9.6\EM Games\Assets
set decohousingassets=%dir%\Built Unity Assets\9.6\EM Housing\Assets

set artassets=%dir%\Built Unity Assets\9.6\Artistry\Assets

set flagsassets=%dir%\Built Unity Assets\9.6\EM Flags\Assets

::File Destinations
set feat=%dest%\Features Pack
set art=%dest%\Artistry

::Sub Folder Destinations
set conven=%dest%\EM Energy
set convmach=%dest%\EM Machines
set convsci=%dest%\EM SciFi
set convstore=%dest%\EM Storage

set decobuild=%dest%\EM Building
set decocloth=%dest%\EM Clothing
set decofood=%dest%\EM Food
set decogame=%dest%\EM Games
set decohousing=%dest%\EM Housing

set flagsdest=%dest%\EM Flags

::Assets Destinations
set featasset=%feat%\Assets

set convenasset=%conven%\Assets
set convmachasset=%convmach%\Assets
set convsciasset=%convsci%\Assets
set convstoreasset=%convstore%\Assets

set decobuildasset=%decobuild%\Assets
set decoclothasset=%decocloth%\Assets
set decofoodasset=%decofood%\Assets
set decogameasset=%decogame%\Assets
set decohousingasset=%decohousing%\Assets

set artasset=%art%\Assets

set flagassetsdest=%flagsdest%\Assets

::Extract Files
@echo on
copy "%base%" "%dest%" /y
copy "%arts%" "%art%" /y

copy "%admin%" "%feat%" /y
copy "%commands%" "%feat%" /y
copy "%daily%" "%feat%" /y
copy "%home%" "%feat%" /y
copy "%informatics%" "%feat%" /y
copy "%motd%" "%feat%" /y
copy "%tp%" "%feat%" /y
copy "%warp%" "%feat%" /y
copy "%autodoor%" "%feat%" /y

copy "%arches%" "%decobuild%" /y
copy "%bricks%" "%decobuild%" /y
copy "%concrete%" "%decobuild%" /y
copy "%greenhouse%" "%decobuild%" /y
copy "%roadworking%" "%decobuild%" /y
copy "%shelf%" "%decobuild%" /y
copy "%tools%" "%decobuild%" /y
copy "%windows%" "%decobuild%" /y
copy "%blocks%" "%decobuild%" /y
copy "%brickarch%" "%decobuild%" /y
copy "%brick45%" "%decobuild%" /y
copy "%concrete45%" "%decobuild%" /y
copy "%windows45%" "%decobuild%" /y

copy "%cloth%" "%decocloth%" /y

copy "%furn%" "%decohousing%" /y
copy "%doors%" "%decohousing%" /y
copy "%paint%" "%decohousing%" /y

copy "%farming%" "%decofood%" /y
copy "%foodsmoking%" "%decofood%" /y
copy "%hunting%" "%decofood%" /y
copy "%zymol%" "%decofood%" /y
copy "%cafe%" "%decofood%" /y
copy "%cuisine%" "%decofood%" /y

copy "%bgames%" "%decogame%" /y
copy "%btools%" "%decogame%" /y

copy "%scifi%" "%convsci%" /y

copy "%shipping%" "%convstore%" /y
copy "%stock%" "%convstore%" /y
copy "%wareh%" "%convstore%" /y

copy "%electro%" "%conven%" /y
copy "%fuel%" "%conven%" /y
copy "%green%" "%conven%" /y
copy "%nuclear%" "%conven%" /y
copy "%sensor%" "%conven%" /y

::copy "%tailings%" "%conv%" /y

copy "%convey%" "%convmach%" /y
copy "%automa%" "%convmach%" /y
copy "%production%" "%convmach%" /y
copy "%trucks%" "%convmach%" /y
copy "%cars%" "%convmach%" /y

copy "%flags%" "%flagsdest%" /y

::Assets Files Extraction
"C:\Windows\System32\robocopy.exe" /s "%featassets%" "%featasset%"

"C:\Windows\System32\robocopy.exe" /s "%decobuildassets%" "%decobuildasset%"
"C:\Windows\System32\robocopy.exe" /s "%decoclothassets%" "%decoclothasset%"
"C:\Windows\System32\robocopy.exe" /s "%decofoodassets%" "%decofoodasset%"
"C:\Windows\System32\robocopy.exe" /s "%decogameassets%" "%decogameasset%"
"C:\Windows\System32\robocopy.exe" /s "%decohousingassets%" "%decohousingasset%"
	 
"C:\Windows\System32\robocopy.exe" /s "%convenassets%" "%convenasset%"
"C:\Windows\System32\robocopy.exe" /s "%convmachassets%" "%convmachasset%"
"C:\Windows\System32\robocopy.exe" /s "%convsciassets%" "%convsciasset%"
"C:\Windows\System32\robocopy.exe" /s "%convstoreassets%" "%convstoreasset%"
 
"C:\Windows\System32\robocopy.exe" /s "%artassets%" "%artasset%"
	 
"C:\Windows\System32\robocopy.exe" /s "%flagsassets%" "%flagassetsdest%"
@echo off
pause