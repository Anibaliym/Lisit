# Desarrollo #

Microservicio responsable de administrar toda la informacion y procesos asociados a los usuarios, localización y servicios de ayudas sociales.

## Estructura de proyecto

### Directorio `src`

Este directorio contiene todo el codigo fuente asociado al proyecto

### Directorio `db`

Este directorio contiene los scripts iniciales e informacion para la generacion de los repositorios de datos.
Se debe ejecutar el único archivo "GeneraBaseDeDatos"


## Tecnologías Implementadas:

- ASP.NET WebApi Core
- ASP.NET Identity Core
- Entity Framework Core 6.0
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI with JWT support
- Script de generación de base de datos (SQL Server)

## Architecture:

- Arquitectura completa con preocupaciones de separación de responsabilidades, código SÓLIDO y limpio
- Diseño basado en dominios (capas y patrón de modelo de dominio)
- Eventos de dominio
- Validaciones de dominio
- Búsqueda de eventos
- Repositorio

