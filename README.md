# GimnasioApi

API REST creada con ASP.NET Core para la gestión de clientes de un gimnasio.  
Permite registrar, consultar, modificar y eliminar clientes, con conexión a base de datos SQL Server.

## 🚀 Tecnologías usadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server Express
- Swagger (OpenAPI)

## 📂 Estructura principal

- `Models/Cliente.cs`: definición de entidad Cliente
- `Data/GimnasioContext.cs`: contexto de base de datos EF Core
- `Controllers/ClientesController.cs`: controlador de API
- `Migrations/`: contiene las migraciones EF
- `appsettings.json`: configuración y cadena de conexión

## ⚙️ Endpoints disponibles

- `GET /api/Clientes` → lista todos los clientes
- `GET /api/Clientes/{id}` → busca por ID
- `POST /api/Clientes` → crea un nuevo cliente
- `PUT /api/Clientes/{id}` → actualiza un cliente
- `DELETE /api/Clientes/{id}` → elimina un cliente

## 🛠️ Cómo ejecutar este proyecto

1. Clonar el repositorio:

```bash
git clone https://github.com/IgnacioMata/GimnasioApi.git
cd GimnasioApi
```

2. Restaurar los paquetes NuGet:

```bash
dotnet restore
```

3. Crear la base de datos (si no existe):

```bash
dotnet ef database update
```

4. Ejecutar la API:

```bash
dotnet run
```

5. Abrir Swagger en el navegador:

```
http://localhost:5085/swagger
```

## 🗄️ Base de datos

- Motor: **SQL Server Express**
- Cadena de conexión (`appsettings.json`):
  ```
  Server=NACHOMATA-PC\SQLEXPRESS01;Database=GimnasioDB;Trusted_Connection=True;TrustServerCertificate=True;
  ```
- Tabla principal: `Clientes`

## ✅ Estado

Proyecto funcional y listo para entrega.  
Swagger habilitado, base de datos conectada, migraciones aplicadas.

---

📚 Trabajo práctico de backend con ASP.NET Core + SQL Server – Ignacio Mata