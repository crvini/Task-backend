# 🖥️ API de Gestión de Tareas (Backend .NET)

Este proyecto es un backend en **.NET Core** para una aplicación de gestión de tareas. Proporciona una API RESTful que permite realizar operaciones CRUD sobre tareas.

## 🚀 Características
- 📋 Obtener todas las tareas
- ➕ Crear una nueva tarea
- ✅ Marcar tarea como completada
- ❌ Eliminar tarea
- 🔎 Filtrar tareas por estado (Pendientes/Completadas)

## 🏗️ Tecnologías Utilizadas
- **.NET Core 8**
- **Entity Framework Core** (Base de datos en memoria)
- **C#**
- **Swagger** (para documentación de la API)
- **Docker** (para despliegue en Render)

---
## 📦 Instalación y Configuración

### **1️⃣ Clonar el repositorio**
```sh
git clone https://github.com/crvini/Task-backend.git
cd task-backend
```

### **2️⃣ Restaurar dependencias**
```sh
dotnet restore
```

---
## ▶️ Ejecución con Docker

### **1️⃣ Construir la imagen Docker**
```sh
docker build -t task-backend .
```

### **2️⃣ Ejecutar el contenedor**
```sh
docker run -p 8080:8080 task-backend
```
El backend se ejecutará en `http://localhost:8080`

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
│── Dockerfile
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
## 🌍 Despliegue en Render con Docker
1️⃣ **Subir el código a GitHub**
```sh
git init
git add .
git commit -m "Initial commit"
git remote add origin https://github.com/crvini/Task-backend.git
git push -u origin main
```

2️⃣ **Ir a [Render](https://render.com)** y crear un "New Web Service".
3️⃣ **Configurar el servicio** con los siguientes comandos:
   - **Dockerfile Path:** `./Dockerfile`
   - **Instance Type:** `Free`
4️⃣ **Hacer clic en "Deploy" y obtener la URL pública**.

---
## 🔗 Verificar la API en Producción
Puedes probar la API desplegada en Render accediendo a:

🔹 **Swagger UI:** [https://task-backend-h2eb.onrender.com/swagger/index.html](https://task-backend-h2eb.onrender.com/swagger/index.html)

---