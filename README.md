# ProjectEF

Este proyecto es el resultado de la realizacion del curso de [Curso de Fundamentos de Entity Framework](https://platzi.com/cursos/entity-framework/) en Platzi

## Requisitos previos

Asegúrate de tener instalado lo siguiente antes de ejecutar el proyecto:

- [.NET Core SDK](https://dotnet.microsoft.com/download) (versión 7.X.X o superior)
- [PostgreSQL](https://www.postgresql.org/download) (versión 14.X.X o superior) si deseas utilizar la base de datos en PostgreSQL

## Configuración

En este proyecto, se utiliza Entity Framework para manejar dos bases de datos: una base de datos en memoria o una base de datos en PostgreSQL. A continuación se detalla cómo configurar cada una de ellas.

### Base de datos en memoria

1. Abre el archivo `appsettings.json`.
2. Asegúrate de que la sección `"ConnectionStrings"` tenga la siguiente configuración:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=:memory:"
}
```

### Base de datos en PostgreSQL

1. Asegúrate de tener instalado PostgreSQL y de tener una base de datos creada.

2. Abre el archivo appsettings.json.

3. Asegúrate de que la sección "ConnectionStrings" tenga la siguiente configuración:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=5432;Database=NombreBaseDeDatos;Username=NombreUsuario;Password=Contraseña"
}
```

Reemplaza NombreBaseDeDatos, NombreUsuario y Contraseña con los valores correspondientes para tu base de datos PostgreSQL.

### Migraciones

Este proyecto utiliza migraciones de Entity Framework para crear y mantener la estructura de la base de datos. A continuación se detallan los pasos para ejecutar las migraciones:

1. Abre una terminal en la ubicación raíz del proyecto.

2. Ejecuta el siguiente comando para aplicar las migraciones a la base de datos en uso:

    `dotnet ef database update`

### Ejecución

1. Abre una terminal en la ubicación raíz del proyecto.

2. Ejecuta el siguiente comando para compilar y ejecutar el proyecto:

    `dotnet run`

El proyecto se ejecutará y estará disponible en http://localhost:XXXX.

### Contribuciones

Si deseas contribuir a este proyecto, sigue los siguientes pasos:

1. Haz un fork de este repositorio.

2. Crea una rama para tu contribución: git checkout -b nombre-rama.

3. Realiza los cambios necesarios y realiza los commits: git commit -am 'Descripción de los cambios'.

4. Envía tus cambios al repositorio remoto: git push origin nombre-rama.

5.Abre un pull request en este repositorio.

### Licencia

Indica aquí la licencia bajo la cual se distribuye el proyecto, por ejemplo:

Este proyecto está licenciado bajo la Licencia MIT.


***Recuerda reemplazar "Nombre del Proyecto", "Descripción del proyecto", y los detalles de configuración de la base de datos según tus necesidades.***
