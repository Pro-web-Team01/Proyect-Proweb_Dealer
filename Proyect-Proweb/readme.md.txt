-----****Requerimientos****------
- Tener instalado SQL SERVER 2022 Developer Edition - Importante!, si tienes el 2019 desinstalalo e instala el 2022.
- Winrar
- Instalar GIT
- Visual Studio 2022

----****Archivos que no debes tocar a menos que sea necesario y si conoces su funcionalidad (Se debe avisar que realizaste un cambio y debes describir que cambios realizaste)****

- Program.cs
- DealerContext
- appsettings.json
- appsettings.Development
- Archivos que se encuentran dentro de la carpetas: Areas, Models y Data 


-----****Primeros pasos****-----
1. Descargar el proyecto de github
2. Extraer e proyecto
3. Entrar a SQL SERVER 2022, iniciar sesion
 3.1 - Clic derecho sobre "Databases"
 3.2 - Clic sobre "Restore Databases" 
 	3.2.1 - En la seccion "Source", clic en el check "Device" y luego clic en el cuadrito con los tres puntos
	3.2.2 - En la nueva ventana que se desplego clic en "Add"
	3.2.3 - En la nueva ventana con el explorador de archivos, buscar la carpeta del proyecto y clic en el archivo 			  "Dealer.bak" y luego clic en ok en las demas pestañas
	3.2.4 - La base de datos fue restaurada.
4. Abrir la carpeta del proyecto
	4.1 Clic en la carpeta ¨Dealer-ProWEb¨ y luego doble clic en el archivo "Dealer-ProWeb.sln"
	4.2 Se abrira una ventana de Visual Studio 2022 y el proyecto debe cargar.

5. Lo demas lo trataremos en las reuniones por Google Meet