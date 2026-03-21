# 🏊‍♂️ Triathlon Training API

API Minimal para gestionar entrenamientos de triatlón con Clean Architecture y .NET 10.

## 📋 Características

- ✅ CRUD completo de entrenamientos
- 🔍 Filtrado por fecha y deporte
- 💾 Almacenamiento en memoria (ideal para testing)
- 🧪 Tests unitarios con Moq
- 📐 Clean Architecture

## 🏗️ Arquitectura

```
TriathlonTraining/
├── TriathlonTraining.Api/          # API Minimal
├── TriathlonTraining.Application/  # DTOs, Services, Interfaces
├── TriathlonTraining.Domain/       # Entities, Enums, Repository Interfaces
├── TriathlonTraining.Infrastructure/# Repositorio en memoria
└── TriathlonTraining.Tests/        # Tests unitarios
```

## 🚀 Inicio Rápido

```bash
# Restaurar paquetes
dotnet restore

# Compilar
dotnet build

# Ejecutar tests
dotnet test

# Iniciar API
cd TriathlonTraining.Api
dotnet run
```

## 📡 Endpoints

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/trainings` | Listar todos los entrenamientos |
| `GET` | `/api/trainings/{id}` | Obtener por ID |
| `GET` | `/api/trainings/by-date/{fecha}` | Filtrar por fecha |
| `GET` | `/api/trainings/by-sport/{tipo}` | Filtrar por deporte |
| `POST` | `/api/trainings` | Crear entrenamiento |
| `PUT` | `/api/trainings/{id}` | Actualizar entrenamiento |
| `DELETE` | `/api/trainings/{id}` | Eliminar entrenamiento |

## 🏊 Deportes Disponibles

| ID | Deporte |
|----|---------|
| 1 | Natación |
| 2 | Ciclismo |
| 3 | Atletismo |

## 📝 Ejemplo de Request

```bash
# Crear entrenamiento
curl -X POST http://localhost:5239/api/trainings \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Natacion matutina",
    "sportType": 1,
    "trainingDate": "2026-03-21T08:00:00",
    "distanceKm": 2.5,
    "duration": "00:45:00",
    "description": "Entrada de nado suave",
    "averageHeartRate": 140
  }'
```

## 🔧 Tecnologías

- [.NET 10](https://dotnet.microsoft.com/)
- [ASP.NET Core Minimal APIs](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Moq](https://github.com/moq/moq) - Para tests

## 📂 Estructura de un Entrenamiento

| Campo | Tipo | Descripción |
|-------|------|-------------|
| `id` | Guid | Identificador único |
| `title` | string | Título del entrenamiento |
| `sportType` | int | Tipo de deporte (1-3) |
| `trainingDate` | DateTime | Fecha del entrenamiento |
| `distanceKm` | double | Distancia en km |
| `duration` | TimeSpan | Duración del entrenamiento |
| `description` | string? | Descripción opcional |
| `averageHeartRate` | int | Frecuencia cardíaca promedio |
| `createdAt` | DateTime | Fecha de creación |
| `updatedAt` | DateTime? | Fecha de actualización |

## 📜 Licencia

MIT
