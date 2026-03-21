# 🏊‍♂️ Triathlon Training

Aplicación completa para gestionar entrenamientos de triatlón con Clean Architecture y .NET 10.

## 📋 Características

- ✅ CRUD completo de entrenamientos
- 🔍 Filtrado por fecha y deporte
- 💾 Almacenamiento en memoria (ideal para testing)
- 🧪 Tests unitarios con Moq
- 📐 Clean Architecture
- 🌐 Interfaz web con Blazor

## 🏗️ Arquitectura

```
TriathlonTraining/
├── TriathlonTraining.Api/           # API Minimal (.NET 10)
├── TriathlonTraining.Blazor/       # Aplicación Blazor Web
├── TriathlonTraining.Application/  # DTOs, Services, Interfaces
├── TriathlonTraining.Domain/       # Entities, Enums, Repository Interfaces
├── TriathlonTraining.Infrastructure/# Repositorio en memoria
└── TriathlonTraining.Tests/       # Tests unitarios
```

## 🚀 Inicio Rápido

```bash
# Restaurar paquetes
dotnet restore

# Compilar todo
dotnet build

# Ejecutar tests
dotnet test

# Iniciar API (puerto 5239)
dotnet run --project TriathlonTraining.Api

# En otra terminal, iniciar Blazor (puerto 5131)
dotnet run --project TriathlonTraining.Blazor
```

## 🌐 Aplicación Blazor

Interfaz web moderna para gestionar entrenamientos.

**URL:** http://localhost:5131

### Funcionalidades
- 📋 Listado de entrenamientos con tarjetas
- 🔍 Filtros por deporte y fecha
- ➕ Crear nuevos entrenamientos
- ✏️ Editar entrenamientos existentes
- 🗑️ Eliminar con confirmación
- 📱 Diseño responsive

### Deportes
| ID | Emoji | Deporte |
|----|-------|---------|
| 1 | 🏊 | Natación |
| 2 | 🚴 | Ciclismo |
| 3 | 🏃 | Atletismo |

## 📡 API REST

**URL:** http://localhost:5239

### Endpoints

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/trainings` | Listar todos los entrenamientos |
| `GET` | `/api/trainings/{id}` | Obtener por ID |
| `GET` | `/api/trainings/by-date/{fecha}` | Filtrar por fecha |
| `GET` | `/api/trainings/by-sport/{tipo}` | Filtrar por deporte |
| `POST` | `/api/trainings` | Crear entrenamiento |
| `PUT` | `/api/trainings/{id}` | Actualizar entrenamiento |
| `DELETE` | `/api/trainings/{id}` | Eliminar entrenamiento |

### Ejemplo de Request

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

| Componente | Tecnología |
|------------|------------|
| API | ASP.NET Core Minimal APIs |
| Frontend | Blazor Web |
| Testing | xUnit + Moq |
| UI | Bootstrap 5 + Bootstrap Icons |
| Framework | .NET 10 |

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

## 🧪 Tests

```bash
# Ejecutar todos los tests
dotnet test

# Ver cobertura
dotnet test --collect:"XPlat Code Coverage"
```

**Tests incluidos:**
- TrainingService: 9 tests
- InMemoryTrainingRepository: 4 tests

## 📜 Licencia

MIT
