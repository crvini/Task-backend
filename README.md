# 🖥️ API de Gestión de Tareas (Backend .NET)

Este proyecto es un backend en **.NET Core** para una aplicación de gestión de tareas. Proporciona una API RESTful que permite realizar operaciones CRUD sobre tareas.

## 🚀 Características
- 📋 Obtener todas las tareas
- ➕ Crear una nueva tarea
- ✅ Marcar tarea como completada
- ❌ Eliminar tarea
- 🔎 Filtrar tareas por estado (Pendientes/Completadas)

## 🏗️ Tecnologías Utilizadas
- **.NET Core 6/7**
- **Entity Framework Core** (Base de datos en memoria)
- **C#**
- **Swagger** (para documentación de la API)

---
## 📦 Instalación y Configuración

### **1️⃣ Clonar el repositorio**
```sh
git clone https://github.com/crvini/Task-backend
cd task-backend
```

### **2️⃣ Restaurar dependencias**
```sh
dotnet restore
```

---
## ▶️ Ejecución

### **1️⃣ Correr el servidor localmente**
```sh
dotnet run
```
El servidor se ejecutará en `http://localhost:5000` o `https://localhost:5001`

### **2️⃣ Probar la API con Swagger**
Después de iniciar el servidor, puedes acceder a la documentación de la API en:
```sh
http://localhost:5000/swagger
```

---
## 📂 Estructura del Proyecto

```sh
Task-backend/
│── Api/
│   ├── Controllers/ (Controladores API)
│── Core/
│── Infrastructure/
│── appsettings.json
│── Program.cs
│── Startup.cs
```

---
## 🌐 API Endpoints

### **Tareas** (`/api/tasks`)
| Método | Endpoint            | Descripción                 |
|--------|--------------------|-----------------------------|
| GET    | `/api/tasks`       | Obtener todas las tareas   |
| POST   | `/api/tasks`       | Crear una nueva tarea      |
| PUT    | `/api/tasks/{id}`  | Actualizar una tarea       |
| DELETE | `/api/tasks/{id}`  | Eliminar una tarea         |

---
## 🌍 Despliegue en Render
1️⃣ **Subir el código a GitHub**
```sh
git init
git add .
git commit -m "Initial commit"
git remote add origin https://github.com/crvini/Task-backend
git push -u origin main
```

2️⃣ **Ir a [Render](https://render.com)** y crear un "New Web Service".
3️⃣ **Configurar el servicio** con los siguientes comandos:
   - Build Command: `dotnet restore && dotnet build`
   - Start Command: `dotnet run`
4️⃣ **Hacer clic en "Deploy" y obtener la URL pública**.

---